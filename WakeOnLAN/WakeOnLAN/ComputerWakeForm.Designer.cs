namespace WakeOnLAN
{
    partial class ComputerWakeForm
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
            this.wakeUpButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.computerGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // wakeUpButton
            // 
            this.wakeUpButton.Location = new System.Drawing.Point(325, 173);
            this.wakeUpButton.Name = "wakeUpButton";
            this.wakeUpButton.Size = new System.Drawing.Size(95, 33);
            this.wakeUpButton.TabIndex = 16;
            this.wakeUpButton.Text = "Réveiller";
            this.wakeUpButton.UseVisualStyleBackColor = true;
            this.wakeUpButton.Click += new System.EventHandler(this.wakeUpButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.Location = new System.Drawing.Point(426, 173);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 33);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // computerGroup
            // 
            this.computerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.computerGroup.FormattingEnabled = true;
            this.computerGroup.Location = new System.Drawing.Point(185, 30);
            this.computerGroup.Name = "computerGroup";
            this.computerGroup.Size = new System.Drawing.Size(321, 23);
            this.computerGroup.TabIndex = 19;
            this.computerGroup.Validating += new System.ComponentModel.CancelEventHandler(this.computerGroup_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Groupe d\'ordinateur à réveiller";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 87);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(509, 33);
            this.progressBar.TabIndex = 20;
            // 
            // progressLabel
            // 
            this.progressLabel.Location = new System.Drawing.Point(421, 123);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(100, 23);
            this.progressLabel.TabIndex = 21;
            this.progressLabel.Text = "0/0 réveiller";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 150;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // ComputerWakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(533, 218);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.computerGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.wakeUpButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(549, 257);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(549, 257);
            this.Name = "ComputerWakeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Réveiller un groupe d\'ordinateurs";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ComputerWakeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button wakeUpButton;
        private Button cancelButton;
        private ComboBox computerGroup;
        private Label label3;
        private ProgressBar progressBar;
        private Label progressLabel;
        private ErrorProvider errorProvider;
    }
}