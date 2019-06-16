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
using WpfApp1;
using StoreLogicLibrary;
using StoreServiceWpfClient.StoreServiceHost;
using StorageLogicLibrary;

namespace StoreServiceWpfClient
{
    /// <summary>
    /// Interaction logic for BuyProduct.xaml
    /// </summary>
    public partial class BuyProduct : Window
    {
        StoreServiceClient storeservice = new StoreServiceClient();

        public BuyProduct()
        {
            InitializeComponent();
        }

        public void Init()
        {
                      
            // Get my products
            MyProducts();
            // Balance
            Balance();
            // Get the products
            RefreshProducts();
        }

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow SubWindow = new MainWindow();
            SubWindow.Show();
            this.Close();
        }

        private void kopen_button_Click(object sender, RoutedEventArgs e)
        {
            String Product = "";
            int quantity = 100000;
            try
            {
                string[] ProductZin = product_listbox.SelectedItem.ToString().Split('-');
                Product = ProductZin[0].Trim();
            }
            catch (Exception) {
                MessageBox.Show("Fout: Heb je wel een product geselecteerd?");
                return;
            }

            try
            {
                quantity = Int32.Parse(hoeveelheid_textbox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Fout: Heb je wel alleen een cijfer ingevoerd bij het te kopen aantal?");
                return;
            }

            if (storeservice.BuyProduct(username_label.Content.ToString(), Product, quantity))
            {
                Init();
                MessageBox.Show("Je hebt " + Product + " gekocht!");
               
            } else
            {
                MessageBox.Show("Helaas, dit product is uitverkocht of je hebt onvoldoende saldo meer!");
                return;
            }

    }

        public void RefreshProducts()
        {
            product_listbox.Items.Clear();

            foreach (var p in storeservice.GetProducts())
            {
               product_listbox.Items.Add(p.Name + " - €" + p.Price + " - nog " + p.Stock + " aanwezig");
            }
        }

        public void Balance()
        {
            // Get the username label
            string username = username_label.Content.ToString();
            // Set the credit
            credit.Content = storeservice.GetBalance(username);
        }

        public void MyProducts()
        {
            // Clear the listbox
            orders_listbox.Items.Clear();

            // Get the username label
            string username = username_label.Content.ToString();

            // Get the order for a user
            var orders = storeservice.GetAllOrders(username);

            orders_listbox.Items.Add("test");

            // Fix orders
            foreach (var o in orders)
            {
                orders_listbox.Items.Add(o.Name + ", " + o.Price + ", " + o.Quantity);
            }
        }

    }
}
