using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComboBox_inMVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ComboBox_inMVVM.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> productsList;

        public ObservableCollection<Product> ProductsList
        {
            get { return productsList; }
            set { productsList = value;}
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChange("SelectedProduct"); }
        }

        public ProductViewModel()
        {
            ProductsList = new ObservableCollection<Product>()
            {
                new Product { ProductId = 1, ProductName = "TV", Category = "Electronics", Price = 500000 },
                new Product { ProductId = 2, ProductName = "Green tea", Category = "Tea", Price = 700 },
                new Product { ProductId = 3, ProductName = "Black tea", Category = "Tea", Price = 570.5 },
                new Product { ProductId = 4, ProductName = "Pudding", Category = "Desserts", Price = 1028.4 }
            };
        }
      

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
