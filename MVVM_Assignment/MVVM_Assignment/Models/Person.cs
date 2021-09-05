using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Assignment.Models
{
    public class Person : INotifyPropertyChanged
    {
		private int personId;

		public int PersonId
		{
			get { return personId; }
			set { personId = value; OnPropertyChanged("PersonId"); }
		}

		private string personName;

		public string PersonName
		{
			get { return personName; }
			set { personName = value; OnPropertyChanged("PersonName"); }
		}

		private long mobileNo;

		public long MobileNo
		{
			get { return mobileNo; }
			set { mobileNo = value; OnPropertyChanged("MobileNo"); }
		}


		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
