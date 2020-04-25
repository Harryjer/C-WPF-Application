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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotelDataClasses1DataContext db = new HotelDataClasses1DataContext();
        public MainWindow()
        {
            InitializeComponent();
            list1.ItemsSource = db.Hotels;
        }

        private void txt_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var q1 = from ho in db.Hotels where ho.Hotel_Name.Contains(txt_1.Text) select ho;

            list1.ItemsSource = q1;
        }

        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hotel h = (Hotel)list1.SelectedItem;
            HotelDetails d = new HotelDetails(h);
            d.Show();
        }
    }
}
