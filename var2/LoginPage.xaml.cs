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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        var2Entities context;
        public LoginPage()
        {
            InitializeComponent();
             context = new var2Entities();
        }

        private void GoLoginPage(object sender, RoutedEventArgs e)
        {

            int login = Convert.ToInt32(inputLogin.Text);
            string password = Convert.ToString(inputPassword.Text);

            if (context.Worker.Any(x => x.idWorker == login))
            {
                Worker worker = context.Worker.ToList().Find(x => x.idWorker == login);

                if (worker.password.Equals(inputPassword.Text))
                {
                    MessageBox.Show("Добро пожаловать");
                    inputPassword.Background = Brushes.Green;

                    NavigationService.Navigate(new maket(worker));
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль");
                }
            }
            else
            {
                MessageBox.Show("Неверный логин/пароль");
                inputPassword.Background = Brushes.Red;
            }

           

        }
    }
}
