using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
    public class Shop
    {
        public string ShopId { get; protected set; }
        public string ShopManager { get; protected set; }

        public Shop(string shopId, string shopManager)
        {

            if (String.IsNullOrWhiteSpace(shopId) || String.IsNullOrWhiteSpace(shopManager))
            {
                throw new ArgumentException("Shop object constructed with one or more null or empty values!");
            }
            
            ShopId = String.Copy(shopId);
            ShopManager = String.Copy(shopManager);
        }
    }
}
