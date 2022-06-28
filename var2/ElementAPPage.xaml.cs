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
    /// Логика взаимодействия для ElementAPPage.xaml
    /// </summary>
    public partial class ElementAPPage : Page
    {
        var2Entities context;
        public ElementAPPage( var2Entities context, ListAnalysisAndProcedure listAnalysisAndProcedure)
        {
            InitializeComponent();
            this.context = context;
            elementTable.ItemsSource = context.ListAnalysisAndProcedure.ToList().Where(x=> x.id == listAnalysisAndProcedure.id).ToList();
        }
    }
}
