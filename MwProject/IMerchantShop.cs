using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
    interface IMerchantShop
    {
        Merchant GetMerchant(string merchantId);
        Dictionary<string, Shop> FindShopsByMerchant(string merchantId);
        Dictionary<string, List<Shop>> GetShopsByMerchantType(string merchantType);
        bool AddMerchant(Merchant newMerchant);
        bool RemoveMerchant(string merchantId);
        }
}
