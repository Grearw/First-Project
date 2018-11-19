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
    public partial class FrmViewIncidentsByTechnician : Form
    {
        private const int cP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | cP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public FrmViewIncidentsByTechnician()
        {
            InitializeComponent();
        }

        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnGetIncidents_Click(object sender, EventArgs e)
        {
            IncidentBLL incBLL = new IncidentBLL();
            dgvViewIncidentsByTech.DataSource = incBLL.GetIncidentsByTechnician(int.Parse(txtTechID.Text));
        }
    }
}
