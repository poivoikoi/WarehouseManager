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
using WarehouseManager1._2.Data;

namespace WarehouseManager1._2
{
    public partial class LoginWindow : Window
    {
        private DataLayer _dataLayer;

        public LoginWindow()
        {
            InitializeComponent();
            _dataLayer = new DataLayer();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Call your data layer method to authenticate the user
            // Replace YourDataLayer.AuthenticateUser with your actual authentication method
            bool authenticationSuccess = _dataLayer.AuthenticateUser(username, password);

            if (authenticationSuccess)
            {
                MessageBox.Show("Login successful!");
              
                this.Close();

                User authenticatedUser = _dataLayer.GetUserByUsername(username); // Fetch the user details from the database
                WarehousePage warehousePage = new WarehousePage(authenticatedUser);
                warehousePage.Show();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials and try again.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
