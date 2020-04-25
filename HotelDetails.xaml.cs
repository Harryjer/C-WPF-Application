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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for HotelDetails.xaml
    /// </summary>
    public partial class HotelDetails : Window
    {
        public HotelDetails(Hotel h)
        {
            InitializeComponent();

            txt_1.Text = h.Hotel_Id + "";
            txt_2.Text = h.Hotel_Name + "";
            txt_3.Text = h.Ratings + "";
            txt_4.Text = h.Destination + "";
            img.Source =new BitmapImage (new Uri(h.Image, UriKind.Absolute));

        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            int h_id = int.Parse(txt_1.Text);
            Room_Details r = new Room_Details(h_id);
            r.Show();
        }
    }
}
