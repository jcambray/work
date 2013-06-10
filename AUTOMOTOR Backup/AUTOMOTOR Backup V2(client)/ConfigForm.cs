using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace clientbackup
{
    public partial class ConfigForm : Form
    {
        private bool btnModifMDPClicked = false;
        private bool btnModifMDPAdminClicked = false;
        private ArrayList files;
        private string ancienInterval;

        public ConfigForm()
        {
            InitializeComponent();
            /*if (this.c != null)
            {
                this.c = Serialization.deserializeConfig();
                this.checkSelectedFiles(this.treeview.Nodes[0], filesList);
                this.tbPeriod.Text = c.getNbJours().ToString();
                this.tbHour.Text = c.getHeure().ToString();
                this.tbMinutes.Text = c.getMinute().ToString();
                this.tbPath.Text = c.getPath();
                this.tbMDP.Text = c.getPassword().ToString();
                this.numericUpDown1.Value = c.getNbSaves();
            }*/
            this.files = Serialization.deserializeXML();
            ImageList imgList = new ImageList();
            this.treeview.ImageList = imgList;
            imgList.Images.Add(System.Drawing.Image.FromFile(Environment.CurrentDirectory + @"/Data/dossier_windows.png"));
            this.populatetreeView();
            

            this.NUDInterval.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["period"]);
            this.tbHour.Text = ConfigurationManager.AppSettings["heure"];
            this.tbMinutes.Text = ConfigurationManager.AppSettings["minute"];
            this.tbPath.Text = ConfigurationManager.AppSettings["path"];
            this.tbMDP.Text = ConfigurationManager.AppSettings["password"];
            this.tbMDPAdmin.Text = ConfigurationManager.AppSettings["passwordAdmin"];
            this.numericUpDown1.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["nbSaves"]);
            this.ancienInterval = this.NUDInterval.Value.ToString();

            this.toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            //this.toolTip1.ToolTipTitle = "Le repertoire de sauvegarde ne peut pas être sauvegarder";
           
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.tbPath.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        public void populatetreeView()
        {
            if (this.treeview.Nodes.Count > 0)
            {
                this.treeview.Nodes.Clear();
            }
            DirectoryInfo directory = new DirectoryInfo(@"\\" + Environment.UserDomainName + @"\C$\Users");
            TreeNode node = new TreeNode(directory.Name);
            this.treeview.Nodes.Add(node);
            this.recursiveDirSearch(node, directory.FullName);
            this.checkSelectedFiles(this.treeview.Nodes[0]);
            this.checkParentnodes(node);
        }

        public void recursiveDirSearch(TreeNode parentNode, string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                this.fileSearch(parentNode, directory);
                if ((directory.Attributes) != FileAttributes.System)
                {
                    foreach (DirectoryInfo dir in directory.GetDirectories())
                    {
                        if ((dir.Attributes & FileAttributes.System) != FileAttributes.System)
                        {
                            TreeNode childNode = new TreeNode(dir.Name);
                            if(this.isDirectory(dir.FullName))
                            {
                                childNode.ImageIndex = 0;
                            }
                            childNode.Checked = parentNode.Checked;
                            parentNode.Nodes.Add(childNode);
                            this.recursiveDirSearch(childNode, dir.FullName);
                        }
                    }
                }
            }
            catch
            {
                parentNode.Nodes.Add(new TreeNode("acces refuse"));
            }
        }

        public void fileSearch(TreeNode parentNode, DirectoryInfo directory)
        {
            try
            {
                foreach (FileInfo f in directory.GetFiles())
                {
                    if ((f.Attributes & FileAttributes.System) != FileAttributes.System)
                    {
                        TreeNode childNode = new TreeNode(f.Name);
                        childNode.Checked = parentNode.Checked;
                        parentNode.Nodes.Add(childNode);
                        
                    }
                }
            }
            catch (Exception)
            {
                parentNode.Nodes.Add(new TreeNode("acces refuse"));
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        { 
            ArrayList pathesList = new ArrayList();
            this.recursiveNodeSearch(this.treeview.Nodes[0], pathesList);
            try
            {
                Serialization.serializeToXML(pathesList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (this.checkConfig())
            {
                try
                {
                    Directory.CreateDirectory(this.tbPath.Text + @"/test");
                    Directory.Delete(this.tbPath.Text + @"/test");
                    this.saveConfig();
                    Application.Restart();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                /*DateTime lastSave = Serialization.deserializeLastSaveDate();
                int period = Convert.ToInt32(ConfigurationManager.AppSettings["period"]);
                DateTime nextSaveAncienInterval = lastSave.AddDays(Convert.ToInt32(ancienInterval));
                DateTime nextSave = lastSave.AddDays(period);
                TimeSpan tempsRestant = nextSave - DateTime.Now;
                TimeSpan tempsRestantAncienInterval = nextSave - DateTime.Now;*/
            }
        }

        public bool isDirectory(string path)
        {
            FileInfo f = new FileInfo(path);
            return f.Attributes == FileAttributes.Directory;
        } 

        public ArrayList recursiveNodeSearch(TreeNode parentNode, ArrayList list)
        {
            foreach (TreeNode n in parentNode.Nodes)
            {
                if (n.Checked)
                {
                    list.Add(n.FullPath);    
                }
                this.recursiveNodeSearch(n,list);
            }
            return list;
        }

        public void saveConfig()
        {
            //ouverture du fichier de configuration
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //sauvegarde de l'heure de la sauvegarde
            //sauvegarde de la minute de la sauvegarde
            //sauvegarde du chemin du repertoire de destination de la sauvegarde
            //sauvegarde de l'intervalle en jours entre 2 sauvegardes
            config.AppSettings.Settings.Remove("heure");
            config.AppSettings.Settings.Add("heure", this.tbHour.Text);
            config.AppSettings.Settings.Remove("minute");
            config.AppSettings.Settings.Add("minute", this.tbMinutes.Text);
            config.AppSettings.Settings.Remove("path");
            config.AppSettings.Settings.Add("path", this.tbPath.Text);
            config.AppSettings.Settings.Remove("period");
            config.AppSettings.Settings.Add("period", this.NUDInterval.Value.ToString());
            //si la zone de texte permettant de changer le mot de passe est visible
            //sauvegarde du mot de passe
            if (this.tbConfirmMDP.Visible == true)
            {
                config.AppSettings.Settings.Remove("password");
                config.AppSettings.Settings.Add("password",this.tbMDP.Text);
            }
            //si la zone de texte permettant de changer le mot de passe administrateur est visible
            //sauvegarde du mot de passe administrateur
            if (this.tbConfirmMDPAdmin.Visible == true)
            {
                config.AppSettings.Settings.Remove("passwordAdmin");
                config.AppSettings.Settings.Add("passwordAdmin", this.tbMDPAdmin.Text);
                Serialization.serializeMDPAdmin(Security.toMd5(this.tbMDPAdmin.Text));
            }
            //sauvegarde du nombre de sauvegardes à conserver
            config.AppSettings.Settings.Remove("nbSaves");
            config.AppSettings.Settings.Add("nbSaves", this.numericUpDown1.Value.ToString());
            ConfigurationManager.RefreshSection("appSettings");
            config.Save(ConfigurationSaveMode.Modified);
            Configuration conf = new Configuration();
            DateTime lastSave = Serialization.deserializeLastSaveDate(true);
            //Sauvegarde le la date de la prochaine sauvegarde
            DateTime nextSaveDate = MainForm.initNextSave(/*lastSave*/DateTime.Now, conf.getPeriode(), conf.getHeure(), conf.getMinute());
            config.AppSettings.Settings.Remove("nextSave");
            config.AppSettings.Settings.Add("nextSave", nextSaveDate.ToString());
            ConfigurationManager.RefreshSection("appSettings");
            //sauvegarde des modifications apportées au fichier de configuration
            config.Save(ConfigurationSaveMode.Modified); 
        }

        #region verification de la validité des paramètres entrés par l'utilisateur
        public bool checkConfig()
        {
            bool check = true;
            if (this.tbHour.Text == string.Empty || this.tbMDP.Text == string.Empty || this.tbMinutes.Text == string.Empty || this.tbPath.Text == string.Empty || this.NUDInterval.Value.ToString() == string.Empty)
            {
                MessageBox.Show("tous les champs doivent être renseignés.");
                check = false;
            }
            else
                if (this.btnModifMDPClicked)
                {
                    if (this.tbMDP.Text != this.tbConfirmMDP.Text)
                    {
                        MessageBox.Show("Les mots de passe sont différents");
                        check = false;
                    }
                }
                
                    if (this.btnModifMDPAdminClicked)
                    {
                        if (this.tbMDPAdmin.Text != this.tbConfirmMDPAdmin.Text)
                        {
                            MessageBox.Show("Les mots de passe administrateur sont différents");
                            check = false;
                        }
                    }
                
            return check;
        }
        #endregion

        #region lorsque l'on cli que sur le bouton "annuler"
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region re-coche les noeuds correspondant aux dossiers selectionnés
        public void checkSelectedFiles(TreeNode parentNode)
        {
            try
            {
                foreach (TreeNode n in parentNode.Nodes)
                {
                    foreach (string s in this.files)
                        if (n.FullPath == s)
                        {
                            n.Checked = true;
                        }
                    this.checkSelectedFiles(n);
                }
            }
            catch (NullReferenceException){ }
            catch (ArgumentNullException){ }
        }
        #endregion

        private void btnModifierEmpFichiers_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Add("empFichierConfig", this.saveFileDialog1.FileName);
                ConfigurationManager.RefreshSection("appSettings");
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        public bool getBtnModifMDPClicked()
        {
            return this.btnModifMDPClicked;
        }

        #region lorsque l'utilisateur clique sur le bouton de modification du mot de passe
        private void btnModifMDP_Click(object sender, EventArgs e)
        {
            this.tbConfirmMDP.Visible = true;
            this.lbMDP.Visible = true;
            this.lbConfirmMDP.Visible = true;
            this.tbMDP.Visible = true;
            this.btnModifMDPClicked = true;
        }
        #endregion

        public void checkParentnodes(TreeNode node)
        {
            if (node.Checked)
            {
                foreach (TreeNode parent in node.Parent.Nodes)
                {
                    parent.Checked = true;
                }
            }
        }

        private void btnModifMDPAdmin_Click(object sender, EventArgs e)
        {
            this.tbConfirmMDPAdmin.Visible = true;
            this.lbMDPAdmin.Visible = true;
            this.lbConfirmMDPAdmin.Visible = true;
            this.tbMDPAdmin.Visible = true;
            this.btnModifMDPAdminClicked = true;
        }

        private void tbPath_MouseMove(object sender, MouseEventArgs e)
        {
            this.toolTip1.SetToolTip(this.btnBrowse, "Veillez à ce que le repertoire de sauvegarde ne soit pas selectionné");
            this.toolTip1.ToolTipTitle = "Le repertoire de sauvegarde ne peut pas être sauvegarder";


        }

        public void actualiseSelectedNodes(TreeNode parent)
        {
            foreach (TreeNode node in parent.Nodes)
            {
                if (node.Checked)
                {
                    node.ForeColor = System.Drawing.Color.Green;
                    foreach (TreeNode n in node.Nodes)
                    {
                        n.Checked = true;
                    }
                }
                this.actualiseSelectedNodes(node);
            }


        }

        private void treeview_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //this.actualiseSelectedNodes(this.treeview.Nodes[0]);
        }
    }

}
