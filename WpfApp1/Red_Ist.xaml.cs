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
    /// Логика взаимодействия для Red_Ist.xaml
    /// </summary>
    public partial class Red_Ist : Window
    {
        public Red_Ist()
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


        public string IDD = "";
        public string Namee = "";
        public string Adres = "";

        private void Redect_Click(object sender, RoutedEventArgs e)
        {
            IDD = id.Text;
            Namee = namee.Text;
            Adres = adres.Text;
            DataTable dt_user = Select("Update Source Set name = ('" + namee.Text + "'), address = ('" + adres.Text + "')  WHERE id_source = ('" + id.Text + "')");
            MainWindow win_gl = new MainWindow();
            win_gl.Show();

            Close();
        }

    }
}
