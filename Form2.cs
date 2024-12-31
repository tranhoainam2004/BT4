
using System;
using System.Windows.Forms;
using BT4;
using System.Xml.Linq;

namespace BT4
{
    public partial class Form2 : Form
    {
        public Employee NewEmployee { get; private set; }

        public Form2(Employee employee = null)
        {
            InitializeComponent();
            if (employee != null)
            {
                txtMssv.Text = employee.MSNV;
                txtName.Text = employee.TenNV;
                txtLuong.Text = employee.LuongCB;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMssv.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewEmployee = new Employee
            {
                MSNV = txtMssv.Text,
                TenNV = txtName.Text,
                LuongCB = txtLuong.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}