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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase"); // создаём таблицу в приложении
                                                             // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Man_Sor_V_A;User=33П;PWD=12357");
            sqlConnection.Open(); // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand(); // создаём команду
            sqlCommand.CommandText = selectSQL; // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close(); // возращаем таблицу с результатом
            return dataTable;
        }

        public MainWindow()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Truba;User=33П;PWD=12357"))
            {
            
                connection.Open();
                SqlCommand createCommand = new SqlCommand("SELECT max(id_source) FROM Source", connection);


                //string cmd = "SELECT * FROM Source"; // Из какой таблицы нужен вывод 
                //SqlCommand createCommand = new SqlCommand(cmd, connection);
                int n = Convert.ToInt32(createCommand.ExecuteScalar().ToString());
                int[] id_source = new int[n];
                string[] name = new string[n];
                string[] address = new string[n];

                for (int i = 1; i <= n; i++)
                {
                    SqlCommand createCommand1 = new SqlCommand("select id_source from Source Where id_source=" + i + "", connection);
                    if (createCommand1.ExecuteScalar() is null)
                    {

                    }
                    else 
                    {
                        id_source[i - 1] = Convert.ToInt32(createCommand1.ExecuteScalar().ToString());
                        SqlCommand createCommand2 = new SqlCommand("select name from Source Where id_source=" + i + "", connection);
                        name[i-1] = Convert.ToString(createCommand2.ExecuteScalar().ToString());
                        SqlCommand createCommand3 = new SqlCommand("select address from Source Where id_source=" + i + "", connection);
                        address[i-1] = Convert.ToString(createCommand3.ExecuteScalar().ToString());
                    }
                }
                List<Istlist> istlist = new List<Istlist>
                {

                };
                for (int i = 1; i <= n; i++)
                {
                    if (address[i-1] == null)
                    {

                    }
                    else
                    {
                        istlist.Add(new Istlist { id_source = i, name = name[i - 1], address = address[i - 1] });
                    }
                }
                table_1.ItemsSource = istlist;

            }

            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Truba;User=33П;PWD=12357"))
            {

                connection.Open();
                SqlCommand createCommand = new SqlCommand("SELECT max(id_emission) FROM Emission", connection);


                //string cmd = "SELECT * FROM Source"; // Из какой таблицы нужен вывод 
                //SqlCommand createCommand = new SqlCommand(cmd, connection);
                int k = Convert.ToInt32(createCommand.ExecuteScalar().ToString());
                int[] id_emission = new int[k];
                int[] id_source = new int[k];
                float[] count = new float[k];
                string[] text = new string[k];
                string[] date = new string[k];

                for (int i = 1; i <= k; i++)
                {
                    SqlCommand createCommand1 = new SqlCommand("select id_emission from Emission Where id_emission=" + i + "", connection);
                    if (createCommand1.ExecuteScalar() is null)
                    {

                    }
                    else
                    {
                        id_emission[i - 1] = Convert.ToInt32(createCommand1.ExecuteScalar().ToString());
                        SqlCommand createCommand2 = new SqlCommand("select count from Emission Where id_emission=" + i + "", connection);
                        count[i - 1] = float.Parse(createCommand2.ExecuteScalar().ToString());
                        SqlCommand createCommand3 = new SqlCommand("select text from Emission Where id_emission=" + i + "", connection);
                        text[i - 1] = Convert.ToString(createCommand3.ExecuteScalar().ToString());
                        SqlCommand createCommand4 = new SqlCommand("select date from Emission Where id_emission=" + i + "", connection);
                        date[i - 1] = Convert.ToString(createCommand4.ExecuteScalar().ToString());
                    }
                }
                List<Vibrlist> vibrlist = new List<Vibrlist>
                {

                };
                for (int i = 1; i <= k; i++)
                {
                    if (date[i - 1] == null)
                    {

                    }
                    else
                    {
                        vibrlist.Add(new Vibrlist { id_emission = i, id_source = id_source[i-1], count = count[i - 1], text = text[i - 1], date = date[i - 1] });
                    }
                }
                table_2.ItemsSource = vibrlist;

            }


        }

        private void Reg(object sender, RoutedEventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
        }

        private void Add11(object sender, RoutedEventArgs e)
        {
            Add add1 = new Add();
            add1.Show();
        }

        private void Add_Ist(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.Show();
            Close();
        }

        private void Redakt_Click(object sender, RoutedEventArgs e)
        {
            Red_Ist red_Ist = new Red_Ist();
            red_Ist.Show();
            Close();
        }

        private void Remove_Ist(object sender, RoutedEventArgs e)
        {
            Delet_Ist delet_Ist = new Delet_Ist();
            delet_Ist.Show();
            Close();
        }

        private void Add_Vibr(object sender, RoutedEventArgs e)
        {
            Add_Vibr add_Vibr = new Add_Vibr();
            add_Vibr.Show();
            Close();
        }

        private void Red_Vibr(object sender, RoutedEventArgs e)
        {
            Red_Vibr red_Vibr = new Red_Vibr();
            red_Vibr.Show();
            Close();
        }

        private void Delet_Vibr(object sender, RoutedEventArgs e)
        {
            Delet_Vibr delet_Vibr = new Delet_Vibr();
            delet_Vibr.Show();
            Close();
        }

        internal class Istlist
        {
            public int id_source { get; set; }
            public string name { get; set; }
            public string address { get; set; }
        }

        internal class Vibrlist
        {
            public int id_emission { get; set; }
            public int id_source { get; set; }
            public float count { get; set; }
            public string text { get; set; }
            public string date { get; set; }
        }
    }
}
