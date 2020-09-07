using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DataAccessLayer
{
    /*
     * Static classes and methods are rarely justifyable
     * They create tight coupling (hard to replace them since they are publicly known.
     * They hinder testability since client code of such classes can not be configured to work with a different data source.
     */
    public static class ItemsFullDataLoader 
    {

        public static Dictionary<int,List<ItemFullData>> GetItemsData(List<ItemGeneralData> itemList)
        {
            var itemsFullData = new Dictionary<int, List<ItemFullData>>();
            var chainsDirectories = new DirectoryInfo("..\\..\\..\\chains").GetDirectories();

            foreach (var chainDir in chainsDirectories)
            {
                var path = chainDir.GetFiles("*.xml")[0].FullName;
                var itemsXml = XElement.Load(path);
                ExctractDataFromFile(itemsXml, itemList, itemsFullData);
            }

            return itemsFullData;
        }

        private static void ExctractDataFromFile(XContainer itemsXml, IEnumerable<ItemGeneralData> itemList, IDictionary<int, List<ItemFullData>> itemsFullData)
        {
            foreach (var itemGeneralData in itemList)
            {
                try
                {
                    var item = itemsXml.Elements()
                        .Last()
                        .Elements()
                        .First(e => CheckExistance(e.Element("ItemCode")?.Value, itemGeneralData));
                    AddFullData(itemGeneralData, item, itemsFullData);
                }
                catch (InvalidOperationException e)
                {
                    var item = new ItemFullData
                    {
                        ChainId = "0", ChainName = "Error" , ItemCode = "0", ItemId = 0,ItemName = "קובץ שגוי", ItemPrice = "0"
                    };
                    if (!itemsFullData.ContainsKey(itemGeneralData.ItemId))
                        itemsFullData.Add(itemGeneralData.ItemId, new List<ItemFullData> { item });
                    else itemsFullData[itemGeneralData.ItemId].Add(item);
                }
                
            }
        }

        private static void AddFullData(ItemGeneralData itemGeneralData, XContainer item, IDictionary<int, List<ItemFullData>> itemsFullData)
        {
            var itemId = itemGeneralData.ItemId;

            if (!itemsFullData.ContainsKey(itemId))
                itemsFullData.Add(itemId, new List<ItemFullData>());

            var data = new ItemFullData();

            data.ChainId = item.Ancestors().Last().Element("ChainId")?.Value;
            data.ChainName = GetChainNameById(data.ChainId);
            data.ItemId = itemId;
            data.ItemCode = item.Element("ItemCode")?.Value;
            data.ItemName = item.Element("ItemName")?.Value;
            data.ItemPrice = item.Element("ItemPrice")?.Value;
            data.LastUpdateDate = item.Element("PriceUpdateDate")?.Value;
            data.Quantity = item.Element("Quantity")?.Value;
            data.StoreId = item.Ancestors().Last()?.Element("StoreId")?.Value;
            data.UnitOfMeasure = item.Element("UnitOfMeasure")?.Value;
            
            itemsFullData[itemId].Add(data);
        }

        private static string GetChainNameById(string chainId)
        {
            switch (chainId)
            {
                case "7290058140886":
                    return "RamiLevi";
                case "7290027600007":
                    return "Shufersal";
                case "7290696200003":
                    return "Victory";
                default:
                    return "Error";
            }
        }

        private static bool CheckExistance(string itemCode, ItemGeneralData item)
        {
            return
                itemCode == item.ShufersalItemCode ||
                itemCode == item.RamiLeviItemCode ||
                itemCode == item.VictoryItemCode;
        }
    }
}
