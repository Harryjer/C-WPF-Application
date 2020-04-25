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
    /// Interaction logic for Room_Details.xaml
    /// </summary>
    public partial class Room_Details : Window
    {
        HotelDataClasses1DataContext db = new HotelDataClasses1DataContext();
        int Hotel_id;
        public Room_Details(int id)
        {
            InitializeComponent();
            Hotel_id = id;
            list_1.ItemsSource = from h in db.Rooms where h.Hotel == Hotel_id select h;
        }

        private void list_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room r = (Room)list_1.SelectedItem;
            if(r != null)
            {
                txt_2.Text = r.Room_Id + "";
                txt_3.Text = r.Category + "";
                txt_4.Text = r.Price + "";
                txt_5.Text = r.Description + "";
                txt_6.Text = r.Image + "";

            }
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            var id = (from r in db.Rooms select r.Room_Id).Max();

            Room r1 = new Room();
            r1.Room_Id = id = 1;
            r1.Category = txt_3.Text;
            r1.Price = float.Parse(txt_4.Text);
            r1.Description = txt_5.Text;
            r1.Image = txt_6.Text;
            r1.Hotel = Hotel_id;
            db.Rooms.InsertOnSubmit(r1);
            db.SubmitChanges();
            MessageBox.Show("Record Inserted");

            list_1.ItemsSource = from h in db.Rooms where h.Hotel == Hotel_id select h;

        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            Room r1 = (from r in db.Rooms where r.Room_Id == int.Parse(txt_2.Text) select r).Single();
            r1.Category = txt_3.Text;
            r1.Price = float.Parse(txt_4.Text);
            r1.Description = txt_5.Text;
            r1.Image = txt_6.Text;

            db.SubmitChanges();
            MessageBox.Show("Record Updated");

            list_1.ItemsSource = from h in db.Rooms where h.Hotel == Hotel_id select h;
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            Room r1 = (from r in db.Rooms where r.Room_Id == int.Parse(txt_2.Text) select r).Single();

            MessageBoxResult r = 
            MessageBox.Show("Delete " + r1.Category, "Confirmation", MessageBoxButton.OKCancel);
            if(r == MessageBoxResult.OK)
            {
                db.Rooms.DeleteOnSubmit(r1);
                db.SubmitChanges();
                MessageBox.Show("Record Removed");

                list_1.ItemsSource = from h in db.Rooms where h.Hotel == Hotel_id select h;
            }
        }
    }
}
