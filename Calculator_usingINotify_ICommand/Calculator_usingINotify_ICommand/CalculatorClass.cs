using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator_usingINotify_ICommand
{
    public class CalculatorClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string currentOperator;

        private double firstNumber;

        private double secondNumber;

        private string result;

        public string Result 
        { 
            get { return result; }
            set { result = value; PropertyChanged(this, new PropertyChangedEventArgs("Result")); } 
        }

        private RelayCommand _addCommandObj = null;

        public ICommand AddCommandObj
        {
            get { return _addCommandObj; }
        }

        private RelayCommand _subCommandObj = null;

        public ICommand SubCommandObj
        {
            get { return _subCommandObj; }
        }

        private RelayCommand _mulCommandObj = null;

        public ICommand MulCommandObj
        {
            get { return _mulCommandObj; }
        }

        private RelayCommand _divCommandObj = null;

        public ICommand DivCommandObj
        {
            get { return _divCommandObj; }
        }

        private RelayCommand _numCommandObj = null;

        public ICommand NumCommandObj
        {
            get { return _numCommandObj; }
        }

        private RelayCommand _clearCommandObj = null;

        public ICommand ClearCommandObj
        {
            get { return _clearCommandObj; }
        }

        private RelayCommand _equalCommandObj = null;

        public ICommand EqualCommandObj
        {
            get { return _equalCommandObj; }
        }

        private RelayCommand _dotCommandObj = null;

        public ICommand DotCommandObj
        {
            get { return _dotCommandObj; }
        }



        public CalculatorClass()
        {
            _numCommandObj = new RelayCommand(Button_Click_Numbers);
            _clearCommandObj = new RelayCommand(Button_Click_Clear);
            _equalCommandObj = new RelayCommand(Button_Click_Equal);
            _addCommandObj = new RelayCommand(Button_Click_Add);
            _subCommandObj = new RelayCommand(Button_Click_Sub);
            _mulCommandObj = new RelayCommand(Button_Click_Mul);
            _divCommandObj = new RelayCommand(Button_Click_Div);
            _dotCommandObj = new RelayCommand(Button_Click_Dot);
        }


        private void Button_Click_Numbers(object sender)
        {
            
            if (Result != "0")
            {
                Result += sender.ToString();
            }
            else
            {
                Result = sender.ToString();
            }
        }

        private void Button_Click_Clear(object sender)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentOperator = "";
            Result = "0";
        }

        private void Button_Click_Add(object sender)
        {
            currentOperator = "+";
            firstNumber = double.Parse(Result);
            Result = "0";
        }

        private void Button_Click_Equal(object sender)
        {
            secondNumber = double.Parse(Result);
            CalculateResult(firstNumber, currentOperator, secondNumber);
        }

        private void Button_Click_Sub(object sender)
        {
            currentOperator = "-";
            firstNumber = double.Parse(Result);
            Result = "0";
        }

        private void Button_Click_Mul(object sender)
        {
            currentOperator = "*";
            firstNumber = double.Parse(Result);
            Result = "0";
        }

        private void Button_Click_Div(object sender)
        {
            currentOperator = "/";
            firstNumber = double.Parse(Result);
            Result = "0";
        }

        private void Button_Click_Dot(object sender)
        {
            if (Result.IndexOf('.') < 0)
            {
                Result += ".";
            }
        }


        private void CalculateResult(double firstNumber, string currentOperator, double secondNumber)
        {
            if (currentOperator == "+")
            {
                Result = (firstNumber + secondNumber).ToString();
            }
            else if (currentOperator == "-")
            {
                Result = (firstNumber - secondNumber).ToString();
            }
            else if (currentOperator == "*")
            {
                Result = (firstNumber * secondNumber).ToString();
            }
            else if (currentOperator == "/")
            {
                Result = (firstNumber / secondNumber).ToString();
            }
            else
            {
                Result = "0";
            }
        }

    }
}
