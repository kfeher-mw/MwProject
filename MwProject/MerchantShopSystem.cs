using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
    public class MerchantShopSystem
    {

        static Dictionary<string,Merchant> _merchantDictionary = new Dictionary<string, Merchant>();
        
        static void Main(string[] args)
        {
            Merchant m = new Merchant("      ", "       ", "       ");
            Console.WriteLine(m.MerchantId);
        }

        
        /// <summary>
        /// (1)	Finding a Merchant by their MerchantId
        /// returns Merchant by their merchantId.
        /// returns null if merchantId cannot be found.
        /// </summary>
        public static Merchant GetMerchant(string merchantId)
        {
            if (String.IsNullOrWhiteSpace(merchantId))
            {
                throw new ArgumentNullException();
            }

            try
            {
                return _merchantDictionary[merchantId]; 
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
        public static Dictionary<string,Shop> FindShopsByMerchant(string merchantId)
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
        public static Dictionary<Merchant,Dictionary<string,Shop>> GetShopsByMerchantType(string merchantType)
        {
            if (String.IsNullOrWhiteSpace(merchantType))
            {
                throw new ArgumentNullException();
            }
            
            Dictionary<Merchant,Dictionary<string,Shop>> returnDictionary = new Dictionary<Merchant, Dictionary<string, Shop>>();
            
            foreach (string merchantId in _merchantDictionary.Keys)
            {
                Merchant aMerchant = _merchantDictionary[merchantId];

                if (aMerchant.MerchantType.Equals(merchantType, StringComparison.OrdinalIgnoreCase))
                {
                    returnDictionary.Add(aMerchant, aMerchant.ShopDictionary);
                }
            }

            return returnDictionary;
        }
    }
}
