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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(people_number.Content) < 12)
            {
                int tmp = Convert.ToInt32(people_number.Content);
                tmp += 1;
                people_number.Content = Convert.ToString(tmp);
            }
            else { MessageBox.Show("Max number of people is 12 !!!", "Event", MessageBoxButton.OKCancel, MessageBoxImage.Information); }



        }

        public double getPrice()
        {
            int people_num = Convert.ToInt32(people_number.Content);
            int days = Convert.ToInt32(Data.SelectedDates.Count);
            if (types.Children.OfType<RadioButton>().Where(s => s.Content == "Econom" && s.IsChecked == true).Count() != null)
            {
                return Convert.ToDouble(20 * people_num * days * 0.8);
            }
            if (types.Children.OfType<RadioButton>().Where(s => s.Content == "Standart" && s.IsChecked == true).Count() != null)
            {
                return Convert.ToDouble(20 * people_num * days * 1.1);
            }
            if (types.Children.OfType<RadioButton>().Where(s => s.Content == "Luxe" && s.IsChecked == true).Count() != null)
            {
                return Convert.ToDouble(20 * people_num * days * 2.3);
            }
            return 0;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Name_To_Enter .Text= string.Empty;
            Surname_To_Enter.Text = string.Empty;
            contact_info.Text = "Contact information here";
            foreach (var i in types.Children.OfType<RadioButton>()) {i.IsChecked = false;}
            people_number.Content = "1";
            Data.SelectedDates.Clear();
            accepted_terms.IsChecked = false;
            acceptBtn.IsEnabled = false;
        }

        private void moreBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(people_number.Content) < 12)
            {
                int tmp = Convert.ToInt32(people_number.Content);
                tmp += 1;
                people_number.Content = Convert.ToString(tmp);
            }
            else { MessageBox.Show("Max number of people is 12 !!!", "Event", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void lessBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(people_number.Content) > 1)
            {
                int tmp = Convert.ToInt32(people_number.Content);
                tmp -= 1;
                people_number.Content = Convert.ToString(tmp);
            }
            else { MessageBox.Show("Number of people cannot be less than 1 !!!", "Event", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void accepted_terms_Click(object sender, RoutedEventArgs e)
        {
            if(accepted_terms.IsChecked == true)
            {
                acceptBtn.IsEnabled = true;
            }
            else { acceptBtn.IsEnabled = false; }
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            string a = Convert.ToString(types.Children.OfType<RadioButton>().First(s => s.IsChecked == true).Content);
            MessageBox.Show(@$"
            Name : {Name_To_Enter.Text}
            Surname : {Surname_To_Enter.Text}
            Class : {a}
            Duration : {Data.SelectedDates.Count}
            Number of people : {people_number.Content}
                        Total price : {getPrice()}");
        }
    }
}
