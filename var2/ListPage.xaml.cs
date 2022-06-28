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
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        var2Entities context;
        public ListPage()
        {
            InitializeComponent();
            context = new var2Entities();
            paListViev.ItemsSource = context.ListAnalysisAndProcedure.ToList();
        }

        private void ClickListAP(object sender, MouseButtonEventArgs e)
        {
            ListAnalysisAndProcedure listAnalysisAndProcedure = (sender as Grid).DataContext as ListAnalysisAndProcedure;

            NavigationService.Navigate(new ElementAPPage(context, listAnalysisAndProcedure));

        }
    }
}
