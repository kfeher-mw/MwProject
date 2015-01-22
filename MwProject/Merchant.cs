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

        public void AddShop(Shop shop)
        {
            ShopDictionary.Add(shop.ShopId, shop);
        }

        public void RemoveShop(Shop shop)
        {
            ShopDictionary.Remove(shop.ShopId);
        }

        public bool DoesShopExist(Shop shop)
        {
            return ShopDictionary.ContainsKey(shop.ShopId);
        }


    }
}
