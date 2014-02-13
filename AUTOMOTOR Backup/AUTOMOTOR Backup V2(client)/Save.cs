using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.InteropServices;




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
        private string saveRoot;
        private DateTime nextSave;
        private TimeSpan tempsRestant;
        private MainForm frm;

        public Save(MainForm mf)
        {
            this.c = new Configuration();
            frm = mf;
            nextSave = initNextSave();
            this.infosCopie = new string[2];
            this.saveRoot = this.getSaveRoot();
            nextSave = initNextSave();
            tempsRestant = nextSave - DateTime.Now;
            if (nextSave.CompareTo(DateTime.Now) < 0)
            {
                reportDateSauvegarde();
            }
        }

        public void execute(BackgroundWorker bgw)
        {

            //Envoi de mail en début de sauvegarde
            try
            {
                Mailer m = new Mailer(this);
                m.sendNotificationDebut();
                Log.notifieDebutSauvegarde();
            }
            catch(Exception e)
            {
                Log.write("- " + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + ": " + e.Message + "/n");
            }

            //Mise à de la date de dernière sauvegarde
            Serialization.serializeLastSaveDate(DateTime.Now);

            //chargement de la liste des fichiers à sauvegarder
            ArrayList pathesList = (ArrayList)Serialization.deserializeXML("folders.xml");
            string path = this.saveRoot + @".tmp";

            //création du dossier de sauvegarde de l'utilisateur
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                if (Directory.Exists(this.saveRoot))
                {
                    Directory.Delete(this.saveRoot, true);
                }
                Directory.CreateDirectory(path);
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show(uae.Message + Environment.NewLine + "veuillez le supprimer manuellement");
            }

            //construction du chemin de sauvegarde des fichiers et copie des fichiers
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
                Log.notifieFinSauvegarde();
                Directory.Move(this.saveRoot + @".tmp", this.saveRoot);
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
            Application.Exit();
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
                    if (!File.Exists(this.saveRoot + @".tmp\" + this.toSavedFilePathFormat(s) + @"\" + fileName))
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
                                File.Copy(filePath, this.saveRoot + @".tmp\" + this.toSavedFilePathFormat(s) + @"\" + fileName, true);
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
                Log.write("erreur: ");
                Log.write(e.Message);
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
                    savedDirPath2 = this.saveRoot + @".tmp" + @"\" + this.toSavedFilePathFormat(savedDirPath) + @"\" + d.Name;
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
            if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + dt.Day + "." + dt.Month + "." + dt.Year) && this.bgwk == null)
            {
                ok = '2';
            }
            else
                if (Directory.Exists(ConfigurationManager.AppSettings["path"] + @"\" + dt.Day + "." + dt.Month + "." + dt.Year + ".tmp") && this.bgwk == null)
                {
                    ok = '0';
                }
                else
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


        //supprime la sauvegarde la plus ancienne tant que la nombre de sauvegardes en plus grand que le nbre de sauvegardes à conserver
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


        public bool checkSaveConditions()
        {
            DateTime lastSave = Serialization.deserializeLastSaveDate(false);
            int heure = Convert.ToInt32(this.c.getHeure());
            int minute = Convert.ToInt32(this.c.getMinute());
            int period = Convert.ToInt32(this.c.getPeriode());
            bool check = false;
            try
            {
                this.tempsRestant = this.nextSave - DateTime.Now;
                TimeSpan tempsEcoule = DateTime.Now - lastSave;
                //this.checkNextSaveDate();
               /* if (this.tempsRestant.Days == 0 && this.tempsRestant.Hours < 15)
                {
                    ShutdownBlockReasonCreate(frm.Handle, "Une sauvegarde automatique va être éffectuée à " + this.nextSave.ToShortTimeString() + "." + Environment.NewLine + " Veuillez ne pas éteindre l'ordinateur");
                }
                else
                { shutdownBlockReasonDestroy(frm.Handle, "Arrêt autorisé"); } */
                 
                //this.afficheAlerte();
                check = this.verifieSiTempsEstEcoule(tempsRestant);
            }
            catch { }
            return check;
        }

        public DateTime initNextSave()
        {
            DateTime d = Serialization.deserializeLastSaveDate(true);
            DateTime nextSave = d.AddDays(c.getPeriode()).AddHours(-d.Hour + c.getHeure()).AddMinutes(-d.Minute + c.getMinute()).AddSeconds(-d.Second);
            return nextSave;
        }

        public DateTime GetNextSave()
        {
            return nextSave;
        }

        public bool verifieSiTempsEstEcoule(TimeSpan t)
        {
            bool ok = false;
            if (t.Days == 0 && t.Hours == 0 && t.Minutes == 0 && t.Seconds == 0)
            {
                ok = true;
            }
            return ok;
        }


        public void SetTempsRestant(TimeSpan t)
        {
            this.tempsRestant = t;
        }

        public void ajouteTemps(TimeSpan t)
        {
            this.tempsRestant.Add(t);
        }

        //report de la sauvegarde à la date actuelle
        public void reportDateSauvegarde()
        {
            if ((this.nextSave < DateTime.Now) || verifieSiTerminee() == '0')
            {
                DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, this.c.getHeure(), this.c.getMinute(), 0);
                if(d.CompareTo(DateTime.Now) >  0)
                {
                nextSave = d.AddDays(1);
                //this.lbDateProchaineSauvegarde1.Text = this.nextSave.ToShortDateString() + " à " + this.nextSave.ToShortTimeString();
                Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " Date de sauvegarde dépassée ou sauvegarde incomplete, réinitialisation de la date de la prochaine sauvegarde, nouvelle valeur: " + this.nextSave.ToString());
                }
            }
        }

        //si la date de la prochaine sauvegarde est antérieure à la date actuelle, reporte la sauvegarde à la date actuelle
        public void checkNextSaveDate()
        {
            if (this.nextSave < DateTime.Now)
            {
                this.nextSave = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, this.c.getHeure(), this.c.getMinute(), 0);
                //this.lbDateProchaineSauvegarde1.Text = this.nextSave.ToShortDateString() + " à " + this.nextSave.ToShortTimeString();
            }
            Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " Date de sauvegarde dépassée, réinitialisation de la date de la prochaine sauvegarde, nouvelle valeur: " + this.nextSave.ToString());
        }

        public TimeSpan GetTempsRestant()
        {
            return tempsRestant;
        }

        public void SetNextSave(DateTime date)
        {
            nextSave = date;
        }

    }

}
