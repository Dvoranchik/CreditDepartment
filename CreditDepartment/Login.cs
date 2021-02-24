using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreditDepartment.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDepartment
{
    public partial class Login : Form
    {
        ModelController controller;
        public Login(ModelController controller)
        {
            InitializeComponent();
            //Предыдущие логины
            textBox1.Text = ConfigurationManager.AppSettings["Login"];
            this.controller = controller;

            //TODO: СДЕЛАТЬ НОРМАЛЬНОЕ ПОДКЛЮЧЕНИЕ К БАЗЕ
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (controller.Initialize(textBox1.Text, textBox2.Text)){
                ConfigurationManager.AppSettings["Login"] = textBox1.Text;
                MessageBox.Show("Вход пользователя " + textBox1.Text + " выполнен успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //TODO: ПРАВИТЬ ЗДЕСЬ
                var form = new Menu(controller.context);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Ошибка авторизации!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
