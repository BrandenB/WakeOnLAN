namespace WakeOnLAN
{
    partial class GroupDeletionForm
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
            this.annulerButton = new System.Windows.Forms.Button();
            this.suprimerButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.computerGroup = new System.Windows.Forms.ComboBox();
            this.confirmationCheckbox = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // annulerButton
            // 
            this.annulerButton.CausesValidation = false;
            this.annulerButton.Location = new System.Drawing.Point(426, 86);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(95, 33);
            this.annulerButton.TabIndex = 20;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annulerButton_Click);
            // 
            // suprimerButton
            // 
            this.suprimerButton.Enabled = false;
            this.suprimerButton.Location = new System.Drawing.Point(325, 86);
            this.suprimerButton.Name = "suprimerButton";
            this.suprimerButton.Size = new System.Drawing.Size(95, 33);
            this.suprimerButton.TabIndex = 19;
            this.suprimerButton.Text = "Suprimer";
            this.suprimerButton.UseVisualStyleBackColor = true;
            this.suprimerButton.Click += new System.EventHandler(this.suprimerButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nom du groupe";
            // 
            // computerGroup
            // 
            this.computerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.computerGroup.FormattingEnabled = true;
            this.computerGroup.Location = new System.Drawing.Point(110, 27);
            this.computerGroup.Name = "computerGroup";
            this.computerGroup.Size = new System.Drawing.Size(397, 23);
            this.computerGroup.TabIndex = 22;
            this.computerGroup.Validating += new System.ComponentModel.CancelEventHandler(this.computerGroup_Validating);
            // 
            // confirmationCheckbox
            // 
            this.confirmationCheckbox.AutoSize = true;
            this.confirmationCheckbox.Location = new System.Drawing.Point(110, 56);
            this.confirmationCheckbox.Name = "confirmationCheckbox";
            this.confirmationCheckbox.Size = new System.Drawing.Size(97, 19);
            this.confirmationCheckbox.TabIndex = 23;
            this.confirmationCheckbox.Text = "Confirmation";
            this.confirmationCheckbox.UseVisualStyleBackColor = true;
            this.confirmationCheckbox.CheckedChanged += new System.EventHandler(this.confirmationCheckbox_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 150;
            this.errorProvider.ContainerControl = this;
            // 
            // GroupDeletionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 131);
            this.Controls.Add(this.confirmationCheckbox);
            this.Controls.Add(this.computerGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.suprimerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(549, 170);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(549, 170);
            this.Name = "GroupDeletionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Suprimer un groupe";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GroupDeletionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button annulerButton;
        private Button suprimerButton;
        private Label label3;
        private ComboBox computerGroup;
        private CheckBox confirmationCheckbox;
        private ErrorProvider errorProvider;
    }
}