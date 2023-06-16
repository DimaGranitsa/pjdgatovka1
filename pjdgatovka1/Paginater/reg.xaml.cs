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

namespace pjdgatovka1.Paginater
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Page
    {
        public reg()
        {
            InitializeComponent();
        }

        private void regп_Click(object sender, RoutedEventArgs e)
        {
            model.User q = new model.User()
            {
              Name = log.Text,
              pass = pass.Text,     
            };
            App.DecorEntities.User.Add(q);
            App.DecorEntities.SaveChanges();
               
        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(login.Text)&& string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("пустые поля");

            }
            else
            {
             var bd = App.DecorEntities.User.Where(z=> z.Name == login.Text || z.pass == password.Text).FirstOrDefault();
                if (bd.Id == 1)
                {
                    Frame.Navigate(new Paginater.MainPager());
                    MessageBox.Show($"дабро пожаловать{bd.Name}");
                }
                if (bd.Id == 2)
                {
                    Frame.Navigate(new Paginater.MainPager());
                    MessageBox.Show($"дабро пожаловать{Name}");
                }
            }
            
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
