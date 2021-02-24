using System;
using System.Collections.Generic;
using System.ComponentModel;
using CreditDepartment.Models;
using System.Windows.Forms;

namespace CreditDepartment
{
    public partial class CreditForm : Form
    {
        public Credit Credit { get; set; }
        public CreditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Credit = Credit ?? new Credit();
            Credit.CreditType = textBox1.Text;
            Credit.CreditProcent = Convert.ToDecimal(textBox2.Text);
            Credit.CreditAdditionalServices = textBox3.Text;
            Credit.CreditLoanProgram = textBox4.Text;
            Close();
        }

        public CreditForm(Credit credit) : this()
        {
            Credit = credit ?? new Credit();
            textBox1.Text = Credit.CreditType;
            textBox2.Text = Credit.CreditProcent.ToString();
            textBox3.Text = Credit.CreditAdditionalServices;
            textBox4.Text = Credit.CreditLoanProgram;
        }
    }
}
