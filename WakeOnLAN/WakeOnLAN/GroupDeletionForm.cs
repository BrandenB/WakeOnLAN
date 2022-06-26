/**
* Author: Branden Brideau
* Date: June 2022
*/

using System.ComponentModel;

using static WakeOnLAN.Enums.DialogMessages;

namespace WakeOnLAN
{
    public partial class GroupDeletionForm : Form
    {
        #region Private properties

        /// <summary>
        /// List of all groups.
        /// </summary>
        private List<string> _groups = new();

        #endregion
        #region Public properties

        /// <summary>
        /// Property to get the computer name.
        /// </summary>
        public string ComputerGroup => this.computerGroup.Text.Trim();

        /// <summary>
        /// Public property to set computer groups.
        /// </summary>
        public List<string> ComputerGroups
        {
            set => _groups = value;
        }

        #endregion

        #region Class constructor.

        /// <summary>
        /// Class constructor.
        /// </summary>
        public GroupDeletionForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form events.

        /// <summary>
        /// Event called when the form loads.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void GroupDeletionForm_Load(object sender, EventArgs e)
        {
            this.computerGroup.Items.AddRange(_groups.ToArray());
            this.computerGroup.Select();
        }

        /// <summary>
        /// Event called when the confirmation checkbox is checked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void confirmationCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            this.suprimerButton.Enabled = this.confirmationCheckbox.Checked;
            this.computerGroup.Select();
        }

        /// <summary>
        /// Event called when validating the group selection.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void computerGroup_Validating(object sender, CancelEventArgs e)
        {
            string trimmedComputerGroup = this.computerGroup.Text.Trim();

            // Clear the errors at each validation.
            errorProvider.Clear();

            // Check computer name.
            if (string.IsNullOrEmpty(trimmedComputerGroup) || string.IsNullOrWhiteSpace(trimmedComputerGroup))
            {
                errorProvider.SetError(this.computerGroup, DialogMessage.ERR_COMPUTER_GROUP_EMPTY.GetMessage());
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Event called when the delete button is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void suprimerButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer le groupe: {this.computerGroup.Text} ? {Environment.NewLine} *** Tous les ordinateurs associés dans ce groupe seront également supprimés! ***", 
                DialogMessage.INFO_TITLE.GetMessage(), 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result is DialogResult.Yes)
            {
                DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        /// <summary>
        /// Event called when the cancel button is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void annulerButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
