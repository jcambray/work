using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        
        public void ProgressBarProgress()
        {
            this.progressBar.PerformStep();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.s.execute(this.backgroundWorker);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string fichierscopies = s.getInfosCopie()[0];
            this.lbAvancementSauvegarde.Text = fichierscopies;
            this.lbNomFichier.Text = s.getInfosCopie()[1];
        }

   
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker.Dispose();
            backgroundWorker.CancelAsync();
            this.Close();
            mainform.setLbEtatDerniereSauvegarde();
            DateTime lastSave = Serialization.deserializeLastSaveDate(false);
            Configuration c = new Configuration();
            DateTime d = MainForm.initNextSave(lastSave, c.getPeriode(), c.getHeure(), c.getMinute());
            this.mainform.setLbDateProchaineSauvegarde(d);
            s.checkSaveNumber();
            Mailer m = new Mailer(this.s);
            m.sendNotificationSauvegarde();
            s.setNbFichiersCopies(0);
            MessageBox.Show("sauvegarde terminée.");
            this.s.setBgwk(null);
        }

        private void SaveViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
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
