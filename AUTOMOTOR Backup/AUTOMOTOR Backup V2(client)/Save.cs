using System;
using Microsoft.VisualBasic;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Security.AccessControl;
using System.Configuration;



namespace clientbackup
{
    public class Save
    {
        private char estTerminée;
        private string fichierCopie;
        private int nbfichierscopie = 0;
        private long volumeFichiers = 0;
        private BackgroundWorker bgwk = null;
        private string[] infosCopie;
        private const long coeff = 1073741824;
        private const long coeffMo = 1048576;
        private Configuration c;

        public Save()
        {
            //this.nbFichiersACopier = this.calculNbFichierACopier();
            this.c = new Configuration();
            this.infosCopie = new string[2];
        }

        public void execute(BackgroundWorker bgw)
        {
            try
            {
                Mailer m = new Mailer(this);
                m.sendNotificationDebut();
                Log.notifieDebutSauvegarde(DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + " à " + DateTime.Now.Hour + "h" + DateTime.Now.Minute + ".");
            }
            catch { }
            Serialization.serializeLastSaveDate(DateTime.Now);
            ArrayList pathesList = (ArrayList)Serialization.deserializeXML("folders.xml");
            string path = this.getSaveRoot() + @".tmp";
            //création du dossier de sauvegarde de l'utilisateur
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                if (Directory.Exists(this.getSaveRoot()))
                {
                    Directory.Delete(this.getSaveRoot(), true);
                }
                Directory.CreateDirectory(path);
                //DirectorySecurity dirSecurity = new DirectorySecurity(path,AccessControlSections.All);
                //Directory.SetAccessControl(path, dirSecurity);
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show(uae.Message + Environment.NewLine + "veuillez le supprimer manuellement");
            }
            //construction du chemin de sauvegarde des fichiers et
            //copie des fichiers
            foreach (string s in pathesList)
            {
                try
                {
                    if (!this.bgwk.CancellationPending)
                    {
                        string savedDirPath = "";
                        savedDirPath += path + @"\" + this.toSavedFilePathFormat(s);
                        if (!Directory.Exists(savedDirPath))
                        {
                            Directory.CreateDirectory(savedDirPath);
                        }
                        this.copyFiles(s, this.bgwk);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            try
            {
                Log.notifieFinSauvegarde("-" + DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + " à " + DateTime.Now.Hour + "h" + DateTime.Now.Minute + ".");
                Directory.Move(this.getSaveRoot() + @".tmp", this.getSaveRoot());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Log.write(e.Message);
            }
        }

        public static void restartComputer()
        {
            System.Diagnostics.ProcessStartInfo restart = new System.Diagnostics.ProcessStartInfo("shutdown.exe", "-r -t 60");
            System.Diagnostics.Process.Start(restart);
        }

        public static void closeOutlook()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process p in processes)
            {
                if (p.ProcessName == "OUTLOOK")
                {
                    p.Kill();
                }
            }

        }

        public bool isDirectory(string path)
        {
            FileInfo f = new FileInfo(path);
            DirectoryInfo di = new DirectoryInfo(path);
            return f.Attributes == FileAttributes.Directory;
        }

