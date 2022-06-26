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

        /// <summary>
        /// Location of the mouse.
        /// </summary>
        private DataGridViewCellMouseEventArgs? mouseLocation;

        #endregion

        #region Class constructor.
        
        /// <summary>
        /// Class constructor.
        /// </summary>
        public WakeOnLAN()
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
        private void WakeOnLAN_Load(object? sender, EventArgs? e)
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
        /// Event called to open the rick click conext menu on data grid view.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            mouseLocation = e;

            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button is MouseButtons.Right)
                {
                    DataGridViewCell cell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    this.dataGridView.CurrentCell = cell;

                    Point mousePos = this.dataGridView.PointToClient(Cursor.Position);

                    this.contextMenuStrip.Show(this.dataGridView, mousePos);
                }
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

        /// <summary>
        /// Context menu delete event.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void suprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(DialogMessage.CON_COMPUTER_DELETION.GetMessage()
                    + $" (Ordinateur: {this.dataGridView.Rows[mouseLocation.RowIndex].Cells[0].Value}, Adresse MAC: {this.dataGridView.Rows[mouseLocation.RowIndex].Cells[1].Value})",
                    DialogMessage.INFO_TITLE.GetMessage(),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result is DialogResult.Yes)
            {
                foreach (XmlNode node in _document.DocumentElement.ChildNodes)
                {
                    if (node.Name.Equals(this.dataGridView.Rows[mouseLocation.RowIndex].Cells[2].Value.ToString()))
                    {
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            if (childNode.Attributes["nom"].Value.Equals(this.dataGridView.Rows[mouseLocation.RowIndex].Cells[0].Value))
                            {
                                // Delete the node.
                                node.RemoveChild(childNode);
                                // Save the document.
                                _document.Save(Path.GetFullPath($"{_xmlFileLocation}{_xmlFileName}"));
                                // Remove the row from the list.
                                this.dataGridView.Rows.RemoveAt(mouseLocation.RowIndex);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Context menu edit event.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ComputerInputForm form = new ComputerInputForm())
            {
                form.ComputerGroups = _xmlGroups;
                form.ComputerName = this.dataGridView.Rows[mouseLocation.RowIndex].Cells[0].Value.ToString() ?? string.Empty;
                form.ComputerMac = this.dataGridView.Rows[mouseLocation.RowIndex].Cells[1].Value.ToString() ?? string.Empty;
                form.ComputerGroup = this.dataGridView.Rows[mouseLocation.RowIndex].Cells[2].Value.ToString() ?? string.Empty;
                form.ComputerLocal = this.dataGridView.Rows[mouseLocation.RowIndex].Cells[3].Value.ToString() ?? string.Empty;
                form.ComputerVlan = this.dataGridView.Rows[mouseLocation.RowIndex].Cells[4].Value.ToString() ?? string.Empty;
                form.ComputerInformation = this.dataGridView.Rows[mouseLocation.RowIndex].Cells[5].Value.ToString() ?? string.Empty;

                form.ShowDialog();

                if (form.DialogResult is DialogResult.Yes)
                {
                    // To keep things easy, delete it, create a new one in the right place (this is if the group changed).
                    foreach (XmlNode node in _document.DocumentElement.ChildNodes)
                    {
                        if (node.Name.Equals(this.dataGridView.Rows[mouseLocation.RowIndex].Cells[2].Value.ToString()))
                        {
                            foreach (XmlNode childNode in node.ChildNodes)
                            {
                                if (childNode.Attributes["nom"].Value.Equals(this.dataGridView.Rows[mouseLocation.RowIndex].Cells[0].Value))
                                {
                                    // Delete the node.
                                    node.RemoveChild(childNode);
                                    // Save the document.
                                    _document.Save(Path.GetFullPath($"{_xmlFileLocation}{_xmlFileName}"));
                                    // Remove the row from the list.
                                    this.dataGridView.Rows.RemoveAt(mouseLocation.RowIndex);
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    // Add the node again.
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
        #endregion
    }
}