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
using System.Windows.Shapes;

namespace ListProject
{
    /// <summary>
    /// Interaction logic for WinAbout.xaml
    /// </summary>
    public partial class WinAbout : Window
    {
        public WinAbout()
        {
            InitializeComponent();
        }

        private void uxButton_CloseAbout_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
