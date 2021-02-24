using System;
using CreditDepartment.Models;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace CreditDepartment
{
    public partial class ContractForm : Form
    {
        public Contract Contract { get; set; }
        private ModelContext db;
        public ContractForm(ModelContext db)
        {
            InitializeComponent();
            this.db = db;
            comboBox1.Items.Add(db.Employees.Select(u => u.EmployeeName));
            comboBox2.Items.Add(db.Clients.Select(u => u.ClientName));
            comboBox3.Items.Add(db.Credits.Select(u => u.CreditType));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contract = Contract ?? new Contract();
            Contract.ContractData = dateTimePicker1.Value;
            Contract.ContractType = textBox2.Text;
            Contract.Employee = db.Employees.Where(u => u.EmployeeName == comboBox1.Text).FirstOrDefault();
            Contract.EmployeeId = Contract.Employee.EmployeeId;
            Contract.Client = db.Clients.Where(u => u.ClientName == comboBox2.Text).FirstOrDefault();
            Contract.ClientId = Contract.Client.ClientId;
            Contract.Credit = db.Credits.Where(u => u.CreditType == comboBox3.Text).FirstOrDefault();
            Contract.CreditId = Contract.Credit.CreditId;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ContractForm(Contract contract, ModelContext db) : this(db)
        {
            Contract = contract ?? new Contract();
            dateTimePicker1.Value = Contract.ContractData;
            textBox2.Text = Contract.ContractType;
            comboBox1.Text = Contract.Employee.EmployeeName;
            comboBox1.Items.Add(db.Employees.Select(u => u.EmployeeName));
            comboBox2.Text = Contract.Client.ClientName;
            comboBox2.Items.Add(db.Clients.Select(u => u.ClientName));
            comboBox3.Text = Contract.Credit.CreditType;
            comboBox3.Items.Add(db.Credits.Select(u => u.CreditType));
        }
    }
}
