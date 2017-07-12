using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace BESK
//{
//    /// <summary>
//    /// Interaction logic for AddDevice.xaml
//    /// </summary>
//    public partial class AddDevice : Window
//    {
//        public AddDevice()
//        {
//            InitializeComponent();
//        }

//        private void btn_save_Click(object sender, RoutedEventArgs e)
//        {

//            using (var db = new Devices())
//            {
//                var dev = new Device {
//                    Name = textBox.Text,
//                    Department = textBox1.Text,
//                    MAC = textBox2.Text,
//                    ServiceTag = textBox3.Text
//                };
//                db.Urzadzenia.Add(dev);
//                db.SaveChanges();
//            }
//            this.Close();
//        }

//        private void btn_cancel_Click(object sender, RoutedEventArgs e)
//        {
//            this.Close();
//        }
//    }
//}
