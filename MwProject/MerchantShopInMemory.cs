using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
    public class MerchantShopInMemory : IMerchantShop
    {

        private Dictionary<string, Merchant> merchantDictionary;
        private Dictionary<string, List<Merchant>> merchantsByType;

        public MerchantShopInMemory(){}
        public MerchantShopInMemory(Dictionary<string, Merchant> aMerchantDictionary, Dictionary<string, List<Merchant>> aMerchantByType)
        {
            merchantDictionary = aMerchantDictionary;
            merchantsByType = aMerchantByType;
        }
        
        
        /// <summary>
        /// (1)	Finding a Merchant by their MerchantId
        /// returns Merchant by their merchantId.
        /// returns null if merchantId cannot be found.
        /// </summary>
        public Merchant GetMerchant(string merchantId)
        {
            if (String.IsNullOrWhiteSpace(merchantId))
            {
                return null;
            }

            if (merchantDictionary.ContainsKey(merchantId))
            {
                return merchantDictionary[merchantId];
            }
            return null;
        }

        /// <summary>
        /// (2) Finding all Shops belonging to a given Merchant 
        /// returns the dictionary of shops by their merchant's merchantId
        /// returns null of the merchantId cannot be found.
        /// </summary>
        public Dictionary<string,Shop> FindShopsByMerchant(string merchantId)
        {
            if (merchantDictionary.ContainsKey(merchantId))
            {
                return GetMerchant(merchantId).ShopDictionary;
            }
            return null;
        }

        /// <summary>
        /// (3)	Finding all Shops for a given Merchant Type (i.e. all FastFood shops or all Electronics Shops)
        /// returns the specific type of merchants with their shops.
        /// </summary>
        public Dictionary<string,List<Shop>> GetShopsByMerchantType (string merchantType)
        {
            if (String.IsNullOrWhiteSpace(merchantType) || !merchantsByType.ContainsKey(merchantType))
            {
                return null;
            }

            Dictionary<string, List<Shop>> returnDictionary = new Dictionary<string, List<Shop>>();
           
            foreach (Merchant merchant in merchantsByType[merchantType])
            {
                returnDictionary.Add(merchant.MerchantId, new List<Shop>(merchant.ShopDictionary.Values));
            }

            return returnDictionary;
        }

        public bool AddMerchant(Merchant newMerchant)
        {
            if (newMerchant == null || merchantDictionary.ContainsKey(newMerchant.MerchantId))
            {
                return false;
            }
            
            merchantDictionary.Add(newMerchant.MerchantId, newMerchant);
            
            if (merchantsByType.ContainsKey(newMerchant.MerchantType))
            {
                merchantsByType[newMerchant.MerchantType].Add(newMerchant);
            }
            else
            {
                merchantsByType.Add(newMerchant.MerchantType, new List<Merchant>(){newMerchant});
            }
            
            return true;
        } 

        public bool RemoveMerchant(string merchantId)
        {
            if (String.IsNullOrWhiteSpace(merchantId))
            {
                return false;
            }

            return merchantDictionary.Remove(merchantId);
        }
    }
}
