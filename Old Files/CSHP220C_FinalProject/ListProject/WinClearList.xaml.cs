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
    /// Interaction logic for WinClearList.xaml
    /// </summary>
    public partial class WinClearList : Window
    {
        public WinClearList()
        {
            InitializeComponent();
        }

        private void uxButton_ClearList_Click(object sender, RoutedEventArgs e)
        {
            ShoppingListTools.ClearList();
            Close();
        }

        private void uxButton_ClearListCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
