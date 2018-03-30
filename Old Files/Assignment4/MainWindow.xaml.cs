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

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxTextBox_PostalCode.Focus();
        }

        private void uxTextBox_PostalCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ValidatePostalCode(uxTextBox_PostalCode.Text))
            {
                uxTextBlock_InvalidPostalCode.Visibility = Visibility.Hidden;
                uxButton_Submit.Visibility = Visibility.Visible;
            }
            else
            {
                uxTextBlock_InvalidPostalCode.Visibility = Visibility.Visible;
                uxButton_Submit.Visibility = Visibility.Hidden;

            }
        }

        private void uxButton_Submit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Valid Postal Code!");
            uxTextBox_PostalCode.Text = "";
            uxButton_Submit.Visibility = Visibility.Hidden;
            uxTextBlock_InvalidPostalCode.Visibility = Visibility.Hidden;
        }

        private bool ValidatePostalCode(string postalCode)
        {
            postalCode = postalCode.ToUpper();
            bool postalCodeValidated = false;
            int x = postalCode.Length;

            switch (x)
            {
                case 5:
                    postalCodeValidated = true;
                    foreach (char ch in postalCode)
                    {
                        
                        if (ch < '0' || ch > '9')
                        {
                            postalCodeValidated = false;
                        }
                    }
                    break;
                case 6:
                    postalCodeValidated = true;
                    if (postalCode[0] < 'A' || postalCode[0] > 'Z' ||
                        postalCode[1] < '0' || postalCode[1] > '9' ||
                        postalCode[2] < 'A' || postalCode[2] > 'Z' ||
                        postalCode[3] < '0' || postalCode[3] > '9' ||
                        postalCode[4] < 'A' || postalCode[4] > 'Z' ||
                        postalCode[5] < '0' || postalCode[5] > '9')
                    {
                        postalCodeValidated = false;
                    }
                    break;
                case 10:
                    postalCodeValidated = true;
                    for (int i = 0; i < x; i++)
                    {
                        if (i == 5)
                        {
                            if (postalCode[i] != '-')
                            {
                                postalCodeValidated = false;
                            }
                        }
                        else if (postalCode[i] < '0' || postalCode[i] > '9')
                        {
                            postalCodeValidated = false;
                        }
                    }
                    break;
                default:
                    break;
            }
            return postalCodeValidated;
        }
    }
}
