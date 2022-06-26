namespace WakeOnLAN
{
    partial class GroupInputForm
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
            this.ajouterButton = new System.Windows.Forms.Button();
            this.computerGroup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.annulerButton.TabIndex = 18;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annulerButton_Click);
            // 
            // ajouterButton
            // 
            this.ajouterButton.Location = new System.Drawing.Point(325, 86);
            this.ajouterButton.Name = "ajouterButton";
            this.ajouterButton.Size = new System.Drawing.Size(95, 33);
            this.ajouterButton.TabIndex = 17;
            this.ajouterButton.Text = "Enregistrer";
            this.ajouterButton.UseVisualStyleBackColor = true;
            this.ajouterButton.Click += new System.EventHandler(this.ajouterButton_Click);
            // 
            // computerGroup
            // 
            this.computerGroup.Location = new System.Drawing.Point(109, 29);
            this.computerGroup.Name = "computerGroup";
            this.computerGroup.PlaceholderText = "SIL-ACAD";
            this.computerGroup.Size = new System.Drawing.Size(393, 23);
            this.computerGroup.TabIndex = 19;
            this.computerGroup.Validating += new System.ComponentModel.CancelEventHandler(this.computerGroup_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Nom du groupe";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 150;
            this.errorProvider.ContainerControl = this;
            // 
            // GroupInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.annulerButton;
            this.ClientSize = new System.Drawing.Size(533, 131);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.computerGroup);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.ajouterButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(549, 170);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(549, 170);
            this.Name = "GroupInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter un groupe";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GroupInputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button annulerButton;
        private Button ajouterButton;
        private TextBox computerGroup;
        private Label label3;
        private ErrorProvider errorProvider;
    }
}