using System;
using CreditDepartment.Models;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace CreditDepartment
{
    public partial class Catalog<T> : Form
        where T : class
    {
        ModelContext db;
        DbSet<T> set;

        public Catalog(DbSet<T> set, ModelContext db)
        {
            InitializeComponent();
            //TODO: СДЕЛАТЬ ОКНО ПОИСКА И ОТБОРА ПО КРИТЕРИЮ
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: СДЕЛАТЬ ПРОВЕРКУ ВВЕДЕНЫХ ДАННЫХ
            if (typeof(T) == typeof(Client))
            {
                    var form = new ClientForm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
            }
            else if (typeof(T) == typeof(Contract))
            {
               
                    var form = new ContractForm( db);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
            }
            else if (typeof(T) == typeof(Credit))
            {
               
                    var form = new CreditForm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
            }
            else if (typeof(T) == typeof(Employee))
            {
                    var form = new EmployeeForm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Client))
            {
                var client = set.Find(id) as Client;
                if (client != null)
                {
                    var form = new ClientForm(client);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        client = form.Client;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Contract))
            {
                var contract = set.Find(id) as Contract;
                if (contract != null)
                {
                    var form = new ContractForm(contract, db);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        contract = form.Contract;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Credit))
            {
                var credit = set.Find(id) as Credit;
                if (credit != null)
                {
                    var form = new CreditForm(credit);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        credit = form.Credit;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Employee))
            {
                var employee = set.Find(id) as Employee;
                if (employee != null)
                {
                    var form = new EmployeeForm(employee);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        employee = form.Employee;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
