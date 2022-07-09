namespace WakeOnLAN
{
    partial class ComputerInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.computerName = new System.Windows.Forms.TextBox();
            this.computerMac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.computerLocal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.computerGroup = new System.Windows.Forms.ComboBox();
            this.ajouterButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.computerInformation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.computerVLAN = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom de l\'ordinateur";
            // 
            // computerName
            // 
            this.computerName.Location = new System.Drawing.Point(182, 28);
            this.computerName.Name = "computerName";
            this.computerName.PlaceholderText = "CSOR00001";
            this.computerName.Size = new System.Drawing.Size(325, 23);
            this.computerName.TabIndex = 5;
            this.computerName.Validating += new System.ComponentModel.CancelEventHandler(this.computerName_Validating);
            // 
            // computerMac
            // 
            this.computerMac.Location = new System.Drawing.Point(182, 60);
            this.computerMac.Name = "computerMac";
            this.computerMac.PlaceholderText = "AA:BB:CC:DD:EE:FF";
            this.computerMac.Size = new System.Drawing.Size(325, 23);
            this.computerMac.TabIndex = 7;
            this.computerMac.Validating += new System.ComponentModel.CancelEventHandler(this.computerMac_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Adresse MAC de l\'ordinateur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Groupe de l\'ordinateur";
            // 
            // computerLocal
            // 
            this.computerLocal.Location = new System.Drawing.Point(182, 115);
            this.computerLocal.Name = "computerLocal";
            this.computerLocal.PlaceholderText = "SIL-104";
            this.computerLocal.Size = new System.Drawing.Size(325, 23);
            this.computerLocal.TabIndex = 11;
            this.computerLocal.Validating += new System.ComponentModel.CancelEventHandler(this.computerLocal_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Local de l\'ordinateur";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "VLAN de l\'ordinateur";
            // 
            // computerGroup
            // 
            this.computerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.computerGroup.FormattingEnabled = true;
            this.computerGroup.Location = new System.Drawing.Point(182, 89);
            this.computerGroup.Name = "computerGroup";
            this.computerGroup.Size = new System.Drawing.Size(325, 23);
            this.computerGroup.TabIndex = 14;
            this.computerGroup.Validating += new System.ComponentModel.CancelEventHandler(this.computerGroup_Validating);
            // 
            // ajouterButton
            // 
            this.ajouterButton.Location = new System.Drawing.Point(325, 229);
            this.ajouterButton.Name = "ajouterButton";
            this.ajouterButton.Size = new System.Drawing.Size(95, 33);
            this.ajouterButton.TabIndex = 15;
            this.ajouterButton.Text = "Enregistrer";
            this.ajouterButton.UseVisualStyleBackColor = true;
            this.ajouterButton.Click += new System.EventHandler(this.ajouterButton_Click);
            // 
            // annulerButton
            // 
            this.annulerButton.CausesValidation = false;
            this.annulerButton.Location = new System.Drawing.Point(426, 229);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(95, 33);
            this.annulerButton.TabIndex = 16;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annulerButton_Click);
            // 
            // computerInformation
            // 
            this.computerInformation.Location = new System.Drawing.Point(182, 173);
            this.computerInformation.Name = "computerInformation";
            this.computerInformation.PlaceholderText = "Optionnel";
            this.computerInformation.Size = new System.Drawing.Size(325, 23);
            this.computerInformation.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Information extra";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 150;
            this.errorProvider.ContainerControl = this;
            // 
            // computerVLAN
            // 
            this.computerVLAN.Items.AddRange(new object[] {
            "VLAN 35",
            "VLAN 36",
            "VLAN 37",
            "VLAN 38",
            "VLAN 238"});
            this.computerVLAN.Location = new System.Drawing.Point(182, 144);
            this.computerVLAN.Name = "computerVLAN";
            this.computerVLAN.Size = new System.Drawing.Size(325, 23);
            this.computerVLAN.TabIndex = 19;
            this.computerVLAN.Validating += new System.ComponentModel.CancelEventHandler(this.computerVLAN_Validating);
            // 
            // ComputerInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.annulerButton;
            this.ClientSize = new System.Drawing.Size(533, 274);
            this.Controls.Add(this.computerVLAN);
            this.Controls.Add(this.computerInformation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.ajouterButton);
            this.Controls.Add(this.computerGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.computerLocal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.computerMac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.computerName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(549, 313);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(549, 313);
            this.Name = "ComputerInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter/modifier un ordinateur";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ComputerInputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox computerName;
        private TextBox computerMac;
        private Label label2;
        private Label label3;
        private TextBox computerLocal;
        private Label label4;
        private Label label5;
        private ComboBox computerGroup;
        private Button ajouterButton;
        private Button annulerButton;
        private TextBox computerInformation;
        private Label label6;
        private ErrorProvider errorProvider;
        private ComboBox computerVLAN;
    }
}