using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BussinesLogicLayer;

namespace UILayer
{
    public class TreeViewModel
    {
        public static void SetTreeDesign(TreeView catalogTree, LogicManager manager)
        {
            
            foreach (var category in manager.GetCatalogItems().GetCatalog())
            {
                var categoryItem = new TreeViewProduct
                {
                    IsEnabled = false,
                    Text = category.Key,
                    Visibility = Visibility.Collapsed
                };

                foreach (var item in category.Value)
                {
                    var treeItem = new TreeViewProduct
                    {
                        IsEnabled = true,
                        Text = item.ItemName,
                        Visibility = Visibility.Visible
                    };
                    categoryItem.SubProducts.Add(treeItem);
                }
                catalogTree.Items.Add(categoryItem);
            }
        }

        public static IEnumerable<KeyValuePair<string, string>> GetSelectedItems(IEnumerable items)
        {
            var shopList = new List<KeyValuePair<string, string>>();

            foreach (TreeViewProduct item in items)
            {
                if (item.IsChecked)
                {
                    double ammount;
                    double.TryParse(item.Ammount, out ammount);
                    if (ammount > 0)
                        shopList.Add(new KeyValuePair<string, string>(item.Text,ammount.ToString()));
                }

                var l = GetSelectedItems(item.SubProducts);
                shopList = shopList.Concat(l).ToList();
            }

            return shopList;
        }
    }
}
