using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        internal SQLManual sqlM;
        internal User usr;
        internal SQLAuto sqlA;
        internal ObservableCollection<Restaurant> restaurants = new ObservableCollection<Restaurant>();
        public MainWindow()
        {
            InitializeComponent();
            sqlM = new SQLManual();
            sqlA = new SQLAuto();
        }

        private void Sidebar_Click(object sender, RoutedEventArgs e)
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

        private void Registrieren(object sender, RoutedEventArgs e)
        {
            string[] Fields = {"Username", "Password", "Name", "Lastname"};
            string[] Values = { $"{registerUsername.Text}", $"{registerPassword.Password}", $"{registerName.Text}", $"{registerLastname.Text}" };
            sqlM.Insert("User",Fields,Values);
            Login.Visibility = System.Windows.Visibility.Hidden;
            Register.Visibility = System.Windows.Visibility.Hidden;
            Content.Visibility = System.Windows.Visibility.Visible;
            FillChoices();

        }

        private void gotoRegister(object sender, RoutedEventArgs e)
        {
            Login.Visibility = System.Windows.Visibility.Hidden;
            Register.Visibility = System.Windows.Visibility.Visible;
        }

        private void clickLogin(object sender, RoutedEventArgs e)
        {
            if (sqlM.Login($"{loginUsername.Text}", $"{loginPassword.Password}"))
            {
                Login.Visibility = System.Windows.Visibility.Hidden;
                Register.Visibility = System.Windows.Visibility.Hidden;
                Content.Visibility = System.Windows.Visibility.Visible;
                FillChoices();
            }
            else
            {
                loginError.Content = "Einloggen fehlgeschlegen bitte Prüfen \n Sie ihre Daten und versuchen es erneut";
            }
        }

        private void FillChoices()
        {
            sqlA.getData();
        }

        private void wählen(object sender, RoutedEventArgs e)
        {

        }
    }
}
