using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WarehouseManager1._2.Data;

namespace WarehouseManager1._2
{
    public partial class ViewCartWindow : Window
    {
        // Assuming you have a reference to your data context (_dbContext)
        private readonly WarehouseDbContext _dbContext;
        private User _currentUser;

        public ViewCartWindow(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            _dbContext = new WarehouseDbContext(); // Initialize your data context
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            // Assuming _currentUser is the current user
            int userId = _currentUser.UserID; // Change this based on your actual User model

            // Load cart items for the current user
            var cartItems = _dbContext.Carts
                .Where(c => c.UserID == userId)
                .Select(c => new
                {
                    c.CartID,
                    c.Quantity,
                    Product = new
                    {
                        c.Product.ProductID,
                        c.Product.ProductName,
                        c.Product.Price,
                        c.Product.Image
                    }
                })
                .ToList();

            // Bind the cart items to the ListView
            cartListView.ItemsSource = cartItems;
        }

        private void RemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the CartID from the button's Tag
                if (sender is Button button && button.Tag is int cartId)
                {
                    // Find the cart item
                    var cartItem = _dbContext.Carts.Find(cartId);

                    if (cartItem != null)
                    {
                        // Remove the item from the database
                        _dbContext.Carts.Remove(cartItem);
                        _dbContext.SaveChanges();

                        // Reload cart items
                        LoadCartItems();

                        MessageBox.Show("Product removed from the cart.");
                    }
                    else
                    {
                        MessageBox.Show("Cart item not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing product from the cart: {ex.Message}");
            }
        }

        private void BackToWarehouse_Click(object sender, RoutedEventArgs e)
        {
            // Logic for navigating back to the Warehouse page
            // You might want to close this window and show the Warehouse page
            //WarehousePage warehousePage = new WarehousePage(_currentUser);
            //warehousePage.Show();
            this.Close();
        }
    }
}
