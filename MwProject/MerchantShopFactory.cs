using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwProject
{
    class MerchantShopFactory
    {
        public MerchantShopFactory(){}
        public IMerchantShop CreateMerchantShop(MerchantShopType type)
        {
            switch (type)
            {
                case MerchantShopType.InDatabase:
                    return new MerchantShopInDatabase();

                case MerchantShopType.InMemory:
                    return new MerchantShopInMemory();

                default :
                    goto case MerchantShopType.InMemory;
            }
        }
    }


    enum MerchantShopType{InMemory, InDatabase}
}
