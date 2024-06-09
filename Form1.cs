using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KHARDPROJECT
{
    public partial class Form1 : Form
    {
        public class DatabaseConnection
        {
            public static MySqlConnection GetConnection()
            {
                string connectionString = "server=localhost;database=romashka;username=batat;password=Alliseeisred12!;";

                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection;
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем данные из текстовых полей
            string login = textBox2.Text;
            string password = textBox3.Text;
            string email = textBox4.Text;

            // Формируем SQL-запрос для вставки данных
            string query = "INSERT INTO users (name, password, email) VALUES (@login, @password, @email)";

            // Создаем объект MySqlCommand
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                 
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);

                    // Открываем соединение с базой данных
                    connection.Open();

                    // Выполняем запрос на вставку
                    command.ExecuteNonQuery();

                    // Закрываем соединение
                    connection.Close();

                    // Отображаем сообщение об успешной вставке
                    MessageBox.Show("Вы успешно зарегистрировались!");

                    // Очищаем текстовые поля
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }
            
        }
    }
}
