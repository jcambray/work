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

        public SaveViewer()
        {
            InitializeComponent();
            this.nb = 0;
            this.s = new Save();
            this.backgroundWorker.RunWorkerAsync(s.getNbFichiersCopie());
            this.lbAvancementSauvegarde.Text = "0";
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
            double fichierscopies = s.getNbFichiersCopie();
            double fichiersACopier = s.getNbFichiersACopier();
            this.lbAvancementSauvegarde.Text = fichierscopies.ToString();
            /*if (s.getNbFichiersACopier() > 0)
            {
                int poucentage = Convert.ToInt32(fichierscopies / fichiersACopier * 100);
                this.progressBar.Value = poucentage;
            }*/
        }

        public void calculProgressBarValue()
        {
            if (s.getNbFichiersACopier() != 0)
            {
                this.progressBar.Value = s.getNbFichiersCopie() / s.getNbFichiersACopier();
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker.Dispose();
            backgroundWorker.CancelAsync();
            this.Close();
        }

        private void SaveViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker.Dispose();
            backgroundWorker.CancelAsync();
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
    }
}
