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
            List<string> tmpMacList = new();

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

                // Attempt to a rate limiter (Lol).
                Thread thread = new Thread(() =>
                {
                    DateTime nextSend = DateTime.Now.AddMinutes(-1);
                    DateTime lastSend = DateTime.Now.AddMinutes(-1);
                    int currentLimit = 0;
                    int limit = 10;

                    foreach (string macAddress in tmpMacList)
                    {
                        DateTime startTime = DateTime.Now;

                        if (nextSend < startTime || currentLimit <= limit)
                        {
                            if (lastSend > startTime)
                            {
                                if (currentLimit >= limit)
                                {
                                    nextSend = (startTime + (lastSend - startTime));
                                    Thread.Sleep(nextSend - startTime);
                                }
                                currentLimit++;
                            } else
                            {
                                currentLimit = 0;
                                lastSend = startTime.AddSeconds(10); // 10 seconds delay after each 10 WOL.
                            }

                            Services.MagicPacketCreator.SendMagicPacket(macAddress);
                            progressBar.Value++;
                            progressLabel.Text = $"{progressBar.Value}/{progressBar.Maximum} réveiller";
                        }
                    }
                    this.wakeUpButton.Enabled = true;
                }); 
            }

            DialogResult result = MessageBox.Show(DialogMessage.INFO_WAKE_UP_COMPLETED.GetMessage(),
                DialogMessage.INFO_TITLE.GetMessage(),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            if (result is DialogResult.OK)
            {
                this.Close();
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
    }
}
