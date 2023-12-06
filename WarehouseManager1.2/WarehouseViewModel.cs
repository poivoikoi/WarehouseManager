using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WarehouseManager1._2.Data;

namespace WarehouseManager1._2
{
    public class WarehouseViewModel : INotifyPropertyChanged
    {
        private WarehouseDbContext _dbContext = new WarehouseDbContext();
        private ObservableCollection<Product> _products;
        private ObservableCollection<Numerator> _numerators;
        private ObservableCollection<NumeratorAllocation> _numeratorAllocations;
        private string _userInfo;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<Numerator> Numerators
        {
            get { return _numerators; }
            set
            {
                _numerators = value;
                OnPropertyChanged(nameof(Numerators));
            }
        }

        public ObservableCollection<NumeratorAllocation> NumeratorAllocations
        {
            get { return _numeratorAllocations; }
            set
            {
                _numeratorAllocations = value;
                OnPropertyChanged(nameof(NumeratorAllocations));
            }
        }

        public string UserInfo
        {
            get { return _userInfo; }
            set
            {
                _userInfo = value;
                OnPropertyChanged(nameof(UserInfo));
            }
        }

        public WarehouseViewModel()
        {
            LoadData();
        }

        public void LoadNumerators()
        {
            Numerators = new ObservableCollection<Numerator>(_dbContext.Numerators.ToList());
        }

        private void LoadData()
        {
            _products = new ObservableCollection<Product>(_dbContext.Products.ToList());
            _numerators = new ObservableCollection<Numerator>(_dbContext.Numerators.ToList());
            _numeratorAllocations = new ObservableCollection<NumeratorAllocation>(_dbContext.NumeratorAllocations.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