        public void copyFiles(string s, BackgroundWorker bgw)
        {
            try
            {
                ArrayList excludedFiles = (ArrayList)Serialization.deserializeXML("files.xml");
                string[] files = Directory.GetFiles(@"C:\" + s);
                foreach (string filePath in files)
                {
                    this.fichierCopie = new DirectoryInfo(filePath).Name;
                    string fileName;
                    FileInfo fi = new FileInfo(filePath);
                    fileName = fi.Name;
                    if (!File.Exists(this.getSaveRoot() + @".tmp\" + this.toSavedFilePathFormat(s) + @"\" + fileName))
                    {
                        if (!this.estUnRaccourci(filePath))
                        {
                            bool ok = true;
                            foreach (string str in excludedFiles)
                            {
                                if (str == fileName)
                                {
                                    ok = false;
                                }
                            }
                            if (ok)
                            {
                                File.Copy(filePath, this.getSaveRoot() + @".tmp\" + this.toSavedFilePathFormat(s) + @"\" + fileName, true);
                                this.nbfichierscopie++;
                                this.volumeFichiers += fi.Length;
                                bgw.ReportProgress(nbfichierscopie);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.write("----------ERREUR----------\n");
                Log.write("\n");
                //Log.write("erreur lors de la copie de: " + this.fichierCopie);
                Log.write("message d'erreur:");
                Log.write(e.Message);
                Log.write("\n");
                Log.write("--------------------------\n");
                Log.write("\n");
            }
        }

        public void copySubDirectories(string savedDirPath, BackgroundWorker bgw)
        {
            try
            {
                string[] subDirectories = Directory.GetDirectories(@"C:\" + savedDirPath);
                foreach (string subDir in subDirectories)
                {
                    DirectoryInfo d = new DirectoryInfo(subDir);
                    string savedDirPath2 = this.toSavedFilePathFormat(savedDirPath);
                    savedDirPath2 = this.getSaveRoot() + @".tmp" + @"\" + this.toSavedFilePathFormat(savedDirPath) + @"\" + d.Name;
                    if (!Directory.Exists(savedDirPath2))
                    {
                        Directory.CreateDirectory(savedDirPath2);
                    }
                    else
                    {
                        Directory.Delete(savedDirPath2, true);
                        Directory.CreateDirectory(savedDirPath2);
                    }
                    string formatedSubdir = subDir.Remove(0, 3);
                    this.copySubDirectories(formatedSubdir, bgw);
                    this.copyFiles(savedDirPath + @"\" + d.Name, bgw);
                }
            }
            catch
            {

            }
        }

        public string getSaveRoot()
        {
            return ConfigurationManager.AppSettings["path"] + @"\" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
        }

        public char verifieSiTerminee()
        {
            char ok = '0';
            DateTime dt = Serialization.deserializeLastSaveDate(false);
            //si le fichier de sauvegarde final éxiste et le backgroundWorker est inactif
            //sinon si le fichier de sauvegarde temporaire éxiste et que le backgroundworker est inactif
            //sinon si le fichier de sauvegarde temporaire éxiste et que le backgroundworker est actif
            //if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + Environment.UserName + @"\" + dt.Day + "." + dt.Month + "." + dt.Year) && this.bgwk == null)
            if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + dt.Day + "." + dt.Month + "." + dt.Year) && this.bgwk == null)
            {
                ok = '2';
            }
            else
                //if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + Environment.UserName + @"\" + dt.Day + "." + dt.Month + "." + dt.Year + ".tmp") && this.bgwk == null)
                if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + dt.Day + "." + dt.Month + "." + dt.Year + ".tmp") && this.bgwk == null)
                {
                    ok = '0';
                }
                else
                    //if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + Environment.UserName + @"\" + dt.Day + "." + dt.Month + "." + dt.Year + ".tmp") && this.bgwk != null)
                    if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + dt.Day + "." + dt.Month + "." + dt.Year + ".tmp") && this.bgwk != null)
                    {
                        ok = '1';
                    }

            Serialization.serializeEtatDerniereSave(ok);

            return ok;
        }

        public char getEstTerminee()
        {
            return this.estTerminée;
        }

        public void setEstTerminee()
        {
            this.estTerminée = this.verifieSiTerminee();

        }

        public string getNomFichierCopie()
        {
            return this.fichierCopie;
        }

        public int getNbFichiersCopie()
        {
            return this.nbfichierscopie;
        }

        public int calculNbFichierACopier()
        {
            ArrayList listRepertoires = Serialization.deserializeXML("folders.xml");
            int nbfichiers = 0;
            foreach (string rep in listRepertoires)
            {
                try
                {
                    nbfichiers += Directory.GetFiles(@"C:\" + rep, ".", SearchOption.AllDirectories).Length;
                }
                catch
                {
                }
            }

            return nbfichiers;
        }

        public bool estUnRaccourci(string path)
        {
            bool ok = false;
            if (new FileInfo(path).Extension == ".lnk")
            { ok = true; }
            return ok;
        }

        public string toSavedFilePathFormat(string s)
        {
            string formated;
            char[] c = new char[5];
            char c1 = '\\';
            c[0] = c1;
            formated = s.Split(c, 3)[2];
            return formated;
        }

        public void setBgwk(BackgroundWorker bg)
        {
            this.bgwk = bg;
        }

        public void checkSaveNumber()
        {
            string[] directories = Directory.GetDirectories(this.c.getPath());
            int nbSaves = Directory.GetDirectories(this.c.getPath()).Length;
            while (nbSaves > this.c.getNbSaves())
            {
                DateTime dt = Directory.GetCreationTime(directories[0]);
                for (int i = 0; i < directories.Length; i++)
                {
                    DateTime dateCreation = Directory.GetCreationTime(directories[i]);
                    if (dt.CompareTo(dateCreation) > 0)
                    {
                        dt = dateCreation;
                    }
                }
                foreach (string s in directories)
                {
                    if (dt == Directory.GetCreationTime(s))
                    {
                        DirectoryInfo dir = new DirectoryInfo(s);
                        foreach (DirectoryInfo info in dir.GetFileSystemInfos())
                        {
                            if ((info.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                            {
                                info.Attributes = FileAttributes.Normal;
                            }
                        }
                        Directory.Delete(s, true);
                    }
                }
                nbSaves = Directory.GetDirectories(this.c.getPath()).Length;
                directories = Directory.GetDirectories(this.c.getPath());
            }

        }

        public string[] getInfosCopie()
        {
            this.infosCopie[0] = this.getNbFichiersCopie().ToString();
            this.infosCopie[1] = this.getNomFichierCopie();
            return this.infosCopie;
        }

        public long EspaceDispo()
        {
            DriveInfo di = new DriveInfo(new DirectoryInfo(c.getPath()).Root.Name);
            long gigaOctet = di.AvailableFreeSpace / coeff;
            return gigaOctet;
        }

        public long EspaceTotal()
        {
            DriveInfo di = new DriveInfo(new DirectoryInfo(c.getPath()).Root.Name);
            long gigaOctet = di.TotalSize / coeff;
            return gigaOctet;
        }

        public void setNbFichiersCopies(int nb)
        {
            this.nbfichierscopie = nb;
        }

        public long getVolumeFichiers()
        {
            long gigaOctet = this.volumeFichiers / coeffMo;
            return gigaOctet;
        }
    }

}
