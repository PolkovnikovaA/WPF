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
    /// Логика взаимодействия для min_vibr.xaml
    /// </summary>
    public partial class min_vibr : Window
    {
        public min_vibr()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Truba;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select min(count) from Emission", connection);
                float n = Convert.ToInt32(command.ExecuteScalar().ToString());
                int id;
                int id1;
                string text;
                string Date;
                SqlCommand command1 = new SqlCommand("select id_emission FROM Emission WHERE Count=" + n + "", connection);
                id1 = Convert.ToInt32(command1.ExecuteScalar().ToString());
                SqlCommand command2 = new SqlCommand("select id_source FROM Emission WHERE Count=" + n + "", connection);
                id = Convert.ToInt32(command2.ExecuteScalar().ToString());
                SqlCommand command3 = new SqlCommand("select text FROM Emission WHERE Count=" + n + "", connection);
                text = Convert.ToString(command3.ExecuteScalar().ToString());
                SqlCommand command4 = new SqlCommand("select date FROM Emission WHERE Count=" + n + "", connection);
                Date = Convert.ToString(command4.ExecuteScalar().ToString());
                List<Vibrlist> vibrosList = new List<Vibrlist>
                {

                };
                vibrosList.Add(new Vibrlist { id_emission = id1, id_source = id, count = n, text = text, date = Date });
                table_4.ItemsSource = vibrosList;
            }

        }
        private void MinClose_Click(object sender, RoutedEventArgs e)
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
