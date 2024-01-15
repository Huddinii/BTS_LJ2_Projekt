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

namespace BTS_LJ2_Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Sidebar_Buttons.Visibility == System.Windows.Visibility.Collapsed)
            {
                Sidebar_Buttons.Visibility = System.Windows.Visibility.Visible;
                (sender as Button).Content = "<";
            }
            else
            {
                Sidebar_Buttons.Visibility = System.Windows.Visibility.Collapsed;
                (sender as Button).Content = ">";
            }
        }
    }
}
