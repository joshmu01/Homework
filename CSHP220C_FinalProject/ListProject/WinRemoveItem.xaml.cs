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
    /// Interaction logic for WinRemoveItem.xaml
    /// </summary>
    public partial class WinRemoveItem : Window
    {
        public WinRemoveItem()
        {
            InitializeComponent();
        }

        private void uxButton_DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void uxButton_DeleteItemCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
