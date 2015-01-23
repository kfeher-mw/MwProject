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
            if (shop == null || DoesShopExist(shop.ShopId))
            {
                return false;
            }
            else

            ShopDictionary.Add(shop.ShopId, shop);
            return DoesShopExist(shop.ShopId);
        }

        public bool RemoveShop(string shopId)
        {
            return ShopDictionary.Remove(shopId);
        }

        public bool DoesShopExist(string shopId)
        {
            return ShopDictionary.ContainsKey(shopId);
        }


    }
}
