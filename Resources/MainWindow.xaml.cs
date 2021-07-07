using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Resources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string someText;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name=null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public string SomeText
        {
            get { return someText; }
            set
            {
                someText = value;
                OnPropertyChanged();
            }
        }

        public Car MyCar { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            //SomeText = "Hakuna";

            MyCar = new Car
            {
                Model = "X7",
                Vendor = "BMW",
                Year = 2021
            };

            Cars = new ObservableCollection<Car>
            {
                new Car
                {
                    Model="X5",
                    Vendor="BMW",
                    Year=2020
                },
                new Car
                {
                    Model="E-200",
                    Vendor="Mercedes",
                    Year=2020
                },
                new Car
                {
                    Model="Cruze 2LT",
                    Vendor="Chevrolet",
                    Year=2010
                },
            };

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyCar.Model = "Chevrolet";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["PrimaryColor"] = Brushes.DeepPink;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush();

            gradientBrush.GradientStops.Add(new GradientStop
            {
                Color = Colors.Blue,
                Offset = 0.0
            });
            gradientBrush.GradientStops.Add(new GradientStop
            {
                Color = Colors.Yellow,
                Offset = 1.0
            });

            this.Resources["SpecialColor"] = gradientBrush;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = new Info();
            info.InfoCar = (sender as ListBox).SelectedItem as Car;
            info.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car
            {
                Model = "LaFerrari",
                Vendor = "Ferrari",
                Year = 2020
            };
            Cars.Add(car);
        }
    }
}
