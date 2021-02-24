using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CreditDepartment.Models;

namespace CreditDepartment
{
    public partial class Menu : Form
    {
        ModelContext db;
        public Menu(ModelContext db)
        {
            this.db = db;
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var form = new Catalog<Client>(db.Clients, db);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Catalog<Employee>(db.Employees, db);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Catalog<Contract>(db.Contracts, db);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new Catalog<Credit>(db.Credits, db);
            form.Show();

        }
    }
}
