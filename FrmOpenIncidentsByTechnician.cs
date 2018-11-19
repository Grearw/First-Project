using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SportsProBLLClassLibrary;

namespace SportsProUserInterfaceLayer
{
    public partial class FrmOpenIncidentsByTechnician : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public FrmOpenIncidentsByTechnician()
        {
            InitializeComponent();
        }

        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmOpenIncidentsByTechnician_Load(object sender, EventArgs e)
        {
            TechnicianBLL techBLL = new TechnicianBLL();
            DataTable dtTechNames = techBLL.GetTechnicianNames();

            cboSelectTechnician.DisplayMember = "NAME";
            cboSelectTechnician.ValueMember = "TECHID";
            cboSelectTechnician.DataSource = dtTechNames;

            cboSelectTechnician.SelectedIndex = -1;
            lblTechnicianEmail.Text = string.Empty;
            lblTechnicianPhone.Text = string.Empty;
        }

        private void cboSelectTechnician_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int techID = Convert.ToInt32(cboSelectTechnician.SelectedValue);

            IncidentBLL incBLL = new IncidentBLL();
            dgvOpenIncidentsByTechnician.DataSource = incBLL.GetOpenIncidentsByTechnician(techID);

            TechnicianBLL techBLL = new TechnicianBLL();
            Technician aTechnician = techBLL.GetTechnicianDetails(techID);

            string techEmail = aTechnician.TechEmail;
            string techPhone = aTechnician.TechPhoneNum;
            lblTechnicianEmail.Text = techEmail;
            lblTechnicianPhone.Text = techPhone;
        }
    }
}
