using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
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
            this.configureTimer();
            this.nextSave = c.getNextSaveDate();

            //Appel de la fonction permettant le bloquage d'arrets Windows
            ShutdownBlockReasonCreate(this.Handle, "Une sauvegarde automatique va être éffectuée.");

            //chargement de la valeur booléenne indiquant si l'autoLogon est activé en base de registre
            //Si l'AutoLogon est activé en base de registre Windows
            //Désactivation de l'autoLogon en base de registre Windows
            // mise à jour et sauvegarde de la valeur booléenne
            // suppression de la sauvegarde la plus ancienne si le nombre maxi de sauvegarde sera dépassé
            //lancement de la sauvegarde
            this.isAutoLogonEnabled = (bool)Serialization.deserialize();
            if (this.isAutoLogonEnabled == true)
            {
                RegistryModifier.disableAutoLogon();
                this.isAutoLogonEnabled = false;
                Serialization.serialize(this.isAutoLogonEnabled);
                this.sauvegarde.checkSaveNumber();
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
            MDPAdminControl MDPAC = new MDPAdminControl();
            DialogResult result = MDPAC.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (MDPAC.getOK())
                {
                    ConfigForm cf = new ConfigForm();
                    cf.ShowDialog();
                }
                else
                {
                    MessageBox.Show("mot de passe incorrect");
                }
            }
        }
        #endregion

        #region fermeture de l'application après vérification du MDP administrateur
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDPAdminControl MDPAC = new MDPAdminControl();
            DialogResult result = MDPAC.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (MDPAC.getOK())
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("mot de passe incorrect");
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
            this.sauvegarde.checkSaveNumber();
            this.initSaveViewer();
            /*if (MessageBox.Show("La sauvegarde necessite le redemarrage de l'ordinateur, voulez-vous redémarrer maintenant?", " ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RegistryModifier.enableAutoLogon(ConfigurationManager.AppSettings["password"]);
                this.isAutoLogonEnabled = true;
                Serialization.serialize(this.isAutoLogonEnabled);
                Save.restartComputer();
            }*/
            
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
            this.sauvegarde.verifieSiTerminee();
            DateTime dt = Serialization.deserializeLastSaveDate(false);
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
                    if(this.sauvegarde.verifieSiTerminee() == '0')
                        {
                            this.lbEtatSauvegarde.Text = " Incomplète.";
                            this.lbEtatSauvegarde.ForeColor = Color.Red;
                        }
                    else
                        if (this.sauvegarde.verifieSiTerminee() == ' ')
                        {
                            this.lbEtatSauvegarde.Text = "N/A";
                            this.lbEtatSauvegarde.ForeColor = Color.Red;
                        }

            if (this.checkSaveConditions())
            {
                this.myTimer.Stop();
                ReportSaveForm rsf = new ReportSaveForm(this);
                DialogResult = rsf.ShowDialog();
                if (DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.nextSave = rsf.getNextSave();
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
            bool check = false;
            this.c = new Configuration();
            int heure = Convert.ToInt32(c.getHeure());
            int minute = Convert.ToInt32(c.getMinute());
            int period = Convert.ToInt32(c.getPeriode());
            try
            {
                //initNextSave(lastSave, period, heure, minute);
                //this.nextSave = c.getNextSaveDate();
                this.tempsRestant = this.nextSave - DateTime.Now;
                TimeSpan tempsEcoule = DateTime.Now - lastSave;
                if (Serialization.deserializeLastSaveDate(false).Year == 2000)
                {
                    this.lbDateProchaineSauvegarde1.ForeColor = Color.Red;
                    this.lbDateProchaineSauvegarde1.Text = "non planifiée";
                }
                else
                {
                    this.lbDateProchaineSauvegarde1.Text = this.nextSave.ToShortDateString() + " à " + c.getHeure() + "h" + c.getMinute();
                }
                this.actualiseLbCompteARebours(this.tempsRestant);
                if (this.tempsRestant.Days == 0 && this.tempsRestant.Hours < 15)
                {
                    ShutdownBlockReasonCreate(this.Handle, "Une sauvegarde automatique va être éffectuée à " + c.getHeure() + " h " + c.getMinute() + "." + Environment.NewLine + " Veuillez ne pas éteindre l'ordinateur");
                }
                this.afficheAlerte();
                if (this.verifieSiTempsEstEcoule(tempsRestant))
                {
                    check = true;
                }
            }
            catch{ }
            return check;
        }

        public void initConfig()
        {
            ConfigForm cf = new ConfigForm();
            cf.Show();
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
            this.ShowInTaskbar = true;
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
            /*if (t.Days >= nbJour && DateTime.Now.Hour == nbHeure && DateTime.Now.Minute == nbMinute)
            {
                ok = true;
            }*/
            return ok;
        }

        public void afficheAlerte()
        {
            DateTime lastSave = Serialization.deserializeLastSaveDate(false);
            this.c = new Configuration();
            int heure = Convert.ToInt32(c.getHeure());
            int minute = Convert.ToInt32(c.getMinute());
            int period = Convert.ToInt32(c.getPeriode());
            DateTime nextSave = initNextSave(lastSave, period, heure, minute);
            TimeSpan tempsRestant = nextSave - DateTime.Now;

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
            SaveViewer sv = new SaveViewer(this.sauvegarde);
            sv.Show();
        }

        public bool isOpen(Form frm)
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
        }

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
           DialogResult r =  MessageBox.Show("Effacer le log","êtes-vous sûr?",MessageBoxButtons.YesNo);
           if (r == System.Windows.Forms.DialogResult.Yes)
           {
               Log.effacer();
           }
        }

        private void consulterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.open();
        }
    }
}
