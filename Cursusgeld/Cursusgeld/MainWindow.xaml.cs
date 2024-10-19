using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cursusgeld
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
        
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void testNumeriekTextBox_Click(object sender, RoutedEventArgs e)
        {
            string input = yearTextBox.Text;
            int year;

            bool isValideYear = int.TryParse(input, out year);

            if (isValideYear)
            {
                isNumeriekLabel.Content = "Is numeriek";
            }
            else
            {
                isNumeriekLabel.Content = "Geef een correct jaartal!";
            }
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(yearTextBox.Text, out int year))
            {
                bool isSchrikkeljaar = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);


                string input = lesHoursTextBox.Text;
                int lesHours = int.Parse(input);

                if (isSchrikkeljaar)
                {
                    isSchrikkelJaarLabel.Content = "Is een schikkeljaar";
                    lesHours += 1;
                }
                else
                {
                    isSchrikkelJaarLabel.Content = "Is geen schrikkeljaar";
                }


                

                const double euroPerHour = 1.5;

                double priceSchrikkelJaar = lesHours * euroPerHour ;
                double priceNotSchrikkelJaar = lesHours * euroPerHour;


                if (isSchrikkeljaar)
                {
                    registrationFeeTextBox.Text = priceSchrikkelJaar.ToString();
                }
                else
                {
                    registrationFeeTextBox.Text = priceNotSchrikkelJaar.ToString();
                }
            }
            
        }
        private void yearTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isNumeriekLabel.Content = "";
        }
    }
}