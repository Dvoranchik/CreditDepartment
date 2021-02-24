using System;
using CreditDepartment.Models;
using System.Windows.Forms;

namespace CreditDepartment
{
    public partial class EmployeeForm : Form
    {
        public Employee Employee { get; set; }
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee = Employee ?? new Employee();
            Employee.EmployeeName = textBox1.Text;
            Employee.EmployeePost = textBox2.Text;
            Close();
        }
        public EmployeeForm(Employee seller) : this()
        {
            Employee = seller ?? new Employee();
            textBox1.Text = Employee.EmployeeName;
            textBox2.Text = Employee.EmployeePost;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
