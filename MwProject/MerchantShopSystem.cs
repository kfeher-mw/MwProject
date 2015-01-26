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

        public MerchantShopSystem()
        {
            merchantDictionary = new Dictionary<string, Merchant>();
            merchantsByType = new Dictionary<string, List<Merchant>>();
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
                throw new ArgumentNullException();
            }

            try
            {
                return merchantDictionary[merchantId]; 
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
         
        }

        /// <summary>
        /// (2) Finding all Shops belonging to a given Merchant 
        /// returns the dictionary of shops by their merchant's merchantId
        /// returns null of the merchantId cannot be found.
        /// </summary>
        public Dictionary<string,Shop> FindShopsByMerchant(string merchantId)
        {
            if (String.IsNullOrWhiteSpace(merchantId))
            {
                throw new ArgumentNullException();
            }

            try
            {
                return GetMerchant(merchantId).ShopDictionary;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        /// (3)	Finding all Shops for a given Merchant Type (i.e. all FastFood shops or all Electronics Shops)
        /// returns the specific type of merchants with their shops.
        /// </summary>
        public List<Shop> GetShopsByMerchantType (string merchantType)
        {
            if (String.IsNullOrWhiteSpace(merchantType))
            {
                throw new ArgumentNullException();
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
            try
            {
                merchantDictionary.Add(newMerchant.MerchantId, newMerchant);
                return true;
            }

            catch (ArgumentNullException)
            {
                return false;
            }

            catch (ArgumentException)
            {
                return false;
            }

        }

        public bool RemoveMerchant(string merchantId)
        {
            try
            {
                merchantDictionary.Remove(merchantId);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
