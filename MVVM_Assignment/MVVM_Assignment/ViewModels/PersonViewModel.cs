using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVM_Assignment.Models;
using MVVM_Assignment.Commands;

namespace MVVM_Assignment.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {

		private ObservableCollection<Person> _PersonList;

		public ObservableCollection<Person> PersonsList
		{
			get { return _PersonList; }
			set { _PersonList = value; }
		}

		public Person SelectedPerson
		{
			set
			{
				if (value != null)
				{
					PersonId = value.PersonId;
					PersonName = value.PersonName;
					MobileNo = value.MobileNo;					
				}
			}
		}

		public PersonViewModel()
		{
			PersonsList = new ObservableCollection<Person>();
			
			_addPersonCmd = new RelayCommand(Add, CanAdd);
			_delPersonCmd = new RelayCommand(Delete, CanDelete);
			_updPersonCmd = new RelayCommand(Update, CanUpdate);
			_searchPersonCmd = new RelayCommand(Search, CanSearch);
		}

		#region Properties of Person

		private Person domObject = new Person();

		public int PersonId
		{
			get { return domObject.PersonId; }
			set { domObject.PersonId = value; OnPropertyChanged("PersonId"); }
		}

		public string PersonName
		{
			get { return domObject.PersonName; }
			set { domObject.PersonName = value; OnPropertyChanged("PersonName"); }
		}

		public long MobileNo
		{
			get { return domObject.MobileNo; }
			set { domObject.MobileNo = value; OnPropertyChanged("MobileNo"); }
		}

		#endregion

		#region relaycommand

		private ICommand _addPersonCmd;  

		public ICommand AddPersonCmd   
		{
			get { return _addPersonCmd; }
			set { _addPersonCmd = value; }
		}

		private ICommand _delPersonCmd;  

		public ICommand DelPersonrCmd   
		{
			get { return _delPersonCmd; }
			set { _delPersonCmd = value; }
		}

		private ICommand _updPersonCmd;  

		public ICommand UpdPersonCmd   
		{
			get { return _updPersonCmd; }
			set { _updPersonCmd = value; }
		}

		private ICommand _searchPersonCmd;

		public ICommand SearchPersonCmd
		{
			get { return _searchPersonCmd; }
			set { _searchPersonCmd = value; }
		}

		public bool CanAdd(object obj)
		{
			if (PersonId != 0 && PersonName != null && MobileNo.ToString().Length==10)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Add(object obj)
		{
			Person person = new Person();
			person.PersonId = PersonId;
			person.PersonName = PersonName;
			person.MobileNo = MobileNo;
			_PersonList.Add(person);
			MessageBox.Show("Person Added successfully !");
		}

		public bool CanDelete(object obj)
		{
			if (_PersonList.Count != 0 && PersonId!=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Delete(object obj)
		{
			Person person = (from s in _PersonList where s.PersonId == Convert.ToInt32(obj) select s).FirstOrDefault();
			if (person != null)
			{
				_PersonList.Remove(person);
				MessageBox.Show("Person removed successfully");
			}
			else
			{
				MessageBox.Show("No such person exists");
			}

		}

		public bool CanUpdate(object obj)
		{
			if (PersonId != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}

		public void Update(object obj)
		{
			Person person = (from s in _PersonList where s.PersonId == Convert.ToInt32(obj) select s).FirstOrDefault();
			if (person != null)
			{
				person.PersonId = PersonId;
				person.PersonName = PersonName;
				person.MobileNo = MobileNo;
			}
			else
			{
				MessageBox.Show("No person with id " + obj.ToString() +" exists");
			}

		}

		public bool CanSearch(object obj)
		{
			if (PersonId != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Search(object obj)
		{
			Person person = (from s in _PersonList where s.PersonId == Convert.ToInt32(obj) select s).FirstOrDefault();
			if (person != null)
			{
				PersonId = person.PersonId;
				PersonName = person.PersonName;
				MobileNo = person.MobileNo;
			}
			else
			{
				MessageBox.Show("No person with id " + obj.ToString() + " exists");
			}

		}


		#endregion

		#region INotify implementation
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
        #endregion
    }
}
