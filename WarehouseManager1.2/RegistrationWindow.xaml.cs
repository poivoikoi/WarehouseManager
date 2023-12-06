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


// RegistrationWindow.xaml.cs

namespace WarehouseManager1._2
{
    public partial class RegistrationWindow : Window
    {
        private DataLayer _dataLayer;

        public RegistrationWindow()
        {
            InitializeComponent();
            _dataLayer = new DataLayer(); // Create an instance of YourDataLayer
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            if (password == confirmPassword)
            {
                // Call your data layer method to register the user
                // Replace YourDataLayer.RegisterUser with your actual registration method
                bool registrationSuccess = _dataLayer.RegisterUser(username, password);

                if (registrationSuccess)
                {
                    MessageBox.Show("Registration successful!");
                    this.Close();

                    User authenticatedUser = _dataLayer.GetUserByUsername(username); // Fetch the user details from the database
                    WarehousePage warehousePage = new WarehousePage(authenticatedUser);
                    warehousePage.Show();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please try again.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


