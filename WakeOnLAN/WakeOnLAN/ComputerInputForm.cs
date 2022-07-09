/**
* Author: Branden Brideau
* Date: June 2022
*/

using System.Text.RegularExpressions;

using static WakeOnLAN.Enums.DialogMessages;

namespace WakeOnLAN
{
    public partial class ComputerInputForm : Form
    {
        #region Private properties

        /// <summary>
        /// List of all computer groups.
        /// </summary>
        private List<string> _computerGroups = new();

        /// <summary>
        /// Regex for mac address validation.
        /// </summary>
        private readonly Regex _macAddressRegex = new Regex("^([0-9A-Fa-f]{2}[:]){5}([0-9A-Fa-f]{2})$");

        /// <summary>
        /// Regex for prohibited XML chars to be used,
        /// </summary>
        private readonly string _escapeSpecialChars = "(<|>|\"|)";

        /// <summary>
        /// Computer group.
        /// </summary>
        private string _computerGroup = string.Empty;

        #endregion

        #region Public properties

        /// <summary>
        /// Public property that passes the name of the computer to the main form.
        /// </summary>
        public string ComputerName
        {
            get => Regex.Replace(this.computerName.Text.Trim().ToUpper(), _escapeSpecialChars, "");
            set => this.computerName.Text = value;
        }

        /// <summary>
        /// Public property that passes the MAC of the computer to the main form.
        /// </summary>
        public string ComputerMac
        {
            get => this.computerMac.Text.Trim().ToUpper();
            set => this.computerMac.Text = value;
        }

        /// <summary>
        /// Public property that passes the group of the computer to the main form.
        /// </summary>
        public string ComputerGroup
        {
            get => this.computerGroup.Text.Trim();
            set => this._computerGroup = value;
        }

        /// <summary>
        /// Public property that passes the local of the computer to the main form.
        /// </summary>
        public string ComputerLocal
        {
            get => Regex.Replace(this.computerLocal.Text.Trim(), _escapeSpecialChars, "");
            set => this.computerLocal.Text = value;
        }

        /// <summary>
        /// Public property that passes the VLAN of the computer to the main form.
        /// </summary>
        public string ComputerVlan
        {
            get => Regex.Replace(this.computerVLAN.Text.Trim(), _escapeSpecialChars, "");
            set => this.computerVLAN.Text = value;
        }

        /// <summary>
        /// Public property that passes the information of the computer to the main form.
        /// </summary>
        public string ComputerInformation
        {
            get => Regex.Replace(this.computerInformation.Text.Trim(), _escapeSpecialChars, "");
            set => this.computerInformation.Text = value;
        }

        /// <summary>
        /// Public property to set the available computer groups.
        /// </summary>
        public List<string> ComputerGroups
        {
            set
            {
                _computerGroups = value;
            }
        }

        #endregion

        #region Class constructor.

        /// <summary>
        /// Class constructor.
        /// </summary>
        public ComputerInputForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form events

        /// <summary>
        /// Event called when the form loads.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ComputerInputForm_Load(object sender, EventArgs e)
        {
            this.computerGroup.Items.AddRange(_computerGroups.ToArray());
            this.computerGroup.Text = _computerGroup;
        }

        /// <summary>
        /// Event called when the add computer button is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ajouterButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                this.DialogResult = DialogResult.Yes;
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Validation event for the computer name.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void computerName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string trimmedComputerName = this.computerName.Text.Trim();

            // Clear the errors at each validation.
            errorProvider.Clear();

            // Check computer name.
            if (string.IsNullOrEmpty(trimmedComputerName) || string.IsNullOrWhiteSpace(trimmedComputerName))
            {
                errorProvider.SetError(this.computerName, DialogMessage.ERR_COMPUTER_NAME_EMPTY.GetMessage());
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Validation event for the mac address.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void computerMac_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string trimmedMacAddress = this.computerMac.Text.Trim();

            // Clear the errors at each validation.
            errorProvider.Clear();

            // Check mac address.
            if (string.IsNullOrEmpty(trimmedMacAddress) || string.IsNullOrWhiteSpace(trimmedMacAddress))
            {
                errorProvider.SetError(this.computerMac, DialogMessage.ERR_MAC_ADDRESS_EMPTY.GetMessage());
                e.Cancel = true;
            } else

            // Validate mac address.
            if (!_macAddressRegex.IsMatch(trimmedMacAddress))
            {
                errorProvider.SetError(this.computerMac, DialogMessage.ERR_MAC_ADDRESS_INVALID.GetMessage());
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Validation event for computer group.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void computerGroup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string groupName = this.computerGroup.Text;

            // Clear the errors at each validation.
            errorProvider.Clear();

            // Check group
            if (string.IsNullOrEmpty(groupName))
            {
                errorProvider.SetError(this.computerGroup, DialogMessage.ERR_GROUP_NOT_SELECTED.GetMessage());
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Validation event for computer local.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void computerLocal_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string trimmedComputerLocal = this.computerLocal.Text.Trim();

            // Clear the errors at each validation.
            errorProvider.Clear();

            // Check computer local.
            if (string.IsNullOrEmpty(trimmedComputerLocal) || string.IsNullOrWhiteSpace(trimmedComputerLocal))
            {
                errorProvider.SetError(this.computerLocal, DialogMessage.ERR_LOCAL_EMPTY.GetMessage());
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Validation event for computer VLAN.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void computerVLAN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string trimmedComputerVLAN = this.computerVLAN.Text.Trim();

            // Clear the errors at each validation.
            errorProvider.Clear();

            // Check computer local.
            if (string.IsNullOrEmpty(trimmedComputerVLAN) || string.IsNullOrWhiteSpace(trimmedComputerVLAN))
            {
                errorProvider.SetError(this.computerVLAN, DialogMessage.ERR_VLAN_EMPTY.GetMessage());
                e.Cancel = true;
            }
        }

        #endregion

    }
}
