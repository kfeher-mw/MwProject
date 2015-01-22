using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
	public class Program
	{

		static Dictionary<string,Merchant> MerchantDictionary = new Dictionary<string, Merchant>();
		
		static void Main(string[] args)
		{
		}

        /// <summary>
        /// (1)	Finding a Merchant by their MerchantId
        /// </summary>
        public static Merchant GetMerchant(string merchantId)
        {
            if (doesMerchantExist(merchantId))
            {
                return MerchantDictionary[merchantId]; 
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (2) Finding all Shops belonging to a given Merchant 
        /// </summary>
        public static Dictionary<string,Shop> findShopsByMerchant(string merchantId)
        {
            return GetMerchant(merchantId).ShopDictionary;
        }

	    
	    public static bool doesMerchantExist(string id)
	    {
	        return MerchantDictionary.ContainsKey(id);
	    }

        /// <summary>
        /// (3)	Finding all Shops for a given Merchant Type (i.e. all FastFood shops or all Electronics Shops)
        /// </summary>
        public static Dictionary<string, Shop> getShopsByMerchantType(string type)
        {
            Dictionary<string, Shop> returnDictionary = new Dictionary<string, Shop>();
            
            foreach (string merchantId in MerchantDictionary.Keys)
            {
                if (MerchantDictionary[merchantId].MerchantType.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    // TODO : returnDictionary.Add(, MerchantDictionary[merchantId].ShopDictionary);
                }
            }

            return returnDictionary;
        }
	}
}
