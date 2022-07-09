/**
* Author: Branden Brideau
* Date: June 2022
*/

using System.ComponentModel;
using System.Text.RegularExpressions;

using static WakeOnLAN.Enums.DialogMessages;

namespace WakeOnLAN
{
    public partial class GroupInputForm : Form
    {
        #region Public properties

        /// <summary>
        /// Property that gets the computer group.
        /// </summary>
        public string ComputerGroup => Regex.Replace(this.computerGroup.Text.Trim(), "([^a-zA-Z0-9-]+)", "");

        #endregion

        #region Class constructor

        /// <summary>
        /// Class constructor.
        /// </summary>
        public GroupInputForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form events 

        /// <summary>
        /// Method called when the form loads.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void GroupInputForm_Load(object sender, EventArgs e)
        {
            this.computerGroup.Select();
        }

        /// <summary>
        /// Event called when validating group name.
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
        /// Method called when we click the save button.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ajouterButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// Method called when the click the cancel button.
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
