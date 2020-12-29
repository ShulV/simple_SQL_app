using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_SQL_app
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            //содание БД
            DataBase data_base = new DataBase();
            string sql_command = "INSERT INTO `users` (`login`, `password`, `name`, `surname`) VALUES(@login, @password, @name, @surname);";
            MySqlCommand command = new MySqlCommand(sql_command, data_base.GetConnection());
            //переменые-заглушки заполняются значениями из полей формы
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginTextBox.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PasswordTextBox.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameTextBox.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameTextBox.Text;

            data_base.openConnection();
              try {
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Регистрация прошла успешно!");
                else
                    MessageBox.Show("Регистрация прервана.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Регистрация прервана.\n" + ex.Message);
            }
            data_base.closeConnection();
        }
    }
}
