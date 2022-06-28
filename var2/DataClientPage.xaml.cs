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
    /// Логика взаимодействия для DataClientPage.xaml
    /// </summary>
    public partial class DataClientPage : Page
    {
        public DataClientPage(var2Entities context, patients pat)
        {
            InitializeComponent();
            DataClientTable.ItemsSource = context.Worker.ToList().Where(x=> x.TakeFioClientFromAppel.Contains(pat.fio)).ToList();
        }
    }
}
