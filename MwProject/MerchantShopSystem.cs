using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
    public class MerchantShopSystem
    {

        private Dictionary<string, Merchant> merchantDictionary;
        private Dictionary<string, List<Merchant>> merchantsByType;

        public MerchantShopSystem(Dictionary<string, Merchant> aMerchantDictionary, Dictionary<string, List<Merchant>> aMerchantByType)
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

            if (DoesMerchantExist(merchantId))
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
            if (DoesMerchantExist(merchantId))
            {
                return GetMerchant(merchantId).ShopDictionary;
            }
            return null;
        }

        /// <summary>
        /// (3)	Finding all Shops for a given Merchant Type (i.e. all FastFood shops or all Electronics Shops)
        /// returns the specific type of merchants with their shops.
        /// </summary>
        public List<Shop> GetShopsByMerchantType (string merchantType)
        {
            if (String.IsNullOrWhiteSpace(merchantType) || !merchantsByType.ContainsKey(merchantType))
            {
                return null;
            }
            
            List<Shop> returnList = new List<Shop>();
           
            foreach (Merchant merchant in merchantsByType[merchantType])
            {
                returnList.AddRange(merchant.ShopDictionary.Values);
            }

            return returnList;
        }

        public bool AddMerchant(Merchant newMerchant)
        {
            if (newMerchant == null || DoesMerchantExist(newMerchant.MerchantId))
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

        public bool DoesMerchantExist(string merchantId)
        {
            if (String.IsNullOrWhiteSpace(merchantId))
            {
                return false;
            }

            return (merchantDictionary.ContainsKey(merchantId));
        }
    }
}
