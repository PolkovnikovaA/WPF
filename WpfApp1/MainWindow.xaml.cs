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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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
                SqlCommand command = new SqlCommand("select max(id_emission) from Emission", connection);
                int n = Convert.ToInt32(command.ExecuteScalar().ToString());
                int[] id = new int[n];
                float[] count = new float[n];
                string[] text = new string[n];
                string[] Date = new string[n];

                for (int i = 1; i <= n; i++)
                {
                    SqlCommand command1 = new SqlCommand("select id_source FROM Emission WHERE id_emission=" + i + "", connection);
                    if (command1.ExecuteScalar() is null)
                    {

                    }
                    else
                    {
                        id[i - 1] = Convert.ToInt32(command1.ExecuteScalar().ToString());
                        SqlCommand command2 = new SqlCommand("select count FROM Emission WHERE id_emission=" + i + "", connection);
                        count[i - 1] = float.Parse(command2.ExecuteScalar().ToString());
                        SqlCommand command3 = new SqlCommand("select text FROM Emission WHERE id_emission=" + i + "", connection);
                        text[i - 1] = Convert.ToString(command3.ExecuteScalar().ToString());
                        SqlCommand command4 = new SqlCommand("select date FROM Emission WHERE id_emission=" + i + "", connection);
                        Date[i - 1] = Convert.ToString(command4.ExecuteScalar().ToString());
                    }
                }
                List<Vibrlist> vibrosList = new List<Vibrlist>
                {

                };
                for (int i = 1; i <= n; i++)
                {
                    if (Date[i - 1] == null)
                    {

                    }
                    else
                    {
                        vibrosList.Add(new Vibrlist { id_emission = i, id_source = id[i - 1], count = count[i - 1], text = text[i - 1], date = Date[i - 1] });
                    }
                }

                table_2.ItemsSource = vibrosList;
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
        private void Max_vibro(object sender, RoutedEventArgs e)
        {
            Maks_vibr max_Vibr = new Maks_vibr();
            max_Vibr.Show();
            Close();
        }
        private void Min_Vibro(object sender, RoutedEventArgs e)
        {
            min_vibr Min_Vibr = new min_vibr();
            Min_Vibr.Show();
            Close();
        }

        private void SR_Vibro(object sender, RoutedEventArgs e)
        {
            SR_vibr sr_Vibr = new SR_vibr();
            sr_Vibr.Show();
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
