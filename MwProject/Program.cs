using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
    public class Program
    {

        static Dictionary<string,Merchant> _merchantDictionary = new Dictionary<string, Merchant>();
        
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// (1)	Finding a Merchant by their MerchantId
        /// </summary>
        public static Merchant GetMerchant(string merchantId)
        {
            if (DoesMerchantExist(merchantId))
            {
                return _merchantDictionary[merchantId]; 
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (2) Finding all Shops belonging to a given Merchant 
        /// </summary>
        public static Dictionary<string,Shop> FindShopsByMerchant(string merchantId)
        {
            return GetMerchant(merchantId).ShopDictionary;
        }

        
        public static bool DoesMerchantExist(string id)
        {
            return _merchantDictionary.ContainsKey(id);
        }

        /// <summary>
        /// (3)	Finding all Shops for a given Merchant Type (i.e. all FastFood shops or all Electronics Shops)
        /// </summary>
        public static List<Shop> GetShopsByMerchantType(string type)
        {
            List<Shop> returnShops = new List<Shop>();
            
            foreach (string merchantId in _merchantDictionary.Keys)
            {
                if (_merchantDictionary[merchantId].MerchantType.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    returnShops.AddRange(_merchantDictionary[merchantId].ShopDictionary.Values);
                }
            }

            return returnShops;
        }
    }
}
