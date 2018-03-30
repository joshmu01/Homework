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
using System.ComponentModel;

namespace CSHP220C_Homework
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private string columnToSort = "";
        private ListSortDirection sortDirection = ListSortDirection.Ascending;

        public SecondWindow()
        {
            InitializeComponent();
            listView_UserInfo.ItemsSource = MainWindow.users;
            columnToSort = columnHeader_UserName.Tag.ToString();
            listView_UserInfo.Items.SortDescriptions.Add(new SortDescription(columnToSort, sortDirection));
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            string columnClicked = (sender as GridViewColumnHeader).Tag.ToString();
            listView_UserInfo.Items.SortDescriptions.Clear();

            ListSortDirection newDirection = ListSortDirection.Ascending;
            if (columnToSort == columnClicked && sortDirection == newDirection)
            {
                newDirection = ListSortDirection.Descending;
            }

            sortDirection = newDirection;
            columnToSort = columnClicked;
            listView_UserInfo.Items.SortDescriptions.Add(new SortDescription(columnToSort, sortDirection));
        }
    }
}
