using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
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
        }

        private void Redakt_Click(object sender, RoutedEventArgs e)
        {
            Red_Ist red_Ist = new Red_Ist();
            red_Ist.Show();
        }

        private void Remove_Ist(object sender, RoutedEventArgs e)
        {
            Delet_Ist delet_Ist = new Delet_Ist();
            delet_Ist.Show();
        }

        private void Add_Vibr(object sender, RoutedEventArgs e)
        {
            Add_Vibr add_Vibr = new Add_Vibr();
            add_Vibr.Show();
        }

        private void Red_Vibr(object sender, RoutedEventArgs e)
        {
            Red_Vibr red_Vibr = new Red_Vibr();
            red_Vibr.Show();
        }

        private void Delet_Vibr(object sender, RoutedEventArgs e)
        {
            Delet_Vibr delet_Vibr = new Delet_Vibr();
            delet_Vibr.Show();
        }
    }
}
