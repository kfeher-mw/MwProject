using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MwProject
{
    class MainClass
    {
        #region DictionaryBuilder to initialise the dictionary with values
        private static int MerchantIdCounter;
        public static List<Merchant> AddMerchantToDictionary(int numberOfMerchants, int maxNumberOfShops, bool isShopNumberRandom)
        {
            List<Merchant> returnList = new List<Merchant>();

            Random rnd = new Random();
            int randomShopType;
            
            for (int i = 0; i <= numberOfMerchants; i++)
            {
                if (i != 0)
                {
                    Merchant aMerchant = null;
                    randomShopType = rnd.Next(1, 7);
                    int actualShopNumber;

                    if (isShopNumberRandom)
                    {
                        actualShopNumber = rnd.Next(1, maxNumberOfShops+1);
                    }
                    else
                    {
                        actualShopNumber = maxNumberOfShops;
                    }
                    
                    MerchantIdCounter++;

                    switch (randomShopType)
                    {
                        case 1:
                            aMerchant = new Merchant("MIN" + MerchantIdCounter, "MerchantName" + MerchantIdCounter, "fastfood");
                            break;
                        case 2:
                            aMerchant = new Merchant("MIN" + MerchantIdCounter, "MerchantName" + MerchantIdCounter, "entertainment");
                            break;
                        case 3:
                            aMerchant = new Merchant("MIN" + MerchantIdCounter, "MerchantName" + MerchantIdCounter, "computing");
                            break;
                        case 4:
                            aMerchant = new Merchant("MIN" + MerchantIdCounter, "MerchantName" + MerchantIdCounter, "retail");
                            break;
                        case 5:
                            aMerchant = new Merchant("MIN" + MerchantIdCounter, "MerchantName" + MerchantIdCounter, "restaurant");
                            break;
                        case 6:
                            aMerchant = new Merchant("MIN" + MerchantIdCounter, "MerchantName" + MerchantIdCounter, "farming");
                            break;

                    }
                    for (int z = 0; z <= actualShopNumber; z++)
                    {
                        if (z != 0)
                        {
                            aMerchant.ShopDictionary.Add("SIN" + z, new Shop("SIN" + z, "Manager#" + z));
                        }
                    }

                    returnList.Add(aMerchant);
                    //Console.WriteLine(aMerchant.MerchantId + " " + aMerchant.MerchantName + " " + aMerchant.MerchantType + " " + aMerchant.ShopDictionary.Count());
                }
            }

            return returnList;
        }

        public static Dictionary<string, Merchant> CreateEmptyDictionary()
        {
            Dictionary<string, Merchant> returnDictionary = new Dictionary<string, Merchant>();
            return returnDictionary;
        }

        public static Dictionary<string, Merchant> Create50000Dictionary()
        {
            int shopcount = 0;
            Dictionary<string, Merchant> returnDictionary = new Dictionary<string, Merchant>();
            List<Merchant> merchantList = new List<Merchant>();

            merchantList.AddRange(AddMerchantToDictionary(14, 50000, false));
            merchantList.AddRange(AddMerchantToDictionary(36, 5000, false));
            merchantList.AddRange(AddMerchantToDictionary(102, 500, false));
            merchantList.AddRange(AddMerchantToDictionary(207, 50, false));
            merchantList.AddRange(AddMerchantToDictionary(1002, 5, false));
            merchantList.AddRange(AddMerchantToDictionary(5001, 2, false));
            merchantList.AddRange(AddMerchantToDictionary(43638, 1, false));

            foreach (Merchant merchant in merchantList)
            {
                returnDictionary.Add(merchant.MerchantId, merchant);
                shopcount += merchant.ShopDictionary.Count();
            }

            //Console.WriteLine("The maximum number of shops are: " + shopcount);
            return returnDictionary;
        }

        public static Dictionary<string, Merchant> Create50001Dictionary()
        {
            int shopcount = 0;
            Dictionary<string, Merchant> returnDictionary = new Dictionary<string, Merchant>();
            List<Merchant> merchantList = new List<Merchant>();

            merchantList.AddRange(AddMerchantToDictionary(14, 50000, false));
            merchantList.AddRange(AddMerchantToDictionary(36, 5000, false));
            merchantList.AddRange(AddMerchantToDictionary(102, 500, false));
            merchantList.AddRange(AddMerchantToDictionary(207, 50, false));
            merchantList.AddRange(AddMerchantToDictionary(1002, 5, false));
            merchantList.AddRange(AddMerchantToDictionary(5001, 2, false));
            merchantList.AddRange(AddMerchantToDictionary(43638, 1, false));
            merchantList.Add(new Merchant("MIN50001", "ExtraMerchant", "restaurant"));

            foreach (Merchant merchant in merchantList)
            {
                returnDictionary.Add(merchant.MerchantId, merchant);
                shopcount += merchant.ShopDictionary.Count();
            }

            //Console.WriteLine("The maximum number of shops are: " + shopcount);
            return returnDictionary;
        }

        public static Dictionary<string, Merchant> CreateSoloDictionary()
        {
            Dictionary<string, Merchant> returnDictionary = new Dictionary<string, Merchant>();
            returnDictionary.Add("MIN1", new Merchant("MIN1", "Belfast Coffee company", "restaurant"));
            return returnDictionary;
        }

        public static Dictionary<string, Merchant> CreateMiddleRangeDictionary()
        {
            int shopcount = 0;
            Dictionary<string, Merchant> returnDictionary = new Dictionary<string, Merchant>();
            List<Merchant> merchantList = new List<Merchant>(AddMerchantToDictionary(25000, 20, true));

            foreach (Merchant merchant in merchantList)
            {
                returnDictionary.Add(merchant.MerchantId, merchant);
                shopcount += merchant.ShopDictionary.Count();
            }

            //Console.WriteLine("The maximum number of shops are: " + shopcount);
            return returnDictionary;
        }
        
        #endregion

        #region GetMerchant test cases
        public static bool Test_GetMerchant_Null_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(CreateMiddleRangeDictionary());
            
            if (testMerchantShopSystem.GetMerchant(null) == null)
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_GetMerchant_EmptyString_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(CreateMiddleRangeDictionary());

            if (testMerchantShopSystem.GetMerchant("") == null)
            {
                return true;
            }
            throw new Exception();
        }

        public static bool Test_GetMerchant_WhiteSpace_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(CreateMiddleRangeDictionary());

            if (testMerchantShopSystem.GetMerchant("       ") == null)
            {
                return true;
            }
            throw new Exception();
        }

        public static bool Test_GetMerchant_NonExistentId_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(CreateMiddleRangeDictionary());

            if (testMerchantShopSystem.GetMerchant("Nonexistent") == null)
            {
                return true;
            }
            throw new Exception();
        }

        public static bool Test_GetMerchant_NonExistentId_50000()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(Create50000Dictionary());

            if (testMerchantShopSystem.GetMerchant("Nonexistent") == null)
            {
                return true;
            }
            throw new Exception();
        }


        public static bool Test_GetMerchant_ExistentId_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(CreateMiddleRangeDictionary());

            if (testMerchantShopSystem.GetMerchant("MIN5").MerchantId.Equals("MIN5"))
            {
                return true;
            }
            throw new Exception();
        }

        public static bool Test_GetMerchant_ExistentId_50000()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(Create50000Dictionary());

            if (testMerchantShopSystem.GetMerchant("MIN50000").MerchantId.Equals("MIN50000"))
            {
                return true;
            }
            throw new Exception();
        }


        public static bool Test_GetMerchant_ExistentId_50001()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(Create50001Dictionary());

            if (testMerchantShopSystem.GetMerchant("MIN50001").MerchantId.Equals("MIN50001"))
            {
                return true;
            }
            throw new Exception();
        }
        #endregion

        #region AddMerchant test cases
        public static bool Test_AddMerchant_Null_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = new MerchantShopSystem(CreateMiddleRangeDictionary());

            if (testMerchantShopSystem.AddMerchant(null) == false)
            {
                return true;
            }

            throw new Exception();
        }
        
        
        #endregion

        public static void RunAllTests()
        {
            Test_GetMerchant_EmptyString_MiddleRange();
            Test_GetMerchant_NonExistentId_MiddleRange();
            Test_GetMerchant_NonExistentId_50000();
            Test_GetMerchant_ExistentId_MiddleRange();
            Test_GetMerchant_ExistentId_50000();
            Test_GetMerchant_ExistentId_50001();
            Test_GetMerchant_Null_MiddleRange();
            Test_GetMerchant_WhiteSpace_MiddleRange();

            Test_AddMerchant_Null_MiddleRange();
        }

        static int Main(string[] args)
        {
            RunAllTests();
            //Console.ReadLine();
            return 0;
        } 
    }

}
