﻿using System;
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

namespace pjdgatovka1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string symbols = "abcdefghijklmnopqrstuvwxyz";
        public int captchaLength = 5;
        public string captcha = "";
        public MainWindow()
        {
            InitializeComponent();
        }
     
        

     
        private void UpdateCaptcha()
        {
            var rnd = new Random();
            spCaptcha.Children.Clear();
            captcha = "";
            for (int i = 0; i < captchaLength; i++)
            {
                var sim= new TextBlock { Text = symbols[rnd.Next(0,symbols.Length)].ToString() };
                sim.RenderTransform = new RotateTransform(rnd.Next(-45 ,50));
                sim.FontSize = rnd.Next(20, 30);
                spCaptcha.Children.Add(sim);
                sim.Margin = new Thickness(10, 10, 10, 10);
                captcha += sim.Text;
            }
        }
        private void GenerateNoise()
        {
            var rnd = new Random();
            canvasNoise.Children.Clear();
            for (int i = 0; i < captchaLength; i++)
            {
                var elliple = new Ellipse();
                elliple.Fill = new SolidColorBrush(Color.FromArgb(105, 105, 0, 0));
                elliple.Width = rnd.Next(50, 150);
                elliple.Height = rnd.Next(50, 150);
                canvasNoise.Children.Add(elliple);
                Canvas.SetLeft(elliple, rnd.Next(10, 100));
            }
        }
       

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
            GenerateNoise();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tbCaptcha.Text == captcha)
            {
                Frame.Navigate(new Paginater.reg());
            }
            else
            {
                MessageBox.Show("неправильная", "неправильно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            tbCaptcha.Text = "";
           
        }
        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}


    


        
    

