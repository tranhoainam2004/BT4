using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BT4
{
    public partial class Form1 : Form
    {
        private List<Employee> employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                employees.Add(form2.NewEmployee);
                UpdateDataGridView();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Employee selectedEmployee = (Employee)dataGridView1.SelectedRows[0].DataBoundItem as Employee;
                if (selectedEmployee != null)
                {
                    Form2 form2 = new Form2(selectedEmployee);
                    if (form2.ShowDialog() == DialogResult.OK)
                    {
                        int index = employees.IndexOf(selectedEmployee);
                        if (index >= 0)
                        {
                            employees[index] = form2.NewEmployee;
                        }
                        UpdateDataGridView();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Employee selectedEmployee = (Employee)dataGridView1.SelectedRows[0].DataBoundItem as Employee;
                if (selectedEmployee != null)
                {
                    employees.Remove(selectedEmployee);
                    UpdateDataGridView();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = employees;
        }
    }

    public class Employee
    {
        public string MSNV { get; set; }
        public string TenNV { get; set; }
        public string LuongCB { get; set; }
    }
}