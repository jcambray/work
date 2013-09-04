using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clientbackup
{

    public partial class ReportSaveForm : Form
    {
        private MainForm m;
        private int i;
        private DateTime nxts;
        public ReportSaveForm(MainForm mf)
        {
            InitializeComponent();
            //remplissage des valeurs de la déroulante
            this.label2.Text = "Le redémarrage de l'ordinateur est necessaire. Voulez-vous reporter la Sauvegarde ?";
            this.comboBox1.Items.Add("redémarrer maintenant");
            this.comboBox1.Items.Add("10 minutes");
            this.comboBox1.Items.Add("15 minutes");
            this.comboBox1.Items.Add("30 minutes");
            this.comboBox1.Items.Add("1 heure");
            this.comboBox1.Items.Add("2 heures");
            this.comboBox1.SelectedIndex = 0;
            this.m = mf;
            this.nxts = this.m.getNextSave();
            this.lbCAR.Text = "30";
            this.i = 1;
            this.timer1.Start();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //selon le choix de l'utilisateur
            //mise a joue de l'heure et la minute de la prochaine sauvegarde
            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    this.updateNextSave(0,10);
                    break;

                case 2:
                    this.updateNextSave(0,15);
                    break;

                case 3:
                    this.updateNextSave(0,30);
                    break;

                case 4:
                    this.updateNextSave(1,0);
                    break;

                case 5:
                    this.updateNextSave(2,0);
                    break;
            }
            //si l'utilisateur souhaite reporter la sauvegarde
            if (this.comboBox1.SelectedIndex != 0)
            {
                DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 30)
            {
                this.Close();
            }
            else
            {
                this.lbCAR.Text = (30 - i).ToString();
                i++;
            }
        }

        public void updateNextSave(int nbHeure, int nbMinute)
        {
            this.nxts = this.nxts.AddHours(nbHeure).AddMinutes(nbMinute);
        }

        public DateTime getNextSave()
        {
            return this.nxts;
        }
    }
}
