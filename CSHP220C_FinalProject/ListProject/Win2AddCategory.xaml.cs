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
    /// Interaction logic for Win2AddCategory.xaml
    /// </summary>
    public partial class Win2AddCategory : Window
    {
        public Win2AddCategory()
        {
            InitializeComponent();
        }

        private void uxButton_ConfirmAddCategory_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void uxButton_ConfirmAddCategoryCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
