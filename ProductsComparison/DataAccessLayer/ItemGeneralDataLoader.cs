using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class ItemGeneralDataLoader 
    {

        /*
     * Static classes and methods are rarely justifyable
     * They create tight coupling (hard to replace them since they are publicly known.
     * They hinder testability since client code of such classes can not be configured to work with a different data source.
     */
        public static List<ItemGeneralData> GetItemsData()
        {
            var categories = XElement.Load("..\\..\\..\\Products.Xml").Elements();

            return (from category in categories
                                from item in category.Elements()
                                select TransformToItemGeneralDataInstance(item))
                            .ToList();
        }

        /*
     * Static classes and methods are rarely justifyable
     * They create tight coupling (hard to replace them since they are publicly known.
     * They hinder testability since client code of such classes can not be configured to work with a different data source.
     */
        private static ItemGeneralData TransformToItemGeneralDataInstance(XElement item)
        {
            int itemIdHolder;
            int.TryParse(item.Element("ItemId")?.Value, out itemIdHolder);
            return 
                new ItemGeneralData
                {
                    ItemId = itemIdHolder,
                    ItemName = item.Element("ItemName")?.Value,
                    ItemCategory = item.Parent?.FirstAttribute.Value,
                    ShufersalItemCode = item.Element("ItemCodeShufersal")?.Value,
                    RamiLeviItemCode = item.Element("ItemCodeRamiLevi")?.Value,
                    VictoryItemCode = item.Element("ItemCodeVictory")?.Value,
                    Ammount = 0
                };
        }
    }
}
