using Lab2_19.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private int number1;
        private int number2;
        private int numberSum;

        private double radius;
        private double lenCricle;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        public int Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }
        public int Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }

        public int NumberSum
        {
            get => numberSum;
            set
            {
                numberSum = value;
                OnPropertyChanged();
            }
        }

        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        public double LenCricle
        {
            get => lenCricle;
            set
            {
                lenCricle = value;
                OnPropertyChanged();
            }
        }


        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            NumberSum = Ariph.Add(Number1, Number2);
        }

        private bool CanAddCommandExecute(object p)
        {
            if (number1 != 0 || number2 != 0)
                return true;
            else
                return false;
        }

        public ICommand LenFromRadiusCommand { get; }

        private void OnLenFromRadius(object p)
        {
            LenCricle = Ariph.LenFromRadius(Radius);
        }

        private bool CanLenFromRadius(object p)
        {
            if (radius != 0)
                return true;
            else
                return false;
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecute);
            LenFromRadiusCommand = new RelayCommand(OnLenFromRadius, CanLenFromRadius);
        }
    }
}


