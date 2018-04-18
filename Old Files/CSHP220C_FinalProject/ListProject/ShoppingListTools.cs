using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ListProject
{
    public class ShoppingListTools
    {
        internal static decimal DecimalCheck(string input)
        {
            if (decimal.TryParse(input, out decimal result) && result > 0.0m)
            {
                return result;
            }
            else
            {
                return -1m;
            }
        }

        internal static int IntCheck(string input)
        {
            if (int.TryParse(input, out int result) && result >= 0)
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        internal static bool ItemNameCheck(ShoppingListEntities entities, string nameToCheck)
        {
            bool isGood = true;
            if ((from items in entities.Items
                 where items.ItemName == nameToCheck
                 select items).Any() ||
                  nameToCheck.Length > 50)
            {
                isGood = false;
            }
            return isGood;
        }

        internal static bool CategoryNameCheck(ShoppingListEntities entities, string nameToCheck)
        {
            bool isGood = true;
            if ((from categories in entities.Categories
                 where categories.CategoryName == nameToCheck
                 select categories).Any() ||
                  nameToCheck.Length > 50)
            {
                isGood = false;
            }
            return isGood;
        }

        internal static void AddCategory(string newCategory)
        {

            using (ShoppingListEntities entities = new ShoppingListEntities())
            {
                if (CategoryNameCheck(entities, newCategory))
                {
                    Category category = new Category();
                    {
                        category.CategoryName = newCategory;
                    }
                    entities.Categories.Add(category);
                    entities.SaveChanges();
                }
                else
                {
                    WinError error = new WinError();
                    error.Show();
                }
            }
        }

        internal static void AddItem(string newItem, string newPrice, string newQuantity, int newCategory)
        {
            using (ShoppingListEntities entities = new ShoppingListEntities())
            {
                Decimal price = DecimalCheck(newPrice);
                int quantity = IntCheck(newQuantity);
                if (ItemNameCheck(entities, newItem) && price != -1m && quantity != -1)
                {
                    Item item = new Item();
                    {
                        item.ItemName = newItem;
                        item.ItemPrice = price;
                        item.ItemQuantity = quantity;
                        item.CategoryID = newCategory;
                    }
                    entities.Items.Add(item);
                    entities.SaveChanges();
                }
                else
                {
                    WinError error = new WinError();
                    error.Show();
                }
            }
        }

        internal static void EditItem(Item item, string editPrice, string editQuantity)
        {
            using (ShoppingListEntities entities = new ShoppingListEntities())
            {
                Decimal price = DecimalCheck(editPrice);
                int quantity = IntCheck(editQuantity);
                if (price != -1m && quantity != -1)
                {
                    item.ItemPrice = price;
                    item.ItemQuantity = quantity;
                    entities.SaveChanges();
                }
                else
                {
                    WinError error = new WinError();
                    error.Show();
                }
            }
        }

        internal static void DeleteItem(Item item)
        {
            using (ShoppingListEntities entities = new ShoppingListEntities())
            {
                entities.Items.Remove(item);
                entities.SaveChanges();
            }
        }

        internal static void ClearList()
        {
            using (ShoppingListEntities entities = new ShoppingListEntities())
            {
                foreach (var item in entities.Items)
                {
                    entities.Items.Remove(item);
                }
                entities.SaveChanges();
            }
        }
    }
}
