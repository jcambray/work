using System;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace clientbackup
{
    public partial class MainForm : Form
    {
        public bool launch = true;
        private bool isAutoLogonEnabled;
        private Configuration c;
        private Save sauvegarde;
        //private TimeSpan tempsRestant;
        //private DateTime nextSave;
        public Thread configFormThread;
        private int j = 0;



        public MainForm()
        {
            InitializeComponent();
            Log.write("- " + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + " Lancement de l'application");
            //chargement des paramètres de l'application
            this.c = new Configuration();
            //Chargement de la date de la derniere sauvegarde
            //initialisation de la date de la prochaine sauvegarde
            //report de la sauvegarde si la dernière sauvegarde ne s'est pas produite
            this.sauvegarde = new Save(this);
            //DateTime lastSave = Serialization.deserializeLastSaveDate(true);
            //this.nextSave = initNextSave(lastSave, this.c.getPeriode(), this.c.getHeure(), this.c.getMinute());
            //Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " Réinitialisation de la date de la prochaine sauvegarde, nouvelle valeur: " + sauvegarde.GetNextSave().ToString());
            //sauvegarde.reportDateSauvegarde();
            //Vérifie si l'utilisateur à accès au répertoire de destination de la sauvegarde au lancement de l'application
            //si non, fermeture de l'application
            if (!(Serialization.deserializeLastSaveDate(false).Year == 2000))
            {

                try
                {
                    Directory.CreateDirectory(this.c.getPath() + @"/test");
                    Directory.Delete(this.c.getPath() + @"/test");
                }
                catch (IOException IOEx)
                {
                    this.launch = false;
                    MessageBox.Show("Il semble que vous n'êtes pas connecté au réseau AMF." + Environment.NewLine + "l'application va fermer.", "AUTOMOTOR Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " : " + IOEx.Message);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("une erreur est survenue au lancement de l'application.", "AUTOMOTOR Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " : " + ex.Message);
                }
            }

            //this.lbProchaineSauvegarde1.Visible = false;
            //this.lbCompteARebours.Visible = false;
            this.Text = "AUTOMOTOR Backup 2.0";
            this.lbUtilisateur1.Text = Environment.UserName;
            this.minimize();

            if (Serialization.deserializeLastSaveDate(false).Year == 2000)
            {
                this.lbDateProchaineSauvegarde1.ForeColor = Color.Red;
                this.lbDateProchaineSauvegarde1.Text = "non planifiée";
            }
            else
            {
                this.lbDateProchaineSauvegarde1.Text = sauvegarde.GetNextSave().ToShortDateString() + " à " + sauvegarde.GetNextSave().ToShortTimeString();
            }


            //Configuration du Timer
            this.configureTimer();
            this.setLbEtatDerniereSauvegarde();
            //Appel de la fonction permettant le bloquage d'arrets Windows
            //ShutdownBlockReasonCreate(this.Handle, "Une sauvegarde automatique va être éffectuée.");

            //chargement de la valeur booléenne indiquant si l'autoLogon est activé en base de registre
            //Si l'AutoLogon est activé en base de registre Windows
            //Désactivation de l'autoLogon en base de registre Windows
            // mise à jour et sauvegarde de la valeur booléenne
            // suppression de la sauvegarde la plus ancienne si le nombre maxi de sauvegarde sera dépassé
            //lancement de la sauvegarde
            this.isAutoLogonEnabled = (bool)Serialization.deserialize();
            if (this.isAutoLogonEnabled == true)
            {
                Thread.Sleep(60000);
                RegistryModifier.disableAutoLogon();
                this.isAutoLogonEnabled = false;
                Serialization.serialize(this.isAutoLogonEnabled);
                this.initSaveViewer();
            }
        }





        [DllImport("user32.dll", EntryPoint = "ShutdownBlockReasonCreate")]
        public extern static void ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string pwszReason);

        [DllImport("user32.dll", EntryPoint="ShutdownBlockReasonDestroy")]
        public extern static bool shutdownBlockReasonDestroy(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string pwszReason);


        //bloque l'arret d'une session windows 
        protected override void WndProc(ref Message m)
        {
            const int WM_QUERYENDSESSION = 0x0011;
            const int WM_ENDSESSION = 0x0016;
            if ((m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION) && ((DateTime.Now.Day * DateTime.Now.Month * DateTime.Now.Year) != (sauvegarde.GetNextSave().Day * sauvegarde.GetNextSave().Month * sauvegarde.GetNextSave().Year)))
            { Application.Exit(); }
            else
                if(m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION)
            {
                return;
            }
            base.WndProc(ref m);
        }

        #region Ouverture du formulaire de configuration après vérification du MDP administrateur
        private void configuraionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mdp = Serialization.deserializeMDPAdmin();
            if (mdp == null)
            {
                MessageBox.Show("mot de passe administrateur introuvable.Veuillez en enregistrer un");
                this.configFormThread = new Thread(new ThreadStart(this.initWaitForm));
                this.configFormThread.Start();
                this.initConfig();
            }
            else
            {
                MDPAdminControl MDPAC = new MDPAdminControl(mdp);
                DialogResult result = MDPAC.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.configFormThread = new Thread(new ThreadStart(this.initWaitForm));
                    this.configFormThread.Start();
                    this.initConfig();
                }
            }
        }
        #endregion

        #region fermeture de l'application après vérification du MDP administrateur
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mdp = Serialization.deserializeMDPAdmin();
            if (mdp == null)
            {
                MessageBox.Show("mot de passe administrateur introuvable.Veuillez en enregistrer un");
                this.configFormThread = new Thread(new ThreadStart(this.initWaitForm));
                this.configFormThread.Start();
                this.initConfig();
            }
            else
            {
                MDPAdminControl MDPAC = new MDPAdminControl(mdp);
                DialogResult result = MDPAC.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " Fermeture de l'application par l'administrateur");
                    Application.Exit();
                }
            }
        }
        #endregion

        #region Lorsque l'utilisateur clique sur le bouton "faire une sauvegarde"
        //Si l'utilisateur accepte le redémarrage de l'ordinateur
        //activation de l'autologon
        //sauvegarde de l'etat de l'autologon à true
        //redémarrage de l'ordinateur
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La sauvegarde necessite le redemarrage de l'ordinateur, voulez-vous redémarrer maintenant?"," ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RegistryModifier.enableAutoLogon(ConfigurationManager.AppSettings["password"]);
                this.isAutoLogonEnabled = true;
                Serialization.serialize(this.isAutoLogonEnabled);
                Save.restartComputer();
            }

        }
        #endregion

        public void configureTimer()
        {
            this.myTimer.Interval = 1000;
            this.myTimer.Enabled = true;
        }

        #region A chaque "tick" du timer:
        //Verification de l'etat de la dernière sauvegarde
        //Si les condition necessaire au lancement d'une sauvegarde sont reunies
        //aret du timer
        //demande de report de la sauvegarde
        //Si oui : redemarrage du timer
        //si non : 
        //activation de l'autologon
        //sauvegarde de l'etat de l'autologon à true
        //lancement du redémarrage de l'ordinateur
        private void myTimer_Tick(object sender, EventArgs e)
        {

            this.MoveCursor(this.j);
            sauvegarde.SetTempsRestant(sauvegarde.GetNextSave() - DateTime.Now);
            if (sauvegarde.checkSaveConditions())
            {
                this.myTimer.Stop();
                ReportSaveForm rsf = new ReportSaveForm(this,sauvegarde);
                DialogResult = rsf.ShowDialog();
                if (DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    sauvegarde.SetNextSave(rsf.getNextSave());
                    this.lbDateProchaineSauvegarde1.Text = sauvegarde.GetNextSave().ToShortDateString() + " à " + c.getHeure() + "h" + c.getMinute();
                    this.myTimer.Start();
                }
                else
                {
                    RegistryModifier.enableAutoLogon(ConfigurationManager.AppSettings["password"]);
                    this.isAutoLogonEnabled = true;
                    Serialization.serialize(this.isAutoLogonEnabled);
                    Save.restartComputer();
                }
            }

            if (sauvegarde.GetTempsRestant().Days == 0 && sauvegarde.GetTempsRestant().Hours < 15)
            {
                ShutdownBlockReasonCreate(this.Handle, "Une sauvegarde automatique va être éffectuée à " + sauvegarde.GetNextSave().ToShortTimeString() + "." + Environment.NewLine + " Veuillez ne pas éteindre l'ordinateur");
            }
            else
            {
                    shutdownBlockReasonDestroy(this.Handle, "Arrêt autorisé"); 
            }
        }
        #endregion


        public void initConfig()
        {
            ConfigForm cf = new ConfigForm(this);
            cf.ShowDialog();
        }


        //affiche une bulle d'information contenant le message et pendant la durée passés en paramètre
        public void afficheNotification(string message, int duree)
        {
            this.notifyIcon.Visible = true;
            this.notifyIcon.Text = message;
            this.notifyIcon.BalloonTipTitle = message;
            this.notifyIcon.ShowBalloonTip(duree);
        }

        //réduit la fenêtre principale
        public void minimize()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
        }

        //agrandit la fenere principale
        public void maximize()
        {
            this.Visible = true;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Normal;
        }

        //lorsque l'on clique sur "réduire"
        private void réduireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.minimize();
        }

        //recalcule la date de la pochaine sauvegarde
        /*public static DateTime initNextSave(DateTime d, int period, int hour, int minute)
        {
            DateTime nextSave = d.AddDays(period).AddHours(-d.Hour + hour).AddMinutes(-d.Minute + minute).AddSeconds(-d.Second);
            return nextSave;
        }*/

        //lorsque l'on clique sur la bulle d'information
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.maximize();
        }

        //Vérifie si le laps de temps entre 2 sauvegardes est écoulé
        /*public bool verifieSiTempsEstEcoule(TimeSpan t)
        {
            bool ok = false;
            if (t.Days == 0 && t.Hours == 0 && t.Minutes == 0 && t.Seconds == 0)
            {
                ok = true;
            }
            return ok;
        }*/

        public void afficheAlerte()
        {

            if (sauvegarde.GetTempsRestant().TotalHours < 6 && sauvegarde.GetTempsRestant().TotalHours > 0 && (DateTime.Now.Minute == 0 && DateTime.Now.Second == 0))
            {
                this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
                this.afficheNotification("jour de sauvegarde ,veuillez ne pas éteindre l'ordinateur", 10000);
                Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " :affiche notification");
            }
            else
            {
                this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            }
        }

        //instancie une nouvelle fenetre permettant le lancement de la sauvegarde et l'affiche à l'ecran
        public void initSaveViewer()
        {
            SaveViewer sv = new SaveViewer(this.sauvegarde, this);
            sv.Show();
        }

        public void notifyIcconAlerte(int heure, int minute, string message, int duree)
        {
            if (DateTime.Now.Day == sauvegarde.GetNextSave().Day && DateTime.Now.Hour == heure && DateTime.Now.Minute == minute)
            {
                this.afficheNotification(message, duree);
            }
        }

      

        //lorsque l'on clique sur "effacer"
        private void effacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Effacer le log", "êtes-vous sûr?", MessageBoxButtons.YesNo);
            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                Log.effacer();
            }
        }

        //lorsque l'on clique sur "consulter"
        private void consulterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.open();
        }

        //lorsque l'on clique sur "ouvrir le repertoire..."
        private void btnCible_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(this.c.getPath());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 
        public void initWaitForm()
        {
            WaitForm wf = new WaitForm();
            wf.ShowDialog();
        }


        //affiche comme date de pricaine sauvegarde la date entrée en paramètre
        public void setLbDateProchaineSauvegarde(DateTime d)
        {
            this.lbDateProchaineSauvegarde1.Text = sauvegarde.GetNextSave().ToShortDateString() + " à " + sauvegarde.GetNextSave().ToShortTimeString();
        }

        //détermine si la sauvegarde est en cours, incomplète ou  terminée
        public void setLbEtatDerniereSauvegarde()
        {
            this.sauvegarde.verifieSiTerminee();
            if (this.sauvegarde.verifieSiTerminee() == '2')
            {
                this.lbEtatSauvegarde.Text = " Terminée.";
                this.lbEtatSauvegarde.ForeColor = Color.Green;
            }
            else
                if (this.sauvegarde.verifieSiTerminee() == '1')
                {
                    this.lbEtatSauvegarde.Text = " En cours.";
                    this.lbEtatSauvegarde.ForeColor = Color.Orange;
                }
                else
                    if (this.sauvegarde.verifieSiTerminee() == '0')
                    {
                        this.lbEtatSauvegarde.Text = "introuvable ou incomplète";
                        this.lbEtatSauvegarde.ForeColor = Color.Red;
                    }
                    else
                        if (this.sauvegarde.verifieSiTerminee() == ' ')
                        {
                            this.lbEtatSauvegarde.Text = "N/A";
                            this.lbEtatSauvegarde.ForeColor = Color.Red;
                        }
        }

        //si la date de la prochaine sauvegarde est antérieure à la date actuelle ou la dernière sauvegarde est introuvable ou incomplete
        


        //déplace le curseur de la souris de 1 pixel toutes les 5min pour empecher la mise en veille
        private void MoveCursor(int i)
        {
            i++;
            if (i == 300)
            {
                if (i % 2 == 0)
                {
                    Cursor.Position = new Point((Cursor.Position.X + 1), Cursor.Position.Y);
                }
                else
                {
                    Cursor.Position = new Point((Cursor.Position.X - 1), Cursor.Position.Y);
                }
                this.j = 0;
            }
        }
    }
}
