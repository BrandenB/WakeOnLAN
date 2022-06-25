/**
 * Author: Branden Brideau
 * Date: June 2022
 */
namespace WakeOnLAN
{
    public partial class WakeOnLAN : Form
    {
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
                form.ShowDialog();

                if (form.DialogResult is DialogResult.Yes)
                {
                    // Add data.
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
                form.ShowDialog();
                // No validation here, the form takes care of it all.
            }
        }
    }
}