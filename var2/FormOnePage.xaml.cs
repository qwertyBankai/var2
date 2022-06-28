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
    /// Логика взаимодействия для FormOnePage.xaml
    /// </summary>
    public partial class FormOnePage : Page
    {
        var2Entities context;
        public FormOnePage()
        {
            InitializeComponent();
            context = new var2Entities();
        }

        private void FormAppeal(object sender, RoutedEventArgs e)
        {
            decimal oms = Convert.ToDecimal(omsBox.Text);
            string fio = fioBox.Text;

            int maxIdAppeal = context.Appel.Max(x => x.idAppel);
            int maxIdReception = context.Reception.Max(x => x.idReception);


            if (context.patients.Any(x=> x.oms == oms))
            {
                if(context.patients.Any(x => x.fio == fio))
                {
                    /**/

                    Appel appel = new Appel()
                    {
                        idAppel = maxIdAppeal + 1,
                        complaint = appealBox.Text,
                        omsPatient = oms,
                    };
                    context.Appel.Add(appel);
                    context.SaveChanges();

                    string i = DateTime.Now.AddDays(5).ToShortDateString();

                    Reception reception = new Reception
                    {
                      
                        idReception = maxIdReception + 1,
                        noteOfInspection = " ",
                        date = Convert.ToDateTime(i),
                        time = TimeSpan.FromHours(8)
                    };

                    context.Reception.Add(reception);
                    context.SaveChanges();

                    MessageBox.Show("Дата и время вашего приема " + reception.date + " " + reception.time);
                }
            }
            else
            {
                patients pat = new patients()
                {
                    oms = Convert.ToDecimal(omsBox.Text),
                    fio = fioBox.Text,
                    seriesAndNumberPassword = passportBox.Text,
                    phone = phoneBox.Text
                };
                context.patients.Add(pat);
                context.SaveChanges();

                Appel appel = new Appel()
                {
                    idAppel = maxIdAppeal + 1,
                    complaint = appealBox.Text,
                    omsPatient = oms,
                };
                context.Appel.Add(appel);
                context.SaveChanges();
            }
        }
    }
}
