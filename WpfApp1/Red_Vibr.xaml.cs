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
    /// Логика взаимодействия для Red_Vibr.xaml
    /// </summary>
    public partial class Red_Vibr : Window
    {
        public Red_Vibr()
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

        public string IDDD = "";
        public string Nameeе = "";
        public string Kolich = "";
        public string Kommentariy = "";
        public string Dateee = "";

        private void Redect1_Click(object sender, RoutedEventArgs e)
        {
            IDDD = idd.Text;
            Nameeе = Ist.Text;
            Kolich = kolic.Text;
            Kommentariy = kommentariy.Text;
            Dateee = Datee.Text;

            DataTable dt_user = Select("Update Emission Set id_source = ('" + Ist.Text + "'), count = ('" + kolic.Text + "'), text = ('" + kommentariy.Text + "'), date = ('" + Datee.Text + "')  WHERE id_emission = ('" + idd.Text + "')");
            MainWindow win_gl = new MainWindow();
            win_gl.Show();

            Close();
        }
    }
}
