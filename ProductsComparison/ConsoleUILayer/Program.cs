using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLogicLayer;

namespace ConsoleUILayer
{
    class Program
    {
        public static void Main()
        {
            var manager = new LogicManager();
            var catalog = manager.GetCatalogItems();
            DisplayCatalogItems(catalog);

        }

        private static void DisplayCatalogItems(ItemsCatalog catalog)
        {
            Console.WriteLine("The Catalog:");
            foreach (var category in catalog.GetCatalog())
            {
                Console.WriteLine($"{category.Key}:");
                foreach (var item in category.Value)
                {
                    Console.WriteLine($"\t{item.ItemId}:{item.ItemName}");
                }
            }
        }
    }
}


//var itemsloader1 = new ItemGeneralDataLoader();
//var list = itemsloader1.GetItemsData();
//var items = new List<ItemGeneralData>();
//foreach (var category in list)
//{
//    Console.WriteLine($"{category.Key}:");
//    foreach (var item in category)
//    {
//        Console.WriteLine($"{item.ItemName}: {item.ShufersalItemCode} , {item.RamiLeviItemCode} , {item.VictoryItemCode}");
//        items.Add(item);
//    }

//}

//var itemsloader2 = new ItemsFullDataLoader();
//var list2 = itemsloader2.GetItemsData(items);
//Console.WriteLine();
//foreach (var itemsData in list2)
//{
//    foreach (var item in itemsData.Value)
//    {
//        Console.WriteLine($"{item.ItemId}, {item.ItemName}: {item.ChainId} , {item.StoreId}");
//    }
//}