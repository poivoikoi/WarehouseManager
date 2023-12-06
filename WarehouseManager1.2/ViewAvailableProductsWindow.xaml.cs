using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using Volo.Abp.Users;
using WarehouseManager1._2.Data;

namespace WarehouseManager1._2
{
    /// <summary>
    /// Логика взаимодействия для ViewAvailableProductsWindow.xaml
    /// </summary>
    public partial class ViewAvailableProductsWindow : Window
    {
        // Assuming you have a collection of products
        private ObservableCollection<Product> availableProducts;
        private User _currentUser;
        public ViewAvailableProductsWindow(User currentUser, ObservableCollection<Product> availableProducts)
        {
            InitializeComponent();

            _currentUser = currentUser;
            this.availableProducts = availableProducts;

            // Bind the product collection to the ListView
            productListView.ItemsSource = availableProducts;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            // Logic for adding the selected product to the cart
            // You can access the selected item in the ListView
            // For example: var selectedProduct = (Product)productListView.SelectedItem;

            // Perform the necessary logic based on the selected product
        }

        private void BackToWarehouse_Click(object sender, RoutedEventArgs e)
        {
            // Logic for navigating back to the Warehouse page
            // You might want to close this window and show the Warehouse page
            WarehousePage warehousePage = new WarehousePage(_currentUser);
            warehousePage.Show();
            this.Close();
        }
    }

    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] bytes)
            {
                return ByteArrayToBitmapImage(bytes);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private BitmapImage ByteArrayToBitmapImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            try
            {
                var image = new BitmapImage();
                using (var stream = new MemoryStream(bytes))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                }
                return image;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return null;
            }
        }
    }
}
