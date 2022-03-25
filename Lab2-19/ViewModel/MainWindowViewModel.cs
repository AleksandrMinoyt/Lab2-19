using Lab2_19.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2_19.ViiwModel
{
    class MainWindowViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string parseString;
        private double numberResult;


        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        public string ParseString
        {
            get => parseString;
            set
            {
                parseString = value;
                OnPropertyChanged();
            }
        }


        public double NumberResult
        {
            get => numberResult;
            set
            {
                numberResult = value;
                OnPropertyChanged();
            }
        }


        public ICommand CalcCommand { get; }

        public ICommand ButtonCommand { get; }
        public ICommand ClearSymbolCommand { get; }
        public ICommand ClearAllCommand { get; }
        public ICommand KvadCommand { get; }

        private void OnKvadCommandExecute(object p)
        {
            NumberResult = Math.Pow(Convert.ToDouble(ParseString), 2);
        }

        private bool CanKvadCommandExecute(object p)
        {
            try
            {
                if (ParseString?.Length > 0)
                {
                    ParseString = ParseString.Replace(".", ",");
                    Convert.ToDouble(ParseString);
                   
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        private void OnClearAllCommandExecute(object p)
        {

            ParseString = "";
        }

        private bool CanClearAllCommandExecute(object p)
        {
            if (ParseString != "" && !(ParseString is null))
                return true;
            return false;
        }



        private void OnClearSymbolCommandExecute(object p)
        {

            ParseString = ParseString.Substring(0, ParseString.Length - 1);
        }

        private bool CanClearSymbolCommandExecute(object p)
        {
            if (ParseString != "" && !(ParseString is null))
                return true;
            return false;
        }


        private void OnButtonCommandExecute(object p)
        {
            ParseString += (string)p;
        }

        private bool CanButtonCommandExecute(object p)
        {
            return true;
        }

        private void OnCalcCommandExecute(object p)
        {
            NumberResult = ParseInputString(ParseString);
        }

        private double ParseInputString(string str)
        {
            DataTable dt = new DataTable();

            try 
            {
                return Convert.ToDouble(dt.Compute(str, ""));
            }
            catch
            {
                return 0;
            }
           
        }

        private bool CanCalcCommandExecute(object p)
        {
            // Проверка на пустоту строки... Тут можно дописать парсер корректности строки.

            if (ParseString != "" && !(ParseString is null))
                return true;
            return false;
        }

        public MainWindowViewModel()
        {
            CalcCommand = new RelayCommand(OnCalcCommandExecute, CanCalcCommandExecute);
            ButtonCommand = new RelayCommand(OnButtonCommandExecute, CanButtonCommandExecute);
            ClearSymbolCommand = new RelayCommand(OnClearSymbolCommandExecute, CanClearSymbolCommandExecute);
            ClearAllCommand = new RelayCommand(OnClearAllCommandExecute, CanClearAllCommandExecute);
            KvadCommand = new RelayCommand(OnKvadCommandExecute, CanKvadCommandExecute);


        }
    }
}


