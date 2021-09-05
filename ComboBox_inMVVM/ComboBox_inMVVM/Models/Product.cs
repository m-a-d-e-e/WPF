using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBox_inMVVM.Models
{
    public class Product : INotifyPropertyChanged
    {
		private int productId;

		public int ProductId
		{
			get { return productId; }
			set { productId = value; OnPropertyChange("ProductId"); }
		}

		private string productName;

		public string ProductName
		{
			get { return productName; }
			set { productName = value; OnPropertyChange("ProductName"); }
		}

		private string category;

		public string Category
		{
			get { return category; }
			set { category = value; OnPropertyChange("Category"); }
		}

		private double price;

		public double Price
		{
			get { return price; }
			set { price = value; OnPropertyChange("Price"); }
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
