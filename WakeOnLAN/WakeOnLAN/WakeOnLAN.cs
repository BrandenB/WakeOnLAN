/**
* Author: Branden Brideau
* Date: June 2022
*/

using System.Xml;

using static WakeOnLAN.Enums.DialogMessages;

namespace WakeOnLAN
{
    public partial class WakeOnLAN : Form
    {
        #region Private properties

        /// <summary>
        /// Location of the Xml file.
        /// </summary>
        private readonly string _xmlFileLocation = ".\\";
        /// <summary>
        /// Name of the Xml file.
        /// </summary>
        private readonly string _xmlFileName = "Ordinateurs.xml";
        /// <summary>
        /// Where all Xml groups are saved.
        /// </summary>
        private readonly List<string> _xmlGroups = new();
        /// <summary>
        /// Where we store our Xml document.
        /// </summary>
        private readonly XmlDocument _document = new();

        #endregion

        public WakeOnLAN()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event called when the form loads.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void WakeOnLAN_Load(object sender, EventArgs e)
        {
            this.dataGridView.Rows.Clear();

            if (File.Exists(Path.GetFullPath($"{_xmlFileLocation}{_xmlFileName}")) is not true)
            {
                DialogResult result = MessageBox.Show(DialogMessage.ERR_XML_NOT_FOUND.GetMessage(),
                    DialogMessage.ERR_TITLE.GetMessage(),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (result is DialogResult.Yes)
                {
                    using (StreamWriter sw = File.CreateText(Path.GetFullPath($"{_xmlFileLocation}{_xmlFileName}")))
                    {
                        sw.WriteLine("<Ordinateurs>");
                        sw.WriteLine("</Ordinateurs>");
                    }
                }
                else
                {
                    this.Close();
                    return;
                }
            }

            try
            {
                // Load the XML file.
                _document.Load(Path.GetFullPath($"{_xmlFileLocation}{_xmlFileName}"));

                if (_document.DocumentElement is not null)
                {
                    foreach (XmlNode node in _document.DocumentElement.ChildNodes)
                    {
                        // This node is considered the group.
                        _xmlGroups.Add(node.Name);

                        if (node.ChildNodes.Count > 0)
                        {
                            foreach (XmlNode childNode in node.ChildNodes)
                            {
                                if (childNode.Attributes is not null)
                                {
                                    this.dataGridView.Rows.Add(
                                        childNode.Attributes["nom"]?.Value ?? string.Empty,
                                        childNode.Attributes["mac"]?.Value ?? string.Empty,
                                        node.Name,
                                        childNode.Attributes["local"]?.Value ?? string.Empty,
                                        childNode.Attributes["vlan"]?.Value ?? string.Empty,
                                        childNode.Attributes["info"]?.Value ?? string.Empty
                                    );
                                }
                            }
                        }
                    }

                    // Sort by computer name.
                    this.dataGridView.Sort(this.dataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    MessageBox.Show("DocumentElement is null?", "Null: ERR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: ERR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Method called when we click the add computer button.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ajouterUnordinateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ComputerInputForm form = new ComputerInputForm())
            {
                form.ComputerGroups = _xmlGroups;
                form.ShowDialog();

                if (form.DialogResult is DialogResult.Yes)
                {
                    foreach (XmlNode node in _document.DocumentElement.ChildNodes)
                    {
                        if (node.Name.Equals(form.ComputerGroup))
                        {
                            // Create a new node.
                            XmlNode child = _document.CreateElement("Ordinateur");
                            // Create new attribute.
                            XmlAttribute name = _document.CreateAttribute("nom");
                            name.Value = form.ComputerName;
                            // Create mac attribute.
                            XmlAttribute mac = _document.CreateAttribute("mac");
                            mac.Value = form.ComputerMac;
                            // Create local attribute.
                            XmlAttribute local = _document.CreateAttribute("local");
                            local.Value = form.ComputerLocal;
                            // Create vlan attribute.
                            XmlAttribute vlan = _document.CreateAttribute("vlan");
                            vlan.Value = form.ComputerVlan;
                            // Create info attribute.
                            XmlAttribute info = _document.CreateAttribute("info");
                            info.Value = form.ComputerInformation;

                            // Add the attributes to the node.
                            child.Attributes.Append(name);
                            child.Attributes.Append(mac);
                            child.Attributes.Append(local);
                            child.Attributes.Append(vlan);
                            child.Attributes.Append(info);

                            // Add the node to the group.
                            node.AppendChild(child);

                            // Save the document.
                            _document.Save(Path.GetFullPath($"{_xmlFileLocation}{_xmlFileName}"));

                            this.dataGridView.Rows.Add(
                                form.ComputerName,
                                form.ComputerMac,
                                node.Name,
                                form.ComputerLocal,
                                form.ComputerVlan,
                                form.ComputerInformation
                            );
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method called when we click add group button.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ajouterUngroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GroupInputForm form = new GroupInputForm())
            {
                form.ShowDialog();

                if (form.DialogResult is DialogResult.Yes)
                {
                    // Create a new node.
                    XmlNode child = _document.CreateElement(form.ComputerGroup);
                    // Add the new group.
                    _document.DocumentElement.AppendChild(child);
                    // Save the document.
                    _document.Save(Path.GetFullPath($"{_xmlFileLocation}{_xmlFileName}"));

                    _xmlGroups.Add(form.ComputerGroup);
                }
            }
        }

        /// <summary>
        /// Method called when we want to delete a group.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void suprimerUnGroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GroupDeletionForm form = new GroupDeletionForm())
            {
                form.ComputerGroups = _xmlGroups;
                form.ShowDialog();

                if (form.DialogResult is DialogResult.Yes)
                {
                    foreach (XmlNode node in _document.DocumentElement.ChildNodes)
                    {
                        if (node.Name.Equals(form.ComputerGroup))
                        {
                            // Remove the element.
                            _document.DocumentElement.RemoveChild(node);
                            // Save the document.
                            _document.Save(Path.GetFullPath($"{_xmlFileLocation}{_xmlFileName}"));

                            // Remove group from dropdown.
                            _xmlGroups.Remove(node.Name);
                            break;
                        }
                    }

                    WakeOnLAN_Load(null, null);// Reload table.

                    MessageBox.Show(DialogMessage.CON_GROUP_DELETED.GetMessage(), 
                        DialogMessage.INFO_TITLE.GetMessage(), 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                } 
            }
        }

        /// <summary>
        /// Method called when we click the wake up button.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void réveillerUnGroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ComputerWakeForm form = new ComputerWakeForm())
            {
                form.Document = _document;
                form.ComputerGroups = _xmlGroups;
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Event called when we click the close button
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}