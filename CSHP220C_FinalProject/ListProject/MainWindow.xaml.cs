using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ListProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShoppingListViewModel context = new ShoppingListViewModel();
            DataContext = context;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(context.ItemList);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CategoryID");
            view.GroupDescriptions.Add(groupDescription);
        }

        private void uxMenuItem_ClearList_Click(object sender, RoutedEventArgs e)
        {
            WinClearList deleteAllItems = new WinClearList();
            deleteAllItems.ShowDialog();
            if (deleteAllItems.DialogResult.HasValue && deleteAllItems.DialogResult.Value)
            {
                ShoppingListTools.ClearList();
            }
        }

        private void uxMenuItem_AddCategory_Click(object sender, RoutedEventArgs e)
        {
            WinAddCategory addCategory = new WinAddCategory();
            addCategory.Show();
        }

        private void uxMenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            WinExitApplication exit = new WinExitApplication();
            exit.Show();
        }

        private void uxMenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            WinAbout about = new WinAbout();
            about.Show();
        }

        private void uxButton_EditItem_Click(object sender, RoutedEventArgs e)
        {
            WinEditItem editItem = new WinEditItem((Item)uxListView_MainList.SelectedItem);
            editItem.Show();
        }

        private void uxButton_AddItem_Click(object sender, RoutedEventArgs e)
        {
            WinAddItem addItem = new WinAddItem();
            addItem.Show();
        }

        private void uxButton_RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            WinRemoveItem removeItem = new WinRemoveItem();
            removeItem.ShowDialog();
            if (removeItem.DialogResult.HasValue && removeItem.DialogResult.Value)
            {
                ShoppingListTools.DeleteItem((Item)uxListView_MainList.SelectedItem);
            }
        }
    }
}
