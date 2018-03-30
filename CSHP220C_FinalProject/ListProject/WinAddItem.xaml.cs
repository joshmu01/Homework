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
    /// Interaction logic for WinAddItem.xaml
    /// </summary>
    public partial class WinAddItem : Window
    {
        public WinAddItem()
        {
            InitializeComponent();
            ShoppingListViewModel context = new ShoppingListViewModel();
            DataContext = context;

        }

        private void uxButton_AddItem_Click(object sender, RoutedEventArgs e)
        {
            Win2AddItem addItem2 = new Win2AddItem();
            addItem2.ShowDialog();
            if (addItem2.DialogResult.HasValue && addItem2.DialogResult.Value)
            {
                ShoppingListTools.AddItem(uxTextBox_AddItemName.Text.ToString(),
                    uxTextBox_AddItemPrice.Text.ToString(), uxTextBox_AddItemQuantity.Text.ToString(),
                    uxComboBox_AddItemCategory.SelectedIndex);
            }
        }

        private void uxButton_AddItemCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
