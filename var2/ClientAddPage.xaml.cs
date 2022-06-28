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
    /// Логика взаимодействия для ClientAddPage.xaml
    /// </summary>
    public partial class ClientAddPage : Page
    {
        var2Entities context;
        public ClientAddPage(var2Entities cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }
        bool flag;
        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                patients pat = new patients()
                {
                    oms = Convert.ToDecimal(omsBox.Text),
                    fio = fioBox.Text,
                    seriesAndNumberPassword = Convert.ToString(passportBox.Text),
                    phone = Convert.ToString(phoneBox.Text),
                };
                context.patients.Add(pat);
                context.SaveChanges();

                NavigationService.Navigate(new ClientPage());
            }
            else
            {
                context.patients.Find(pats.oms).fio = fioBox.Text;
                context.patients.Find(pats.oms).seriesAndNumberPassword = passportBox.Text;
                context.patients.Find(pats.oms).phone = phoneBox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new ClientPage());
            }
           
        }



        patients pats;
        public ClientAddPage(var2Entities cont, patients pat)
        {
            InitializeComponent();
            context = cont;
            pats = pat;
            omsBox.Text = Convert.ToString(pat.oms);
            fioBox.Text = pat.fio;
            passportBox.Text = pat.seriesAndNumberPassword;
            phoneBox.Text = pat.phone;
            flag = false;
        }

    }
}
