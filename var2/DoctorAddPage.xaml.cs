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
    /// Логика взаимодействия для DoctorAddPage.xaml
    /// </summary>
    public partial class DoctorAddPage : Page
    {
        var2Entities context;
        bool flag;
        public DoctorAddPage(var2Entities cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }

        Worker wor;

        public DoctorAddPage(var2Entities cont, Worker worker)
        {
            InitializeComponent();
            context = cont;
            wor = worker;

            fioBox.Text = wor.fio;
            doctorBox.Text = wor.TakePosition;
            flag = false;
        }

        private void AddNewDoctor(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                Worker worker = new Worker()
                {
                    fio = Convert.ToString(fioBox.Text),
                    idPosition = Convert.ToInt32(doctorBox.Text),
                    password = passBox.Text,
                    //???
                    idAppel = 1,
                    idReception = 1,
                    idTimeTable = 1
                    //???
                };
                context.Worker.Add(worker);
                context.SaveChanges();

                NavigationService.Navigate(new DoctorPage());
            }
            else
            {
                context.Worker.Find(wor.idWorker).fio = fioBox.Text;
                context.Worker.Find(wor.idWorker).idPosition = Convert.ToInt32(doctorBox.Text);
                context.SaveChanges();
                NavigationService.Navigate(new DoctorPage());
            }

        }



       


    }
}
