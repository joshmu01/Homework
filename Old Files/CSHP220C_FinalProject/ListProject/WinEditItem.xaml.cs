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
    /// Interaction logic for WinEditItem.xaml
    /// </summary>
    public partial class WinEditItem : Window
    {
        public WinEditItem(Item item)
        {
            InitializeComponent();
            DataContext = item;
        }

        private void uxButton_EditItem_Click(object sender, RoutedEventArgs e)
        {
            Win2EditItem editItem2 = new Win2EditItem();
            editItem2.ShowDialog();

            if (editItem2.DialogResult.HasValue && editItem2.DialogResult.Value)
            {
                ShoppingListTools.EditItem((Item)DataContext, uxTextBox_EditItemPrice.Text, uxTextBox_EditItemQuantity.Text);
                Close();
            }
        }

        private void uxButton_EditItemCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
