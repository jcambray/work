namespace clientbackup
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.réduireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consulterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbUtilisateur1 = new System.Windows.Forms.Label();
            this.lbDateProchaineSauvegarde = new System.Windows.Forms.Label();
            this.lbDateProchaineSauvegarde1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbEtatSauvegarde = new System.Windows.Forms.Label();
            this.btnCible = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitterToolStripMenuItem,
            this.réduireToolStripMenuItem,
            this.configuraionToolStripMenuItem,
            this.logToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(323, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // réduireToolStripMenuItem
            // 
            this.réduireToolStripMenuItem.Name = "réduireToolStripMenuItem";
            this.réduireToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.réduireToolStripMenuItem.Text = "Réduire";
            this.réduireToolStripMenuItem.Click += new System.EventHandler(this.réduireToolStripMenuItem_Click);
            // 
            // configuraionToolStripMenuItem
            // 
            this.configuraionToolStripMenuItem.Name = "configuraionToolStripMenuItem";
            this.configuraionToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configuraionToolStripMenuItem.Text = "Configuration";
            this.configuraionToolStripMenuItem.Click += new System.EventHandler(this.configuraionToolStripMenuItem_Click);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consulterToolStripMenuItem,
            this.effacerToolStripMenuItem});
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // consulterToolStripMenuItem
            // 
            this.consulterToolStripMenuItem.Name = "consulterToolStripMenuItem";
            this.consulterToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.consulterToolStripMenuItem.Text = "Consulter";
            this.consulterToolStripMenuItem.Click += new System.EventHandler(this.consulterToolStripMenuItem_Click);
            // 
            // effacerToolStripMenuItem
            // 
            this.effacerToolStripMenuItem.Name = "effacerToolStripMenuItem";
            this.effacerToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.effacerToolStripMenuItem.Text = "Effacer";
            this.effacerToolStripMenuItem.Click += new System.EventHandler(this.effacerToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(298, 60);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Faire une sauvegarde";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // myTimer
            // 
            this.myTimer.Enabled = true;
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "sauvegarde automatique";
            this.notifyIcon.BalloonTipTitle = "AUTOMOTOR Backup";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AUTOMOTOR Backup - sauvegarde automatique";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // lbUtilisateur1
            // 
            this.lbUtilisateur1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbUtilisateur1.AutoSize = true;
            this.lbUtilisateur1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUtilisateur1.ForeColor = System.Drawing.Color.White;
            this.lbUtilisateur1.Image = ((System.Drawing.Image)(resources.GetObject("lbUtilisateur1.Image")));
            this.lbUtilisateur1.Location = new System.Drawing.Point(128, 145);
            this.lbUtilisateur1.Name = "lbUtilisateur1";
            this.lbUtilisateur1.Size = new System.Drawing.Size(66, 24);
            this.lbUtilisateur1.TabIndex = 6;
            this.lbUtilisateur1.Text = "label1";
            // 
            // lbDateProchaineSauvegarde
            // 
            this.lbDateProchaineSauvegarde.AutoSize = true;
            this.lbDateProchaineSauvegarde.Image = ((System.Drawing.Image)(resources.GetObject("lbDateProchaineSauvegarde.Image")));
            this.lbDateProchaineSauvegarde.Location = new System.Drawing.Point(9, 212);
            this.lbDateProchaineSauvegarde.Name = "lbDateProchaineSauvegarde";
            this.lbDateProchaineSauvegarde.Size = new System.Drawing.Size(168, 13);
            this.lbDateProchaineSauvegarde.TabIndex = 11;
            this.lbDateProchaineSauvegarde.Text = "Date de la prochaine sauvegarde:";
            // 
            // lbDateProchaineSauvegarde1
            // 
            this.lbDateProchaineSauvegarde1.AutoSize = true;
            this.lbDateProchaineSauvegarde1.Image = ((System.Drawing.Image)(resources.GetObject("lbDateProchaineSauvegarde1.Image")));
            this.lbDateProchaineSauvegarde1.Location = new System.Drawing.Point(179, 213);
            this.lbDateProchaineSauvegarde1.Name = "lbDateProchaineSauvegarde1";
            this.lbDateProchaineSauvegarde1.Size = new System.Drawing.Size(35, 13);
            this.lbDateProchaineSauvegarde1.TabIndex = 12;
            this.lbDateProchaineSauvegarde1.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(9, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Etat de la dernière sauvegarde:";
            // 
            // lbEtatSauvegarde
            // 
            this.lbEtatSauvegarde.AutoSize = true;
            this.lbEtatSauvegarde.Image = ((System.Drawing.Image)(resources.GetObject("lbEtatSauvegarde.Image")));
            this.lbEtatSauvegarde.Location = new System.Drawing.Point(179, 282);
            this.lbEtatSauvegarde.Name = "lbEtatSauvegarde";
            this.lbEtatSauvegarde.Size = new System.Drawing.Size(35, 13);
            this.lbEtatSauvegarde.TabIndex = 14;
            this.lbEtatSauvegarde.Text = "label2";
            // 
            // btnCible
            // 
            this.btnCible.Location = new System.Drawing.Point(54, 360);
            this.btnCible.Name = "btnCible";
            this.btnCible.Size = new System.Drawing.Size(215, 33);
            this.btnCible.TabIndex = 17;
            this.btnCible.Text = "Ouvrir le répertoire de sauvegarde";
            this.btnCible.UseVisualStyleBackColor = true;
            this.btnCible.Click += new System.EventHandler(this.btnCible_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(323, 484);
            this.ControlBox = false;
            this.Controls.Add(this.btnCible);
            this.Controls.Add(this.lbEtatSauvegarde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDateProchaineSauvegarde1);
            this.Controls.Add(this.lbDateProchaineSauvegarde);
            this.Controls.Add(this.lbUtilisateur1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = " ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer myTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem réduireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.Label lbUtilisateur1;
        private System.Windows.Forms.Label lbDateProchaineSauvegarde;
        private System.Windows.Forms.Label lbDateProchaineSauvegarde1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbEtatSauvegarde;
        private System.Windows.Forms.ToolStripMenuItem consulterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effacerToolStripMenuItem;
        private System.Windows.Forms.Button btnCible;
    }
}

