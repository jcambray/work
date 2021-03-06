﻿using System;
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

        public MDPAdminControl(string password)
        {
            InitializeComponent();
            this.mdp = password;
            this.ActiveControl = this.tbMDP;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.checkMDP();
            if (this.ok)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                if (!this.ok)
                {
                    MessageBox.Show("Mot de passe incorrect");
                    this.Close();
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                }
        }

        public bool getOK()
        {
            return this.ok;
        }

        public void checkMDP()
        {
            Security secure = new Security();
            //this.ok = Security.compareToMd5(this.tbMDP.Text,this.mdp);
            this.ok = this.mdp.Equals(secure.toCaesar(this.tbMDP.Text , 15));
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
