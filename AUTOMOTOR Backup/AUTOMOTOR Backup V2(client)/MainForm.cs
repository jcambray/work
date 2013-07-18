using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace clientbackup
{
    public partial class MainForm : Form
    {
        private bool isAutoLogonEnabled;
        private Configuration c;
        private Save sauvegarde;
        private TimeSpan tempsRestant;
        private DateTime nextSave;
        public Thread configFormThread;
        private int i = 0;

        public MainForm()
        {
            InitializeComponent();
            this.lbProchaineSauvegarde1.Visible = false;
            this.lbCompteARebours.Visible = false;
            this.Text = "AUTOMOTOR Backup v" + Application.ProductVersion;
            this.lbUtilisateur1.Text = Environment.UserName;
            this.minimize();
            this.sauvegarde = new Save();

            //chargement des paramètres de l'application
            //Configuration du Timer
            //Chargement de la date de la derniere sauvegarde
            this.c = new Configuration();
            DateTime lastSave = Serialization.deserializeLastSaveDate(false);
            this.nextSave = initNextSave(lastSave, this.c.getPeriode(), this.c.getHeure(), this.c.getMinute());
            if (Serialization.deserializeLastSaveDate(false).Year == 2000)
            {
                this.lbDateProchaineSauvegarde1.ForeColor = Color.Red;
                this.lbDateProchaineSauvegarde1.Text = "non planifiée";
            }
            else
            {
                this.lbDateProchaineSauvegarde1.Text = this.nextSave.ToShortDateString() + " à " + c.getHeure() + "h" + c.getMinute();
            }
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


        [DllImport("user32.dll")]
        public extern static void ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string pwszReason);

        protected override void WndProc(ref Message m)
        {
            const int WM_QUERYENDSESSION = 0x0011;
            const int WM_ENDSESSION = 0x0016;
            if (m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION)
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
                    Application.Exit();
                }
            }
        }
        #endregion

        #region Lorsque l'utilisateur clique sur le bouton "faire une sauvegarde"
        //Si l'utilisateur accepte le redémarrage de l'ordinateur
        //activation de l'autologon
        //sauvegarde de l'etat de l'autologon à true
        //lancement du redémarrage de l'ordinateur
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La sauvegarde necessite le redemarrage de l'ordinateur, voulez-vous redémarrer maintenant?", " ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                /*RegistryModifier.enableAutoLogon(ConfigurationManager.AppSettings["password"]);
                this.isAutoLogonEnabled = true;
                Serialization.serialize(this.isAutoLogonEnabled);
                Save.restartComputer();*/
                this.initSaveViewer();
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
            if (this.checkSaveConditions())
            {
                this.myTimer.Stop();
                ReportSaveForm rsf = new ReportSaveForm(this);
                DialogResult = rsf.ShowDialog();
                if (DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.nextSave = rsf.getNextSave();
                    this.lbDateProchaineSauvegarde1.Text = this.nextSave.ToShortDateString() + " à " + c.getHeure() + "h" + c.getMinute();
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
        }
        #endregion

        public bool checkSaveConditions()
        {
            DateTime lastSave = Serialization.deserializeLastSaveDate(false);
            //this.nextSave = initNextSave(lastSave, period, heure, minute);
            int heure = Convert.ToInt32(this.c.getHeure());
            int minute = Convert.ToInt32(this.c.getMinute());
            int period = Convert.ToInt32(this.c.getPeriode());
            bool check = false;
            try
            {
                //this.nextSave = initNextSave(lastSave, period, heure, minute);
                this.tempsRestant = this.nextSave - DateTime.Now;
                TimeSpan tempsEcoule = DateTime.Now - lastSave;
                //this.actualiseLbCompteARebours(this.tempsRestant);
                if (this.tempsRestant.Days == 0 && this.tempsRestant.Hours < 15)
                {
                    ShutdownBlockReasonCreate(this.Handle, "Une sauvegarde automatique va être éffectuée à " + c.getHeure() + " h " + c.getMinute() + "." + Environment.NewLine + " Veuillez ne pas éteindre l'ordinateur");
                }
                this.afficheAlerte();
                check = this.verifieSiTempsEstEcoule(tempsRestant);
            }
            catch { }
            return check;
        }

        public void initConfig()
        {
            ConfigForm cf = new ConfigForm(this);
            cf.ShowDialog();
        }

        public void afficheNotification(string message, int duree)
        {
            this.notifyIcon.Visible = true;
            this.notifyIcon.Text = message;
            this.notifyIcon.BalloonTipTitle = message;
            this.notifyIcon.ShowBalloonTip(duree);
        }

        public void minimize()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
        }

        public void maximize()
        {
            this.Visible = true;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void réduireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.minimize();
        }

        public void actualiseLbCompteARebours(TimeSpan t)
        {
            if (Serialization.deserializeLastSaveDate(false).Year == 2000)
            {
                this.lbCompteARebours.Text = "non planifiée";
            }
            else
            {
                this.lbCompteARebours.Text = t.Days + " jours " + t.Hours + " : " + t.Minutes + " : " + t.Seconds;
            }
        }

        public static DateTime initNextSave(DateTime d, int period, int hour, int minute)
        {
            DateTime nextSave = d.AddDays(period).AddHours(-d.Hour + hour).AddMinutes(-d.Minute + minute).AddSeconds(-d.Second);
            return nextSave;
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.maximize();
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

        public void afficheAlerte()
        {
            DateTime lastSave = Serialization.deserializeLastSaveDate(false);
            int heure = Convert.ToInt32(this.c.getHeure());
            int minute = Convert.ToInt32(this.c.getMinute());
            int period = Convert.ToInt32(this.c.getPeriode());
            TimeSpan tempsRestant = this.nextSave - DateTime.Now;

            if (this.tempsRestant.Days == 0 && this.tempsRestant.Hours < 5 && DateTime.Now.Second == 0 && (DateTime.Now.Minute == 0 || DateTime.Now.Minute == 30))
            {
                this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
                this.afficheNotification("jour de sauvegarde ,veuillez ne pas éteindre l'ordinateur", 10000);
            }
            else
            {
                this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            }
        }

        public void initSaveViewer()
        {
            SaveViewer sv = new SaveViewer(this.sauvegarde, this);
            sv.Show();
        }

        /* public bool isOpen(Form frm)
         {
             bool b = false;
             foreach (Form f in Application.OpenForms)
             {
                 if (frm.GetType() == f.GetType())
                 {
                     b = true;
                 }
             }
             return b;
         } */

        public void notifyIcconAlerte(int heure, int minute, string message, int duree)
        {
            if (DateTime.Now.Day == this.nextSave.Day && DateTime.Now.Hour == heure && DateTime.Now.Minute == minute)
            {
                this.afficheNotification(message, duree);
            }
        }

        public TimeSpan getTempsRestant()
        {
            return this.tempsRestant;
        }

        public void setTempsRestant(TimeSpan t)
        {
            this.tempsRestant = t;
        }
        public void ajouteTemps(TimeSpan t)
        {
            this.tempsRestant.Add(t);
        }

        /*public void updateNextSave(int nbHeure, int nbMinute)
        {
            this.nextSave.AddHours(nbHeure).AddMinutes(nbMinute);
            //this.nextSave.AddHours(nbHeure);
            //this.nextSave.AddMinutes(nbMinute);
            MessageBox.Show(nextSave.ToString());
        }*/

        public DateTime getNextSave()
        {
            return this.nextSave;
        }

        private void effacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Effacer le log", "êtes-vous sûr?", MessageBoxButtons.YesNo);
            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                Log.effacer();
            }
        }

        private void consulterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.open();
        }

        private void btnCible_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(this.c.getPath() + @"\" + Environment.UserName);
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

        private void ti_Tick(Object sender, EventArgs e)
        {
            this.i++;
        }
        public void setLbDateProchaineSauvegarde(DateTime d)
        {
            this.lbDateProchaineSauvegarde1.Text = d.ToShortDateString() + " à " + this.c.getHeure() + "h" + this.c.getMinute();
        }

        public void setLbEtatDerniereSauvegarde()
        {
            this.sauvegarde.verifieSiTerminee();
            //DateTime dt = Serialization.deserializeLastSaveDate(false);
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
    }
}
