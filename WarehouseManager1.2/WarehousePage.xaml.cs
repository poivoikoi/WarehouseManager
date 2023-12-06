using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseManager1._2.Data;
using User = WarehouseManager1._2.Data.User;

namespace WarehouseManager1._2
{
    public partial class WarehousePage : Window
    {
        private User _currentUser;
        private WarehouseDbContext _dbContext = new WarehouseDbContext();
        private WarehouseViewModel _viewModel; 

        public WarehousePage()
        {
            InitializeComponent();
        }
        public WarehousePage(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _viewModel = new WarehouseViewModel();
            DataContext = _viewModel;


            if (user.UserType == "Administrator")
            {
                AdminPanel.Visibility = Visibility.Visible;
            }
            else if (user.UserType == "Buyer")
            {
                BuyerPanel.Visibility = Visibility.Visible;
            }

            _viewModel.UserInfo = $"User: {user.Username}, UserType: {user.UserType}";
            _viewModel.Products = new ObservableCollection<Product>(_dbContext.Products.ToList());
            _viewModel.Numerators = new ObservableCollection<Numerator>(_dbContext.Numerators.ToList());
            _viewModel.NumeratorAllocations = new ObservableCollection<NumeratorAllocation>(_dbContext.NumeratorAllocations.ToList());

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Close();
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void ViewCart_Click(object sender, RoutedEventArgs e)
        {

            ViewCartWindow viewCartWindow = new ViewCartWindow(_currentUser);
            viewCartWindow.Show();
        }

        private void AddProductToDatabase_Click(object sender, RoutedEventArgs e)
        {
            var firstNumerator = _viewModel.Numerators.FirstOrDefault();
            if (firstNumerator != null)
            {
                firstNumerator.CurrentValue += 1;
                // Update the database
                _dbContext.SaveChanges();
                // Notify UI
                _viewModel.LoadNumerators();
            }
            var addProductToDatabaseWindow = new AddProductToDatabaseWindow();
            addProductToDatabaseWindow.ShowDialog();
            _viewModel.Products = new ObservableCollection<Product>(_dbContext.Products.ToList());
        }

        private void DeleteProductFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProducts = productListView.SelectedItems.Cast<Product>().ToList();

                if (selectedProducts.Count == 0)
                {
                    MessageBox.Show("No products selected.");
                    return;
                }

                foreach (var selectedProduct in selectedProducts)
                {
                    _dbContext.Products.Remove(selectedProduct);
                }

                _dbContext.SaveChanges();
                _viewModel.Products = new ObservableCollection<Product>(_dbContext.Products.ToList());

                MessageBox.Show($"{selectedProducts.Count} products deleted from the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting products from the database: {ex.Message}");
            }
        }

        private void ViewEditProductInfo_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducts = productListView.SelectedItems.Cast<Product>().ToList();

            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("No products selected.");
                return;
            }

            if (selectedProducts.Count > 1)
            {
                MessageBox.Show("Only one product can be selected.");
                return;
            }

            Product selectedProduct = selectedProducts[0];
            ViewEditProductInfoWindow viewEditProductInfoWindow = new ViewEditProductInfoWindow(selectedProduct, _dbContext);
            viewEditProductInfoWindow.Show();
        }

        private void AddSelectedToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProducts = productListView.SelectedItems.Cast<Product>().ToList();

                if (selectedProducts.Count == 0)
                {
                    MessageBox.Show("No products selected.");
                    return;
                }

                int userId = _currentUser.UserID;
                foreach (var selectedProduct in selectedProducts)
                {
                    if (!_dbContext.Carts.Any(c => c.UserID == userId && c.ProductID == selectedProduct.ProductID))
                    {
                        var cartItem = new Cart
                        {
                            UserID = userId,
                            ProductID = selectedProduct.ProductID,
                            Quantity = 1
                        };

                        _dbContext.Carts.Add(cartItem);
                    }
                }

                _dbContext.SaveChanges();

                MessageBox.Show($"{selectedProducts.Count} products added to the cart.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding products to the cart: {ex.Message}");
            }
        }

        private void ViewAvailableProducts_Click(object sender, RoutedEventArgs e)
        {
            ViewAvailableProductsWindow viewAvailableProductsWindow = new ViewAvailableProductsWindow(_currentUser, _viewModel.Products);
            viewAvailableProductsWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }
    }
}
