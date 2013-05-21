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
    public partial class MDPAdminControl : Form
    {
        private string mdp;
        private bool ok = false;

        public MDPAdminControl()
        {
            InitializeComponent();
           this.mdp = Serialization.deserializeMDPAdmin();
           if (this.mdp == null)
           {
               MessageBox.Show("mot de passe administrateur introuvable.Veuillez en enregistrer un");
               ConfigForm cf = new ConfigForm();
               cf.Show();
           }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.checkMDP();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public bool getOK()
        {
            return this.ok;
        }

        public void checkMDP()
        {
            this.ok = Security.compareToMd5(this.tbMDP.Text,this.mdp);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
