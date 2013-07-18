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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Intervalle en jours entre deux sauvegardes:";
            // 
            // tbHour
            // 
            this.tbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHour.Location = new System.Drawing.Point(242, 79);
            this.tbHour.Name = "tbHour";
            this.tbHour.Size = new System.Drawing.Size(25, 20);
            this.tbHour.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Heure de la sauvegarde (hh:mm):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Emplacement de la sauvegarde:";
            // 
            // tbPath
            // 
            this.tbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPath.Location = new System.Drawing.Point(242, 115);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(173, 20);
            this.tbPath.TabIndex = 5;
            this.tbPath.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tbPath_MouseMove);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(418, 114);
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
            this.treeview.Location = new System.Drawing.Point(28, 474);
            this.treeview.Name = "treeview";
            this.treeview.Size = new System.Drawing.Size(245, 265);
            this.treeview.TabIndex = 7;
            this.treeview.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeview_AfterCheck);
            this.treeview.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeview_NodeMouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(269, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = ":";
            // 
            // tbMinutes
            // 
            this.tbMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMinutes.Location = new System.Drawing.Point(282, 79);
            this.tbMinutes.Name = "tbMinutes";
            this.tbMinutes.Size = new System.Drawing.Size(26, 20);
            this.tbMinutes.TabIndex = 9;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(499, 200);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètres de sauvegarde";
            // 
            // NUDInterval
            // 
            this.NUDInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDInterval.Location = new System.Drawing.Point(242, 42);
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
            this.label10.Location = new System.Drawing.Point(290, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "jour(s)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(51, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "nombre de sauvegardes à conserver:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(242, 152);
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
            this.lbMDP.Location = new System.Drawing.Point(112, 19);
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
            this.tbConfirmMDP.Location = new System.Drawing.Point(192, 52);
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
            this.lbConfirmMDP.Location = new System.Drawing.Point(52, 55);
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
            this.groupBox2.Location = new System.Drawing.Point(28, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 91);
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
            this.label7.Location = new System.Drawing.Point(156, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Selectionnez les fichiers a sauvegarder:";
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
            this.groupBox3.Location = new System.Drawing.Point(28, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 91);
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
            this.lbConfirmMDPAdmin.Location = new System.Drawing.Point(52, 55);
            this.lbConfirmMDPAdmin.Name = "lbConfirmMDPAdmin";
            this.lbConfirmMDPAdmin.Size = new System.Drawing.Size(134, 13);
            this.lbConfirmMDPAdmin.TabIndex = 17;
            this.lbConfirmMDPAdmin.Text = "Confirmer le  mot de passe:";
            this.lbConfirmMDPAdmin.Visible = false;
            // 
            // tbConfirmMDPAdmin
            // 
            this.tbConfirmMDPAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmMDPAdmin.Location = new System.Drawing.Point(192, 52);
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
            this.lbMDPAdmin.Location = new System.Drawing.Point(112, 21);
            this.lbMDPAdmin.Name = "lbMDPAdmin";
            this.lbMDPAdmin.Size = new System.Drawing.Size(74, 13);
            this.lbMDPAdmin.TabIndex = 14;
            this.lbMDPAdmin.Text = "Mot de passe:";
            this.lbMDPAdmin.Visible = false;
            // 
            // treeViewFichiers
            // 
            this.treeViewFichiers.CheckBoxes = true;
            this.treeViewFichiers.Location = new System.Drawing.Point(279, 474);
            this.treeViewFichiers.Name = "treeViewFichiers";
            this.treeViewFichiers.Size = new System.Drawing.Size(244, 265);
            this.treeViewFichiers.TabIndex = 23;
            this.treeViewFichiers.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFichiers_AfterCheck);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(557, 780);
            this.ControlBox = false;
            this.Controls.Add(this.treeViewFichiers);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}