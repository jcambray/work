namespace clientbackup
{
    partial class ConfigForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbHour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.treeview = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMinutes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NUDInterval = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnValider = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbMDP = new System.Windows.Forms.Label();
            this.tbMDP = new System.Windows.Forms.TextBox();
            this.tbConfirmMDP = new System.Windows.Forms.TextBox();
            this.lbConfirmMDP = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModifMDP = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnModifMDPAdmin = new System.Windows.Forms.Button();
            this.lbConfirmMDPAdmin = new System.Windows.Forms.Label();
            this.tbConfirmMDPAdmin = new System.Windows.Forms.TextBox();
            this.tbMDPAdmin = new System.Windows.Forms.TextBox();
            this.lbMDPAdmin = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeViewFichiers = new System.Windows.Forms.TreeView();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbSSL = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSMTP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbMDPFrom = new System.Windows.Forms.TextBox();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Intervalle en jours entre deux sauvegardes:";
            // 
            // tbHour
            // 
            this.tbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHour.Location = new System.Drawing.Point(240, 49);
            this.tbHour.Name = "tbHour";
            this.tbHour.Size = new System.Drawing.Size(25, 20);
            this.tbHour.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(70, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Heure de la sauvegarde (hh:mm):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(77, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Emplacement de la sauvegarde:";
            // 
            // tbPath
            // 
            this.tbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPath.Location = new System.Drawing.Point(240, 77);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(173, 20);
            this.tbPath.TabIndex = 5;
            this.tbPath.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tbPath_MouseMove);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(418, 76);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Parcourir...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // treeview
            // 
            this.treeview.CheckBoxes = true;
            this.treeview.Location = new System.Drawing.Point(28, 367);
            this.treeview.Name = "treeview";
            this.treeview.Size = new System.Drawing.Size(245, 201);
            this.treeview.TabIndex = 7;
            this.treeview.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeview_AfterCheck);
            this.treeview.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeview_NodeMouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(271, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = ":";
            // 
            // tbMinutes
            // 
            this.tbMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMinutes.Location = new System.Drawing.Point(287, 50);
            this.tbMinutes.Name = "tbMinutes";
            this.tbMinutes.Size = new System.Drawing.Size(26, 20);
            this.tbMinutes.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.NUDInterval);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbMinutes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.tbPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbHour);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 143);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètres de sauvegarde";
            // 
            // NUDInterval
            // 
            this.NUDInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDInterval.Location = new System.Drawing.Point(242, 24);
            this.NUDInterval.Name = "NUDInterval";
            this.NUDInterval.Size = new System.Drawing.Size(39, 20);
            this.NUDInterval.TabIndex = 24;
            this.NUDInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(287, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "jour(s)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(53, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "nombre de sauvegardes à conserver:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(240, 104);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnValider
            // 
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(371, 745);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 11;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(452, 745);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Fermer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbMDP
            // 
            this.lbMDP.AutoSize = true;
            this.lbMDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMDP.Image = ((System.Drawing.Image)(resources.GetObject("lbMDP.Image")));
            this.lbMDP.Location = new System.Drawing.Point(112, 20);
            this.lbMDP.Name = "lbMDP";
            this.lbMDP.Size = new System.Drawing.Size(74, 13);
            this.lbMDP.TabIndex = 14;
            this.lbMDP.Text = "Mot de passe:";
            this.lbMDP.Visible = false;
            // 
            // tbMDP
            // 
            this.tbMDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMDP.Location = new System.Drawing.Point(192, 16);
            this.tbMDP.Name = "tbMDP";
            this.tbMDP.PasswordChar = '*';
            this.tbMDP.Size = new System.Drawing.Size(100, 20);
            this.tbMDP.TabIndex = 15;
            this.tbMDP.Visible = false;
            // 
            // tbConfirmMDP
            // 
            this.tbConfirmMDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmMDP.Location = new System.Drawing.Point(192, 42);
            this.tbConfirmMDP.Name = "tbConfirmMDP";
            this.tbConfirmMDP.PasswordChar = '*';
            this.tbConfirmMDP.Size = new System.Drawing.Size(100, 20);
            this.tbConfirmMDP.TabIndex = 16;
            this.tbConfirmMDP.Visible = false;
            // 
            // lbConfirmMDP
            // 
            this.lbConfirmMDP.AutoSize = true;
            this.lbConfirmMDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmMDP.Image = ((System.Drawing.Image)(resources.GetObject("lbConfirmMDP.Image")));
            this.lbConfirmMDP.Location = new System.Drawing.Point(52, 46);
            this.lbConfirmMDP.Name = "lbConfirmMDP";
            this.lbConfirmMDP.Size = new System.Drawing.Size(134, 13);
            this.lbConfirmMDP.TabIndex = 17;
            this.lbConfirmMDP.Text = "Confirmer le  mot de passe:";
            this.lbConfirmMDP.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.btnModifMDP);
            this.groupBox2.Controls.Add(this.lbConfirmMDP);
            this.groupBox2.Controls.Add(this.tbConfirmMDP);
            this.groupBox2.Controls.Add(this.tbMDP);
            this.groupBox2.Controls.Add(this.lbMDP);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 86);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mot de passe utilisateur";
            // 
            // btnModifMDP
            // 
            this.btnModifMDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifMDP.Location = new System.Drawing.Point(316, 16);
            this.btnModifMDP.Name = "btnModifMDP";
            this.btnModifMDP.Size = new System.Drawing.Size(161, 23);
            this.btnModifMDP.TabIndex = 18;
            this.btnModifMDP.Text = "modifier le mot de passe";
            this.btnModifMDP.UseVisualStyleBackColor = true;
            this.btnModifMDP.Click += new System.EventHandler(this.btnModifMDP_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(156, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Selectionner les fichiers à sauvegarder:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 21;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.btnModifMDPAdmin);
            this.groupBox3.Controls.Add(this.lbConfirmMDPAdmin);
            this.groupBox3.Controls.Add(this.tbConfirmMDPAdmin);
            this.groupBox3.Controls.Add(this.tbMDPAdmin);
            this.groupBox3.Controls.Add(this.lbMDPAdmin);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(28, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 86);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mot de passe administrateur";
            // 
            // btnModifMDPAdmin
            // 
            this.btnModifMDPAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifMDPAdmin.Location = new System.Drawing.Point(316, 16);
            this.btnModifMDPAdmin.Name = "btnModifMDPAdmin";
            this.btnModifMDPAdmin.Size = new System.Drawing.Size(161, 23);
            this.btnModifMDPAdmin.TabIndex = 18;
            this.btnModifMDPAdmin.Text = "modifier le mot de passe";
            this.btnModifMDPAdmin.UseVisualStyleBackColor = true;
            this.btnModifMDPAdmin.Click += new System.EventHandler(this.btnModifMDPAdmin_Click);
            // 
            // lbConfirmMDPAdmin
            // 
            this.lbConfirmMDPAdmin.AutoSize = true;
            this.lbConfirmMDPAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmMDPAdmin.Image = ((System.Drawing.Image)(resources.GetObject("lbConfirmMDPAdmin.Image")));
            this.lbConfirmMDPAdmin.Location = new System.Drawing.Point(53, 45);
            this.lbConfirmMDPAdmin.Name = "lbConfirmMDPAdmin";
            this.lbConfirmMDPAdmin.Size = new System.Drawing.Size(134, 13);
            this.lbConfirmMDPAdmin.TabIndex = 17;
            this.lbConfirmMDPAdmin.Text = "Confirmer le  mot de passe:";
            this.lbConfirmMDPAdmin.Visible = false;
            // 
            // tbConfirmMDPAdmin
            // 
            this.tbConfirmMDPAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmMDPAdmin.Location = new System.Drawing.Point(192, 42);
            this.tbConfirmMDPAdmin.Name = "tbConfirmMDPAdmin";
            this.tbConfirmMDPAdmin.PasswordChar = '*';
            this.tbConfirmMDPAdmin.Size = new System.Drawing.Size(100, 20);
            this.tbConfirmMDPAdmin.TabIndex = 16;
            this.tbConfirmMDPAdmin.Visible = false;
            // 
            // tbMDPAdmin
            // 
            this.tbMDPAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMDPAdmin.Location = new System.Drawing.Point(192, 16);
            this.tbMDPAdmin.Name = "tbMDPAdmin";
            this.tbMDPAdmin.PasswordChar = '*';
            this.tbMDPAdmin.Size = new System.Drawing.Size(100, 20);
            this.tbMDPAdmin.TabIndex = 15;
            this.tbMDPAdmin.Visible = false;
            // 
            // lbMDPAdmin
            // 
            this.lbMDPAdmin.AutoSize = true;
            this.lbMDPAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMDPAdmin.Image = ((System.Drawing.Image)(resources.GetObject("lbMDPAdmin.Image")));
            this.lbMDPAdmin.Location = new System.Drawing.Point(112, 19);
            this.lbMDPAdmin.Name = "lbMDPAdmin";
            this.lbMDPAdmin.Size = new System.Drawing.Size(74, 13);
            this.lbMDPAdmin.TabIndex = 14;
            this.lbMDPAdmin.Text = "Mot de passe:";
            this.lbMDPAdmin.Visible = false;
            // 
            // treeViewFichiers
            // 
            this.treeViewFichiers.CheckBoxes = true;
            this.treeViewFichiers.Location = new System.Drawing.Point(279, 367);
            this.treeViewFichiers.Name = "treeViewFichiers";
            this.treeViewFichiers.Size = new System.Drawing.Size(244, 201);
            this.treeViewFichiers.TabIndex = 23;
            this.treeViewFichiers.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFichiers_AfterCheck);
            // 
            // btnActualiser
            // 
            this.btnActualiser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualiser.Location = new System.Drawing.Point(28, 338);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(75, 23);
            this.btnActualiser.TabIndex = 24;
            this.btnActualiser.Text = "actualiser";
            this.btnActualiser.UseVisualStyleBackColor = true;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.cbSSL);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.tbSMTP);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tbTo);
            this.groupBox4.Controls.Add(this.tbPort);
            this.groupBox4.Controls.Add(this.tbMDPFrom);
            this.groupBox4.Controls.Add(this.tbFrom);
            this.groupBox4.Location = new System.Drawing.Point(31, 578);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(489, 162);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Paramètres d\'envoi de mails";
            // 
            // cbSSL
            // 
            this.cbSSL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbSSL.BackgroundImage")));
            this.cbSSL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbSSL.Image = ((System.Drawing.Image)(resources.GetObject("cbSSL.Image")));
            this.cbSSL.Location = new System.Drawing.Point(363, 22);
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Size = new System.Drawing.Size(111, 17);
            this.cbSSL.TabIndex = 10;
            this.cbSSL.Text = "utiliser SSL";
            this.cbSSL.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.Location = new System.Drawing.Point(154, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Port:";
            // 
            // tbSMTP
            // 
            this.tbSMTP.Location = new System.Drawing.Point(189, 70);
            this.tbSMTP.Name = "tbSMTP";
            this.tbSMTP.Size = new System.Drawing.Size(226, 20);
            this.tbSMTP.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Image = ((System.Drawing.Image)(resources.GetObject("label12.Image")));
            this.label12.Location = new System.Drawing.Point(48, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Adresses des destinataires:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(111, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Serveur smtp:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(38, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mot de passe de l\'expediteur:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(64, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Adresse de l\'expéditeur:";
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(189, 123);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(285, 20);
            this.tbTo.TabIndex = 4;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(189, 96);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 3;
            // 
            // tbMDPFrom
            // 
            this.tbMDPFrom.Location = new System.Drawing.Point(189, 45);
            this.tbMDPFrom.Name = "tbMDPFrom";
            this.tbMDPFrom.PasswordChar = '*';
            this.tbMDPFrom.Size = new System.Drawing.Size(100, 20);
            this.tbMDPFrom.TabIndex = 1;
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(189, 19);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(100, 20);
            this.tbFrom.TabIndex = 0;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(557, 780);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnActualiser);
            this.Controls.Add(this.treeViewFichiers);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeview);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(573, 818);
            this.Name = "ConfigForm";
            this.Text = "AUTOMOTOR Backup Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TreeView treeview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMinutes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbMDP;
        private System.Windows.Forms.TextBox tbMDP;
        private System.Windows.Forms.TextBox tbConfirmMDP;
        private System.Windows.Forms.Label lbConfirmMDP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnModifMDP;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown NUDInterval;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnModifMDPAdmin;
        private System.Windows.Forms.Label lbConfirmMDPAdmin;
        private System.Windows.Forms.TextBox tbConfirmMDPAdmin;
        private System.Windows.Forms.TextBox tbMDPAdmin;
        private System.Windows.Forms.Label lbMDPAdmin;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TreeView treeViewFichiers;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbSMTP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbMDPFrom;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.CheckBox cbSSL;
    }
}