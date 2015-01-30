using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MwProject
{
    public class Merchant
    {
        public string MerchantId { get; protected set; }
        public string MerchantName { get; protected set; }
        public string MerchantType { get; protected set; }
        internal Dictionary<string, Shop> ShopDictionary { get; private set; }


        public Merchant(string merchantId, string merchantName, string merchantType)
        {

            if (String.IsNullOrWhiteSpace(merchantId) || String.IsNullOrWhiteSpace(merchantName) ||
                String.IsNullOrWhiteSpace(merchantType))
            {
                throw new ArgumentException("Merchant object constructed with one or more null or empty values!");
            }

            MerchantId = String.Copy(merchantId);
            MerchantName = String.Copy(merchantName);
            MerchantType = String.Copy(merchantType);
            ShopDictionary = new Dictionary<string, Shop>();
        }

        public bool AddShop(Shop newShop)
        {
            if (newShop == null || ShopDictionary.ContainsValue(newShop))
            {
                return false;
            }

            ShopDictionary.Add(newShop.ShopId, newShop);
            return true;
        }

        public bool RemoveShop(string shopId)
        {

            if (String.IsNullOrWhiteSpace(shopId))
            {
                return false;
            }

            return ShopDictionary.Remove(shopId);
        }
    }
}
