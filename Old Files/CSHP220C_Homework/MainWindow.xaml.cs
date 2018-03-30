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

namespace CSHP220C_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static List<Models.User> users = new List<Models.User>();

        public MainWindow()
        {
            InitializeComponent();
            textBox_UserName.Focus();
            
            AddUser("Dave", "1DavePwd");
            AddUser("Steve", "2StevePwd");
            AddUser("Lisa", "3LisaPwd");
        }

        private void textBox_UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnlockPasswordConfirmation();
        }

        private void textBox_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnlockPasswordConfirmation();
            PasswordConfirmation();
        }

        private void textBox_PasswordConfirmation_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordConfirmation();
        }

        private void button_Submit_Click(object sender, RoutedEventArgs e)
        {
            AddUser(textBox_UserName.Text, textBox_Password.Text);
            MessageBox.Show("New User Account Created!\r\n" +
                $"User Name: {textBox_UserName.Text}\r\nPassword: {textBox_Password.Text}");
            textBox_UserName.Text = "";
            textBox_Password.Text = "";
            textBox_UserName.Focus();
        }

        private void UnlockPasswordConfirmation()
        {
            if (textBox_UserName.Text != "" && textBox_Password.Text != "")
            {
                textBox_PasswordConfirmation.IsEnabled = true;
            }
            else
            {
                textBox_PasswordConfirmation.Text = "";
                textBox_PasswordConfirmation.IsEnabled = false;
            }
        }

        private void PasswordConfirmation()
        {
            if (textBox_PasswordConfirmation.Text == "")
            {
                textBlock_PasswordNotVerified.Visibility = Visibility.Hidden;
                button_Submit.IsEnabled = false;
            }
            else
            {
                if (textBox_Password.Text == textBox_PasswordConfirmation.Text)
                {
                    textBlock_PasswordNotVerified.Visibility = Visibility.Hidden;
                    button_Submit.IsEnabled = true;
                }
                else
                {
                    textBlock_PasswordNotVerified.Visibility = Visibility.Visible;
                    button_Submit.IsEnabled = false;
                }
            }
        }

        private void AddUser(String name, String password)
        {
            users.Add(new Models.User { Name = name, Password = password });
        }

        private void button_userInfo_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow secondWindow = new SecondWindow();
            secondWindow.ShowDialog();
        }
    }
}
