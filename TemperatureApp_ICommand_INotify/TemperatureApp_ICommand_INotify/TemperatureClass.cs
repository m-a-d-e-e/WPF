using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TemperatureApp_ICommand_INotify
{
    public class TemperatureClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Fields and Properties 

        private double tempValue;

        public double TempValue
        {
            get { return tempValue; }
            set { tempValue = value; PropertyChanged(this, new PropertyChangedEventArgs("TempValue")); }
        }

        private double celsiusValue;
        public double CelsiusValue
        {
            get { return celsiusValue; }
            set { celsiusValue = value; PropertyChanged(this, new PropertyChangedEventArgs("CelsiusValue")); }
        }

        private double fahreValue;
        public double FahreValue
        {
            get { return fahreValue; }
            set { fahreValue = value; PropertyChanged(this, new PropertyChangedEventArgs("FahreValue")); }
        }

        #endregion



        #region Command Fields and Properties 

        private RelayCommand _toCelsiusObj = null;

        public ICommand ToCelsiusObj
        {
            get { return _toCelsiusObj; }
        }

        private RelayCommand _toFahreObj = null;

        public ICommand ToFahreObj
        {
            get { return _toFahreObj; }
        }

        #endregion

        #region Constructor and Methods

        public TemperatureClass()
        {
            _toCelsiusObj = new RelayCommand(Convert_FtoC);
            _toFahreObj = new RelayCommand(Convert_CtoF);
        }

        public void Convert_CtoF(object obj)
        {
            FahreValue = ((TempValue * 1.8) + 32);
        }

        public void Convert_FtoC(object obj)
        {
            CelsiusValue = ((TempValue - 32) * 0.5556);
        }

        #endregion

    }
}
