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
    public partial class FrmAddRegistration : Form
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

        public FrmAddRegistration()
        {
            InitializeComponent();
        }

        private void FrmAddRegistration_Load(object sender, EventArgs e)
        {
            CustomerBLL custBLL = new CustomerBLL();
            Customer aCustomer = new Customer();
            List<Customer> lstCustDetails = custBLL.RetrieveCustomerIDandName();

            cboCustomerName.DisplayMember = "Name";
            cboCustomerName.ValueMember = "CustomerID";
            cboCustomerName.DataSource = lstCustDetails;

            ProductBLL prodBLL = new ProductBLL();
            Product aProduct = new Product();
            List<Product> lstProdDetails = prodBLL.RetrieveProductNameandCode();
           
            cboProduct.DisplayMember = "Name";
            cboProduct.ValueMember = "ProductCode";
            cboProduct.DataSource = lstProdDetails;

            cboCustomerName.SelectedIndex = -1;
            cboProduct.SelectedIndex = -1;
        }

        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAddRegistration_Click(object sender, EventArgs e)
        {
            Registration aRegistration = new Registration();
            RegistrationBLL regBLL = new RegistrationBLL();

            aRegistration.CustomerID = (int)cboCustomerName.SelectedValue;
            aRegistration.ProductCode = cboProduct.SelectedValue.ToString();
            aRegistration.RegistrationDate = (DateTime)DateTime.Today;

            if (regBLL.AddNewRegistration(aRegistration) is true)
            {
                MessageBox.Show("The Product was successfully registered", "Add Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The registration already exists", "Add Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
