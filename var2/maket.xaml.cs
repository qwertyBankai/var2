using System;
using System.Collections.Generic;
using System.Linq;
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

namespace var2
{
    /// <summary>
    /// Логика взаимодействия для maket.xaml
    /// </summary>
    public partial class maket : Page
    {
        public maket(Worker worker)
        {
            InitializeComponent();

            if(worker.idPosition == 1)
            {
                FormTwoBtn.Visibility = Visibility.Hidden;
            }

            if(worker.idPosition == 2 || worker.idPosition == 3 || worker.idPosition == 4)
            {
                ClientBtn.Visibility = Visibility.Hidden;
                DoctorBtn.Visibility = Visibility.Hidden;
            }

            frames.NavigationService.Navigate(new ClientPage());
        }

        private void GoClient(object sender, RoutedEventArgs e)
        {
            frames.NavigationService.Navigate(new ClientPage());
        }

        private void GoDoctor(object sender, RoutedEventArgs e)
        {
            frames.NavigationService.Navigate(new DoctorPage());

        }

        private void GoList(object sender, RoutedEventArgs e)
        {
            frames.NavigationService.Navigate(new ListPage());
        }

        private void GoFormOne(object sender, RoutedEventArgs e)
        {
            frames.NavigationService.Navigate(new FormOnePage());
        }

        private void GoFormTwo(object sender, RoutedEventArgs e)
        {
            frames.NavigationService.Navigate(new FormTwoPage());

        }
    }
}
