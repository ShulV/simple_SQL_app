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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Console.WriteLine("Getting Connection ...");
            DataBase database = new DataBase();
            MySqlConnection conn = database.GetConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //логин и пароль из полей
            String user_login = this.LoginTextBox.Text;
            String user_password = this.PasswordTextBox.Text;
            //содание БД
            DataBase data_base = new DataBase();
            //создание таблицы БД
            DataTable data_table = new DataTable();
            //адаптер
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //sql команда
            /*
             SELECT - выборка
             '*' - обозначает выбор всех всех записей
             FROM `users` - из таблицы 'users'
             @LP и @PU - переменные-заглушки
             */
            String sql_command = "SELECT * FROM `users` WHERE `login` = @LU AND `password` = @PU";
            MySqlCommand command = new MySqlCommand(sql_command, data_base.GetConnection());
            //переменые-заглушки заполняются значениями из полей формы
            command.Parameters.Add("@LU", MySqlDbType.VarChar).Value = user_login;
            command.Parameters.Add("@PU", MySqlDbType.VarChar).Value = user_password;
            //выбрать команду для объекта-адаптера
            adapter.SelectCommand = command;
            //заполняем объект-Table данными, полученными после выполнения команды
            adapter.Fill(data_table);
            //если Table чем-то заполнилось, значит в БД нашлось совпадение
            if (data_table.Rows.Count > 0)
                MessageBox.Show("YEAH!");
            else
                MessageBox.Show("Nooo!");
        }
    }
}
