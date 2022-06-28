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
    /// Логика взаимодействия для FormTwoPage.xaml
    /// </summary>
    public partial class FormTwoPage : Page
    {
        var2Entities context;
        public FormTwoPage()
        {
            InitializeComponent();
            context = new var2Entities();

            specCombo.ItemsSource = context.ListPositions.ToList();
        }

        private void ClickFormOne(object sender, RoutedEventArgs e)
        {

            int idMaxList = context.ListAnalysisAndProcedure.Max(x => x.id);

            ListAnalysisAndProcedure listAnalysisAndProcedure = new ListAnalysisAndProcedure()
            {
                id = idMaxList + 1,
                title = titleBox.Text,
                price = Convert.ToDecimal(priceBox.Text),
                image = null,
                description = descBox.Text
            };
            context.ListAnalysisAndProcedure.Add(listAnalysisAndProcedure);
            context.SaveChanges();
        }

        private void ClickFormTwo(object sender, RoutedEventArgs e)
        {
            int maxIdReception = context.Reception.Max(x => x.idReception);

            Reception reception = new Reception
            {
                idReception = maxIdReception + 1,
                noteOfInspection = " ",
                date = Convert.ToDateTime(dateBox.Text),
                time = TimeSpan.FromHours(Convert.ToDouble(timeBox.Text))
            };

            context.Reception.Add(reception);
            context.SaveChanges();
        }
    }
}
