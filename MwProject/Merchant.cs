using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MwProject
{
    public class Merchant
    {
        public string MerchantId { get; protected set; }
        public string MerchantName { get; protected set; }
        public string MerchantType { get; protected set; }
        public Dictionary<string, Shop> ShopDictionary { get;  protected set; }
    

        public Merchant(string merchantId, string merchantName, string merchantType)
        {
            MerchantId = String.Copy(merchantId);
            MerchantName = String.Copy(merchantName);
            MerchantType = String.Copy(merchantType);
            ShopDictionary = new Dictionary<string,Shop>();
        }

        public bool AddShop(Shop shop)
        {
            try
            {
                ShopDictionary.Add(shop.ShopId, shop);
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

        public bool RemoveShop(string shopId)
        {
            try
            {
                ShopDictionary.Remove(shopId);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public bool DoesShopExist(string shopId)
        {
            try
            {
                return ShopDictionary.ContainsKey(shopId);
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }


    }
}
