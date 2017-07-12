using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace BESK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Devices db = new Devices();
        List<Device> items = new List<Device>();
        public MainWindow()
        {
   
                InitializeComponent();
                listRefresh();

            


            List<Department> cbItems = new List<Department>();
            cbItems.Add(new Department { FullName = "Machinery Department", ShortName = "MD" });
            cbItems.Add(new Department { FullName = "Timber Warehouse", ShortName = "TW" });
            cbItems.Add(new Department { FullName = "Painting Department", ShortName = "PD" });
            cbItems.Add(new Department { FullName = "Assebmling & Glazing Department", ShortName = "AGD" });
            cbItems.Add(new Department { FullName = "Fittings Warehouse", ShortName = "FW" });
            cbItems.Add(new Department { FullName = "Finished Goods Warehouse", ShortName = "FGW" });
            cmbColors.ItemsSource = cbItems;

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate window
            AddDevice dialogBox = new AddDevice();
          

            // Show window modally
            // NOTE: Returns only when window is closed
            Nullable<bool> dialogResult = dialogBox.ShowDialog();
            if(dialogResult == false)
            {

                listRefresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Device d = (Device)listView.SelectedItems[0];
            //var employer = new Device { Id = 1 };
            //ctx.Employ.Attach(employer);
            //ctx.Employ.Remove(employer);
            //ctx.SaveChanges();
            //db.Urzadzenia.Where(u => u.Id == d.Id ).First()
            //db.Urzadzenia.Remove(d);
            //db.SaveChanges();
            //listRefresh();
            items.Remove(d);
        }

        private void listRefresh()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = items;
        }

        string path = null;
        private void toCSV_Click(object sender, RoutedEventArgs e)
        {
            if (path == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV File  (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == true)
                    path = saveFileDialog.FileName;
                    using (var file = File.CreateText(path))
                    {
                        var query = items;

                        file.WriteLine("Id,Nazwa,Oddzial,MAC,ServiceTag");
                        foreach (var item in query)
                        {
                            file.WriteLine(string.Join(",", item.Id, item.Name, item.Department, item.MAC, item.ServiceTag));
                        }
                    }
            }
            else
            {
                using (var file = File.CreateText(path))
                {
                    var query = items;

                    file.WriteLine("Id,Nazwa,Oddzial,MAC,ServiceTag");
                    foreach (var item in query)
                    {
                        file.WriteLine(string.Join(",", item.Id, item.Name, item.Department, item.MAC, item.ServiceTag));
                    }
                }
            }
           
        }

        String dep = "...";
        private void cmbColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            String selectedColor = ((Department)cmbColors.SelectedItem).FullName;
            dep = selectedColor;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {

                var dev = new Device
                {
                    Name = textBox.Text,
                    Department = dep,
                    MAC = textBox2.Text,
                    ServiceTag = textBox3.Text
                };
                items.Add(dev);
                //db.SaveChanges();
            
            textBox.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            listRefresh();
            toCSV_Click(sender, e);

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            using (tb.DeclareChangeBlock())
            {
                foreach (var c in e.Changes)
                {
                    if (c.AddedLength == 0) continue;
                    tb.Select(c.Offset, c.AddedLength);

                    if (tb.SelectedText.Contains(' '))
                    {
                        tb.SelectedText = tb.SelectedText.Replace(' ', '-');
                    }
                    tb.Select(c.Offset + c.AddedLength, 0);
                }
            }

        }
    }
}
