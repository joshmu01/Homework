using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListProject
{
    public class ShoppingListViewModel : INotifyPropertyChanged
    {
        ShoppingListEntities context = new ShoppingListEntities();

        private ObservableCollection<Item> itemList;
        public ObservableCollection<Item> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged("ItemList");
            }
        }

        private ObservableCollection<Category> categoryList;
        public ObservableCollection<Category> CategoryList
        {
            get { return categoryList; }
            set
            {
                categoryList = value;
                OnPropertyChanged("CategoryList");
            }
        }

        private string totalCost;
        public string TotalCost
        {
            get
            { return totalCost; }
            set
            {
                totalCost = value;
                OnPropertyChanged("TotalCost");
            }
        }

        public ShoppingListViewModel()
        {
            var ocItems = from items in context.Items
                       select items;
            itemList = new ObservableCollection<Item>(ocItems);

            var ocCategories = from categories in context.Categories
                       select categories;
            categoryList = new ObservableCollection<Category>(ocCategories);

            decimal sum = 0.0M;
            foreach (var item in itemList)
            {
                sum += (item.ItemPrice * item.ItemQuantity);
            }
            totalCost = sum.ToString();
        }

        #region PropertyChangedEventHandler / OnPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
