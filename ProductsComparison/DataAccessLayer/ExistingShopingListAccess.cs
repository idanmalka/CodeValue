using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    public class ExistingShopingListAccess
    {

        public static void SaveCartToFile(List<ItemGeneralData> cart, string path)
        {
            var writer = new XmlSerializer(typeof(List<ItemGeneralData>));

            var file = System.IO.File.Create(path);

            writer.Serialize(file, cart);
            file.Close();
        }

        public static List<ItemGeneralData> LoadCartFromFile(string path)
        {
            var reader = new System.Xml.Serialization.XmlSerializer(typeof(List<ItemGeneralData>));
            var file = new System.IO.StreamReader(path);
            List<ItemGeneralData> cart;
            try
            {
                cart = (List<ItemGeneralData>) reader.Deserialize(file);
            }
            catch (InvalidOperationException e)
            {
                cart = new List<ItemGeneralData>
                {
                    new ItemGeneralData
                    {
                        ItemName = "Invalid File"
                    }
                };
            }
            file.Close();
            return cart;
        }
    }
}
