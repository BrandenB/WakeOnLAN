/**
* Author: Branden Brideau
* Date: June 2022
*/

using System.ComponentModel;
using System.Xml;

using static WakeOnLAN.Enums.DialogMessages;

namespace WakeOnLAN
{
    public partial class ComputerWakeForm : Form
    {
        #region Private properties

        /// <summary>
        /// Where the XML document data is stored.
        /// </summary>
        private XmlDocument _document = new();

        /// <summary>
        /// Where all of the computer groups are stored.
        /// </summary>
        private List<string> _computerGroups = new();

        /// <summary>
        /// Where all macs are stored.
        /// </summary>
        private List<string> tmpMacList = new();

        /// <summary>
        /// Background worker.
        /// </summary>
        private BackgroundWorker _worker = new();

        #endregion

        #region Public properties

        /// <summary>
        /// Public XML document property.
        /// </summary>
        public XmlDocument Document
        {
            get => _document;
            set => _document = value;
        }

        /// <summary>
        /// Public computer group property.
        /// </summary>
        public List<string> ComputerGroups
        {
            get => _computerGroups;
            set => _computerGroups = value;
        }

        #endregion

        #region Class constructor

        /// <summary>
        /// Class constructor.
        /// </summary>
        public ComputerWakeForm()
        {
            InitializeComponent();

            #pragma warning disable CS8622 
            _worker.DoWork += backgroundWorker_WakeComputers;
            #pragma warning disable CS8622 
            _worker.ProgressChanged += backgroundWorker_ProgressChanged;
            #pragma warning disable CS8622
            _worker.RunWorkerCompleted += backgroundWorker_Completed;
            _worker.WorkerReportsProgress = true;
        }

        #endregion

        /// <summary>
        /// Event called when the form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComputerWakeForm_Load(object sender, EventArgs e)
        {
            this.computerGroup.Items.AddRange(_computerGroups.ToArray());
            this.computerGroup.Select();
        }

        /// <summary>
        /// Event called when clicking the wake up button.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void wakeUpButton_Click(object sender, EventArgs e)
        {
            // Disable the button until this is all done.
            this.wakeUpButton.Enabled = false;

            if (_document.DocumentElement is not null)
            {
                foreach (XmlNode node in _document.DocumentElement.ChildNodes)
                {
                    if (node.Name.Equals(this.computerGroup.Text))
                    {
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            if (childNode.NodeType is XmlNodeType.Element) // Double check this.
                            {
                                tmpMacList.Add(childNode.Attributes["mac"].Value);
                            }
                        }
                        break;
                    }
                }

                progressBar.Maximum = tmpMacList.Count;
                this.wakeUpButton.Enabled = false;
                this.cancelButton.Enabled = false;
                _worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Event called when validating the computer group.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void computerGroup_Validating(object sender, CancelEventArgs e)
        {
            // Clear all errors.
            errorProvider.Clear();

            if (string.IsNullOrEmpty(this.computerGroup.Text))
            {
                errorProvider.SetError(this.computerGroup, DialogMessage.ERR_GROUP_NOT_SELECTED.GetMessage());
                e.Cancel = true;
            }
        }

        #region Private methods

        /// <summary>
        /// Worker that wakes computers.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void backgroundWorker_WakeComputers(object sender, DoWorkEventArgs e)
        {
            foreach (string macAddress in tmpMacList)
            {
                Services.MagicPacketCreator.SendMagicPacket(macAddress);
                _worker.ReportProgress(1);
                Thread.Sleep(500);
            }
        }


        /// <summary>
        /// Worker that updates information.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value++;
            progressLabel.Text = $"{progressBar.Value}/{progressBar.Maximum} réveiller";
            progressLabel.Refresh();
        }

        /// <summary>
        /// Worker called when we are done waking.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void backgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            tmpMacList.Clear();

            DialogResult result = MessageBox.Show(DialogMessage.INFO_WAKE_UP_COMPLETED.GetMessage(),
                DialogMessage.INFO_TITLE.GetMessage(),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            if (result is DialogResult.OK)
            {
                this.Close();
            }
        }

        #endregion
    }
}
