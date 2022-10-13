using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase"); // создаём таблицу в приложении
                                                             // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Truba;User=33П;PWD=12357");
            sqlConnection.Open(); // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand(); // создаём команду
            sqlCommand.CommandText = selectSQL; // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close(); // возращаем таблицу с результатом
            return dataTable;
        }

        public string login = "";
        public string password = "";
        public string password1 = "";

        private void Zareg(object sender, RoutedEventArgs e)
        {
            login = TextBoxLog.Text;
            password = TextBoxpass.Password;
            password1 = TextBoxpass2.Password;
            if (login == "")
            {
                MessageBox.Show("Введите логин");
            }
            else
            {
                if (password == "")
                {
                    MessageBox.Show("Введите пароль");
                }
                else
                {
                    if (password1 == "")
                    {
                        MessageBox.Show("Повторите пароль");
                    }
                    else
                    {
                        if (password != password1)
                        {
                            MessageBox.Show("Проверьте на корректность ввода пароля");
                        }
                        else
                        {
                            DataTable dt_user1 = Select("SELECT * FROM Reg WHERE Login = '" + TextBoxLog.Text + "'");
                            if (dt_user1.Rows.Count == 0) // если такая запись существует       
                            {
                                MessageBox.Show("Регистрация успешно завершена");
                                DataTable dt_user = Select("insert into Reg (Login, Password) values('" + TextBoxLog.Text + "','" + TextBoxpass.Password + "')");
                                MainWindow win_gl = new MainWindow();
                                this.Close();
                                win_gl.Show();
                            }
                            else
                            {
                                MessageBox.Show("Такой аккаунт уже существует");
                            }
                        }
                    }
                }
            }
        }
    }
}
