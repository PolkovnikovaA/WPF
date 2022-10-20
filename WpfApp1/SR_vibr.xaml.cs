using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SR_vibr.xaml
    /// </summary>
    public partial class SR_vibr : Window
    {
        public SR_vibr()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Truba;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select avg(count) from Emission", connection);
                string nn = command.ExecuteScalar().ToString();
                float n = float.Parse(nn);
                n = Convert.ToInt32(Math.Round(n, 1));
                int id = 0;
                int id1 = 0;
                string text = "";
                string Date = "";
                SqlCommand commandd1 = new SqlCommand("select id_emission FROM Emission WHERE count=" + n + "", connection);
                if (commandd1.ExecuteScalar() is null)
                {

                }
                else
                {
                    SqlCommand command1 = new SqlCommand("select id_emission FROM Emission WHERE count=" + n + "", connection);
                    id1 = Convert.ToInt32(command1.ExecuteScalar().ToString());
                    SqlCommand command2 = new SqlCommand("select id_source FROM Emission WHERE count=" + n + "", connection);
                    id = Convert.ToInt32(command2.ExecuteScalar().ToString());
                    SqlCommand command3 = new SqlCommand("select text FROM Emission WHERE count=" + n + "", connection);
                    text = Convert.ToString(command3.ExecuteScalar().ToString());
                    SqlCommand command4 = new SqlCommand("select date FROM Emission WHERE count=" + n + "", connection);
                    Date = Convert.ToString(command4.ExecuteScalar().ToString());
                }
                List<Vibrlist> vibrosList = new List<Vibrlist>
                {

                };
                vibrosList.Add(new Vibrlist { id_emission = id1, id_source = id, count = n, text = text, date = Date });
                table_5.ItemsSource = vibrosList;
            }
        }
        private void SRClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow glavnaya = new MainWindow();
            glavnaya.Show();
            Close();
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
