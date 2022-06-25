namespace WakeOnLAN
{
    partial class WakeOnLAN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.formMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnordinateurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUngroupeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.suprimerUnGroupeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.réveillerUnGroupeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.HeaderComputerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderComputerMac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderComputerGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderClasseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderComputerVLAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComputerOtherInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // formMenuStrip
            // 
            this.formMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.actionToolStripMenuItem});
            this.formMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.formMenuStrip.Name = "formMenuStrip";
            this.formMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.formMenuStrip.TabIndex = 0;
            this.formMenuStrip.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnordinateurToolStripMenuItem,
            this.ajouterUngroupeToolStripMenuItem,
            this.toolStripSeparator1,
            this.suprimerUnGroupeToolStripMenuItem,
            this.toolStripSeparator2,
            this.fermerToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // ajouterUnordinateurToolStripMenuItem
            // 
            this.ajouterUnordinateurToolStripMenuItem.Name = "ajouterUnordinateurToolStripMenuItem";
            this.ajouterUnordinateurToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ajouterUnordinateurToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.ajouterUnordinateurToolStripMenuItem.Text = "Ajouter un &ordinateur";
            this.ajouterUnordinateurToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnordinateurToolStripMenuItem_Click);
            // 
            // ajouterUngroupeToolStripMenuItem
            // 
            this.ajouterUngroupeToolStripMenuItem.Name = "ajouterUngroupeToolStripMenuItem";
            this.ajouterUngroupeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.ajouterUngroupeToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.ajouterUngroupeToolStripMenuItem.Text = "Ajouter un &groupe";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // suprimerUnGroupeToolStripMenuItem
            // 
            this.suprimerUnGroupeToolStripMenuItem.Name = "suprimerUnGroupeToolStripMenuItem";
            this.suprimerUnGroupeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.suprimerUnGroupeToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.suprimerUnGroupeToolStripMenuItem.Text = "&Suprimer un groupe";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(228, 6);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.fermerToolStripMenuItem.Text = "&Fermer";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.réveillerUnGroupeToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "&Action";
            // 
            // réveillerUnGroupeToolStripMenuItem
            // 
            this.réveillerUnGroupeToolStripMenuItem.Name = "réveillerUnGroupeToolStripMenuItem";
            this.réveillerUnGroupeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.réveillerUnGroupeToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.réveillerUnGroupeToolStripMenuItem.Text = "&Réveiller un groupe d\'ordinateurs";
            this.réveillerUnGroupeToolStripMenuItem.Click += new System.EventHandler(this.réveillerUnGroupeToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HeaderComputerName,
            this.HeaderComputerMac,
            this.HeaderComputerGroup,
            this.HeaderClasseName,
            this.HeaderComputerVLAN,
            this.ComputerOtherInfo});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(800, 426);
            this.dataGridView.TabIndex = 1;
            // 
            // HeaderComputerName
            // 
            this.HeaderComputerName.HeaderText = "Nom de l\'ordinateur";
            this.HeaderComputerName.Name = "HeaderComputerName";
            this.HeaderComputerName.ReadOnly = true;
            // 
            // HeaderComputerMac
            // 
            this.HeaderComputerMac.HeaderText = "Adresse MAC";
            this.HeaderComputerMac.Name = "HeaderComputerMac";
            this.HeaderComputerMac.ReadOnly = true;
            // 
            // HeaderComputerGroup
            // 
            this.HeaderComputerGroup.HeaderText = "Groupe";
            this.HeaderComputerGroup.Name = "HeaderComputerGroup";
            this.HeaderComputerGroup.ReadOnly = true;
            // 
            // HeaderClasseName
            // 
            this.HeaderClasseName.HeaderText = "Local";
            this.HeaderClasseName.Name = "HeaderClasseName";
            this.HeaderClasseName.ReadOnly = true;
            // 
            // HeaderComputerVLAN
            // 
            this.HeaderComputerVLAN.HeaderText = "VLAN";
            this.HeaderComputerVLAN.Name = "HeaderComputerVLAN";
            this.HeaderComputerVLAN.ReadOnly = true;
            // 
            // ComputerOtherInfo
            // 
            this.ComputerOtherInfo.HeaderText = "Information";
            this.ComputerOtherInfo.Name = "ComputerOtherInfo";
            this.ComputerOtherInfo.ReadOnly = true;
            // 
            // WakeOnLAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.formMenuStrip);
            this.MainMenuStrip = this.formMenuStrip;
            this.Name = "WakeOnLAN";
            this.Text = "WakeOnLAN";
            this.Load += new System.EventHandler(this.WakeOnLAN_Load);
            this.formMenuStrip.ResumeLayout(false);
            this.formMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip formMenuStrip;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem ajouterUnordinateurToolStripMenuItem;
        private ToolStripMenuItem ajouterUngroupeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem suprimerUnGroupeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem fermerToolStripMenuItem;
        private ToolStripMenuItem actionToolStripMenuItem;
        private ToolStripMenuItem réveillerUnGroupeToolStripMenuItem;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn HeaderComputerName;
        private DataGridViewTextBoxColumn HeaderComputerMac;
        private DataGridViewTextBoxColumn HeaderComputerGroup;
        private DataGridViewTextBoxColumn HeaderClasseName;
        private DataGridViewTextBoxColumn HeaderComputerVLAN;
        private DataGridViewTextBoxColumn ComputerOtherInfo;
    }
}