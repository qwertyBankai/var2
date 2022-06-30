using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        var2Entities context;
        public ClientPage()
        {
            InitializeComponent();
            context = new var2Entities();


            clientTable.ItemsSource = context.patients.ToList();
            Downloadpict();

        }

        public void RefreshData()
        {
            var list = context.patients.ToList();

            if (!string.IsNullOrWhiteSpace(fioBox.Text))
            {
                list = list.Where(x => x.fio.ToLower().Contains(fioBox.Text.ToLower())).ToList();

            }

            clientTable.ItemsSource = list;

            if (!string.IsNullOrWhiteSpace(omsBox.Text))
            {
                list = list.Where(x => x.oms.ToString().Contains(omsBox.Text)).ToList();
            }
            clientTable.ItemsSource = list;
        }


        private void GoClientPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientAddPage(context));
        }

        private void SearchByFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }


        private void EditClient(object sender, RoutedEventArgs e)
        {
            patients pat = clientTable.SelectedItem as patients;

            NavigationService.Navigate(new ClientAddPage(context, pat));

        }

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                   patients pats = clientTable.SelectedItem as patients;
                    context.patients.Remove(pats);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка при удалении");
                }
            }
        }

        private void SearchOms(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        public void Downloadpict()
        {
            var2Entities test = new var2Entities();
            foreach (var item in test.ListAnalysisAndProcedure.ToList())
            {
                item.image = File.ReadAllBytes(@"C:\Users\c1own\Desktop\Новая папка\var2\var2\Resousre\" + item.id + ".jpg");
            }
            test.SaveChanges();
        }

        private void ClickToDataClient(object sender, MouseButtonEventArgs e)
        {
            patients pat = clientTable.SelectedItem as patients;

            NavigationService.Navigate(new DataClientPage(context, pat));
        }
    }
}
