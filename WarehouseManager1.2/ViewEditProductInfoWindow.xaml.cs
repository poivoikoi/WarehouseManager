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
    public partial class ViewEditProductInfoWindow : Window
    {
        // Assuming you have a reference to your data context (_dbContext)
        private readonly WarehouseDbContext _dbContext;
        private Product _selectedProduct;

        public ViewEditProductInfoWindow(Product selectedProduct, WarehouseDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;  // Initialize your data context
            _selectedProduct = selectedProduct;
            LoadProductInfo();
        }

        //public ViewEditProductInfoWindow(List<Product> selectedProducts)
        //{
        //}

        private void LoadProductInfo()
        {
            // Load the product information into the window
            ProductIdTextBlock.Text = _selectedProduct.ProductID.ToString();
            ProductNameTextBox.Text = _selectedProduct.ProductName;
            PriceTextBox.Text = _selectedProduct.Price.ToString();
            StockQuantityTextBox.Text = _selectedProduct.StockQuantity.ToString();
            DescriptionTextBox.Text = _selectedProduct.Description;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Update the product information in the database
                _selectedProduct.ProductName = ProductNameTextBox.Text;
                _selectedProduct.Price = decimal.Parse(PriceTextBox.Text);
                _selectedProduct.StockQuantity = int.Parse(StockQuantityTextBox.Text);
                _selectedProduct.Description = DescriptionTextBox.Text;

                _dbContext.SaveChanges();

                MessageBox.Show("Product information updated successfully.");

                this.Close(); // Close the window after saving changes
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving changes
            this.Close();
        }
    }
}
