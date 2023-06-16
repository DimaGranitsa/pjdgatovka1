using pjdgatovka1.model;
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
    /// Логика взаимодействия для MainPager.xaml
    /// </summary>
    public partial class MainPager : Page
    {
       
        int pageSize;
        int pageNumber;
        
        public MainPager()
        {
            InitializeComponent();
            RefreshButtons();
            InitializeComponent();
            RefreshPagination();
            DGWrites.ItemsSource = App.DecorEntities.tovar.ToList().Skip(pageNumber * 10).Take(10).ToList();
            RefreshButtons();
          
        }
       
        private void col_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BLeft_Click(object sender, RoutedEventArgs e)
        {
            if(pageNumber == 0)
            {
                return;
            }
            pageNumber--;
        }

        private void BRight_Click(object sender, RoutedEventArgs e)
        {
            if (App.DecorEntities.tovar.ToList().Count % 10 == 0)
            {
                if (pageNumber == (App.DecorEntities.tovar.ToList().Count / 10) - 1)
                    return;
            }
            else
            {
                if (pageNumber == (App.DecorEntities.tovar.ToList().Count / 10))
                    return;
            }
            pageNumber++;
            RefreshPagination();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            pageNumber = Convert.ToInt32(button.Content) - 1;
            RefreshPagination();
        }
        private void RefreshButtons()
        {
            WPButtons.Children.Clear();
            if (App.DecorEntities.tovar.ToList().Count % 10 == 0)
            {
                for (int i = 0; i < App.DecorEntities.tovar.ToList().Count / 10; i++)
                {
                    Button button = new Button();
                    button.Content = i + 1;
                    button.Click += Button_Click;
                    button.Margin = new Thickness(5);
                    button.Width = 20;
                    button.Height = 20;
                    button.FontSize = 14;
                    WPButtons.Children.Add(button);
                }
            }
            else {
                for (int i = 0; i < App.DecorEntities.tovar.ToList().Count / 10 +1; i++)
                {
                    Button button = new Button();
                    button.Content = i + 1;
                    button.Click += Button_Click;
                    button.Margin = new Thickness(5);
                    button.Width = 20;
                    button.Height = 20;
                    button.FontSize = 14;
                    WPButtons.Children.Add(button);
                }
            }

        }
        private void RefreshPagination()
        {
            DGWrites.ItemsSource = App.DecorEntities.tovar.OrderBy(x => x.Id).Skip(pageNumber * 10).Take(10).ToList();
        }

       

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGWrites.ItemsSource = App.DecorEntities.tovar.ToList().Where(z => z.Name.Contains(poisk.Text));
        }

        private void ufal_Click(object sender, RoutedEventArgs e)
        {
            var b = DGWrites.SelectedItem as tovar;
            if (b != null)
            {
                App.DecorEntities.tovar.Remove(b);
                App.DecorEntities.SaveChanges();

            }
            else
            {
                MessageBox.Show("net");
            }
            RefreshPagination();
        }
    }

    
}
