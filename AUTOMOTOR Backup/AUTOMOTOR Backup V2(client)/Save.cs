using System;
using Microsoft.VisualBasic;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Configuration;



namespace clientbackup
{
    public class Save
    {
        private char estTerminée;
        private string fichierCopie;
        private int nbfichierscopie = 0;
        private BackgroundWorker bgwk = null;

        public Save()
        {
            //this.nbFichiersACopier = this.calculNbFichierACopier();
        }

        public void execute(BackgroundWorker bgw)
        {
            try
            {
                Log.notifieDebutSauvegarde(DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + " à " + DateTime.Now.Hour + "h" + DateTime.Now.Minute + ".");
            }
            catch { }
            Serialization.serializeLastSaveDate(DateTime.Now);
            ArrayList pathesList = (ArrayList)Serialization.deserializeXML();
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
                    string savedDirPath = "";
                    savedDirPath += path + @"\" + this.toSavedFilePathFormat(s);
                    if (!Directory.Exists(savedDirPath))
                    {
                        Directory.CreateDirectory(savedDirPath);
                    }
                    this.copyFiles(s, bgw);
                    this.copySubDirectories(s,bgw);
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
            catch{ }
        }

        public static void restartComputer()
        {
            System.Diagnostics.ProcessStartInfo restart = new System.Diagnostics.ProcessStartInfo("shutdown.exe", "-r");
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
                string[] files = Directory.GetFiles(@"C:\" + s);
                foreach (string filePath in files)
                {
                    this.fichierCopie = filePath;
                    string fileName;
                    FileInfo fi = new FileInfo(filePath);
                    fileName = fi.Name;
                    if (!File.Exists(this.getSaveRoot() + @".tmp\" + this.toSavedFilePathFormat(s) + @"\" + fileName))
                    {
                        if (!this.estUnRaccourci(filePath))
                        {
                            File.Copy(filePath, this.getSaveRoot() + @".tmp\" + this.toSavedFilePathFormat(s) + @"\" + fileName);
                            this.nbfichierscopie++;
                            bgw.ReportProgress(nbfichierscopie);
                        }
                    }
                }
            }
            catch(Exception e)
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

        public void copySubDirectories(string savedDirPath,BackgroundWorker bgw)
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
                    this.copySubDirectories(formatedSubdir,bgw);
                    this.copyFiles(savedDirPath + @"\" + d.Name,bgw);
                }
            }
            catch
            {
              
            }
        }

        public string getSaveRoot()
        {
            return ConfigurationManager.AppSettings["path"] + @"\" + Environment.UserName + @"\" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
        }

        public char verifieSiTerminee()
        {
            char ok = '0';
            DateTime dt = Serialization.deserializeLastSaveDate();
            if (this.bgwk != null)
            {
                if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + Environment.UserName + @"\" + dt.Day + "." + dt.Month + "." + dt.Year) && !this.bgwk.IsBusy)
                {
                    ok = '2';
                }
                else
                    if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + Environment.UserName + @"\" + dt.Day + "." + dt.Month + "." + dt.Year + ".tmp") && !this.bgwk.IsBusy)
                    {
                        ok = '0';
                    }
                    else
                        if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + Environment.UserName + @"\" + dt.Day + "." + dt.Month + "." + dt.Year + ".tmp") && this.bgwk.IsBusy)
                        {
                            ok = '1';
                        }
                Serialization.serializeEtatDerniereSave(ok);
            }
            else
            {
                ok = Serialization.deserializeEtatDerniereSave();
            }
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
            ArrayList listRepertoires = Serialization.deserializeXML();
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
            if(new FileInfo(path).Extension == ".lnk")
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
    }

}
