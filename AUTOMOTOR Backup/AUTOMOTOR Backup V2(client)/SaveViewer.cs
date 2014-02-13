using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace clientbackup
{
    public partial class SaveViewer : Form
    {

        private Save s;
        private double nb;
        private MainForm mainform;

        public SaveViewer(Save save, MainForm mf)
        {
            InitializeComponent();
            this.nb = 0;
            this.s = save;
            save.setBgwk(this.backgroundWorker);
            this.backgroundWorker.RunWorkerAsync(s.getInfosCopie());
            this.lbAvancementSauvegarde.Text = "0";
            this.mainform = mf;
        }
        
     

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Lancement de la sauvegarde
            this.s.execute(this.backgroundWorker);
        }

        //Informations sur la progression de la sauvegarde
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {   
            string fichierscopies = s.getInfosCopie()[0];
            this.lbAvancementSauvegarde.Text = fichierscopies;
            this.lbNomFichier.Text = s.getInfosCopie()[1];
        }

          
        //Lorsque la sauvegarde est terminée
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker.Dispose();
            backgroundWorker.CancelAsync();

            mainform.setLbEtatDerniereSauvegarde();
            DateTime lastSave = Serialization.deserializeLastSaveDate(false);
            Configuration c = new Configuration();

            //reinitialisation de la date de la prochaine sauvegarde
            DateTime d = s.initNextSave();
            Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " Réinitialisation de la date de la prochaine sauvegarde, nouvelle valeur: " + d.ToString());
            this.mainform.setLbDateProchaineSauvegarde(d);
            
            //suppression des anciennes sauvegardes
            if (c.getNbSaves() != 0)
            {
                s.checkSaveNumber();
            }

            //Création et envoi du mail de fin de sauvegarde
            Mailer m = new Mailer(this.s);
            m.sendNotificationSauvegarde();
            s.setNbFichiersCopies(0);

            if (c.getAutoShutDown() == '1')
            {
                //Arret de l'ordinateur
                System.Diagnostics.ProcessStartInfo restart = new System.Diagnostics.ProcessStartInfo("shutdown.exe", "-s -t 60");
                System.Diagnostics.Process.Start(restart);
            }
            else
            {
                MessageBox.Show("Sauvegarde terminée.");
                Log.write("- " + DateTime.Now.ToShortDateString() + " à " + DateTime.Now.ToShortTimeString() + " Sauvegarde terminée");
                Application.Restart();
            }
            Close();
        }

        //lors de la fermeture du formulaire
        private void SaveViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //"destruction" du backgroundworker
            backgroundWorker.CancelAsync();
            this.s.setBgwk(null);
            backgroundWorker.Dispose();
       }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value == 100)
            {
                this.progressBar.Value = 0;
                this.nb = 0;
            }
            else
            {
                this.nb += 25;
                this.progressBar.Value = (int)this.nb;
            }
        }

        public  BackgroundWorker getBGW()
        {
            return this.backgroundWorker;
        }
    }
}
