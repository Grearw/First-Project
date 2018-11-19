using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsProUserInterfaceLayer
{
    public partial class FrmMain : Form
    {
        FrmViewAllIncidents viewAllIncidents = new FrmViewAllIncidents();
        FrmViewIncidentsByTechnician viewIncidentsByTechnician = new FrmViewIncidentsByTechnician();
        FrmOpenIncidentsByTechnician viewOpenIncidentsByTechnician = new FrmOpenIncidentsByTechnician();
        FrmAddRegistration frmAddRegistration = new FrmAddRegistration();
        

        public FrmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                this.Dispose();
                this.Close();
            }
            Application.Exit();
        }

        private void showFormInMDI(Form FrmMain)
        {
            FrmMain.MdiParent = this;
            FrmMain.Anchor = AnchorStyles.Top;
            FrmMain.Anchor = AnchorStyles.Left;
            FrmMain.Dock = DockStyle.Fill;
            FrmMain.Show();
        }

        private void displayAllIncidentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showFormInMDI(viewAllIncidents);
        }

        private void displayIncidentsByTechnicianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            showFormInMDI(viewIncidentsByTechnician);
        }

        private void displayOpenIncidentsByTechnicianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            showFormInMDI(viewOpenIncidentsByTechnician);
        }

        private void addRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showFormInMDI(frmAddRegistration);
        }
    }
}
