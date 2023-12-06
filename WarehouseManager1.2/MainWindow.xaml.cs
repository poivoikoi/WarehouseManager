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

namespace WarehouseManager1._2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Handle login logic
            // For example, open a login window
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Handle registration logic
            // For example, open a registration window
            var registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void ViewWarehouse_Click(object sender, RoutedEventArgs e)
        {
            // Handle registration logic
            // For example, open a registration window
            WarehousePage warehousePage = new WarehousePage();
            warehousePage.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
