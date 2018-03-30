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
    /// Interaction logic for WinAddCategory.xaml
    /// </summary>
    public partial class WinAddCategory : Window
    {
        public WinAddCategory()
        {
            InitializeComponent();
        }

        private void uxButton_AddCategory_Click(object sender, RoutedEventArgs e)
        {
            Win2AddCategory addCategory2 = new Win2AddCategory();
            addCategory2.ShowDialog();

            if (addCategory2.DialogResult.HasValue && addCategory2.DialogResult.Value)
            {
                ShoppingListTools.AddCategory(uxTextBox_AddCategory.Text.ToString());
            }
        }

        private void uxButton_AddCategoryCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
