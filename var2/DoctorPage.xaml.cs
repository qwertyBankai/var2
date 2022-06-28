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
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        var2Entities context;
        public DoctorPage()
        {
            InitializeComponent();
            context = new var2Entities();
            doctorTable.ItemsSource = context.Worker.ToList();

        }

        public void RefreshData()
        {
            var list = context.Worker.ToList();

            if (!string.IsNullOrWhiteSpace(fioBox.Text))
            {
                list = list.Where(x => x.fio.ToLower().Contains(fioBox.Text.ToLower())).ToList();

            }

            doctorTable.ItemsSource = list;

            if (!string.IsNullOrWhiteSpace(doctorBox.Text))
            {
                list = list.Where(x => x.TakePosition.ToLower().Contains(doctorBox.Text.ToLower())).ToList();
            }
            doctorTable.ItemsSource = list;
        }

        private void SearchByFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void SearchSpec(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void EditDoctor(object sender, RoutedEventArgs e)
        {
            Worker worker = doctorTable.SelectedItem as Worker;
            NavigationService.Navigate(new DoctorAddPage(context, worker));
        }

        private void GoDoctorPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorAddPage(context));
        }
    }
}
