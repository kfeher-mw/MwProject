using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
    internal class Shop
    {
        public string ShopId { get; private set; }
        public string ShopManager { get; private set; }

        public Shop(string id, string manager)
        {
            ShopId = id;
            ShopManager = manager;
        }
    }
}
