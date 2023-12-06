using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// <summary>
    /// Логика взаимодействия для AddProductToDatabaseWindow.xaml
    /// </summary>
    public partial class AddProductToDatabaseWindow : Window
    {
        private WarehouseDbContext _dbContext = new WarehouseDbContext();
        public AddProductToDatabaseWindow()
        {
            InitializeComponent();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            // Use OpenFileDialog to allow the user to choose an image file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*",
                Title = "Select an Image File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Set the selected image path to the ImagePathTextBox
                ImagePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Logic for adding a product to the database
            string productName = ProductNameTextBox.Text;
            decimal price = decimal.Parse(PriceTextBox.Text); // Handle parsing errors appropriately
            int stockQuantity = int.Parse(StockQuantityTextBox.Text); // Handle parsing errors appropriately
            string description = DescriptionTextBox.Text;
            string imagePath = ImagePathTextBox.Text;

            if (imagePath == string.Empty)
            {
                MessageBox.Show("The image cannot be empty.");
                this.Close();
            }
            else
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    // Create a new Product instance and add it to the database
                    Product newProduct = new Product
                    {
                        ProductName = productName,
                        Price = price,
                        StockQuantity = stockQuantity,
                        Description = description,
                        Image = imageBytes
                    };

                    _dbContext.Products.Add(newProduct);
                    _dbContext.SaveChanges();

                    DataContext = new ObservableCollection<Product>(_dbContext.Products.ToList());

                    MessageBox.Show("Product added successfully!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("The database has not been updated.");
                    this.Close();
                }
                
            }
        }

        private void ImagePathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
