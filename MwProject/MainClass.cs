using System;
using System.CodeDom;
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

        public static MerchantShopSystem CreateEmptyDictionary()
        {
            Dictionary<string, Merchant> merchantDictionary = new Dictionary<string, Merchant>();
            Dictionary<string, List<Merchant>> merchantsByType = new Dictionary<string, List<Merchant>>();
            MerchantShopSystem aMerchantShopSystem = new MerchantShopSystem(merchantDictionary, merchantsByType);
            return aMerchantShopSystem;
        }

        public static MerchantShopSystem Create50000Dictionary()
        {
            int shopcount = 0;
            Dictionary<string, Merchant> merchantDictionary = new Dictionary<string, Merchant>();
            Dictionary<string, List<Merchant>> merchantsByType = new Dictionary<string, List<Merchant>>();
            
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
                merchantDictionary.Add(merchant.MerchantId, merchant);
                
                if (merchantsByType.ContainsKey(merchant.MerchantType))
                {
                    merchantsByType[merchant.MerchantType].Add(merchant);
                }
                else
                {
                    merchantsByType.Add(merchant.MerchantType, new List<Merchant>() { merchant });
                }
            }

            MerchantShopSystem aMerchantShopSystem = new MerchantShopSystem(merchantDictionary, merchantsByType);
            return aMerchantShopSystem;
        }

        public static MerchantShopSystem Create50001Dictionary()
        {
            int shopcount = 0;
            Dictionary<string, Merchant> merchantDictionary = new Dictionary<string, Merchant>();
            Dictionary<string, List<Merchant>> merchantsByType = new Dictionary<string, List<Merchant>>();

            List<Merchant> merchantList = new List<Merchant>();

            merchantList.AddRange(AddMerchantToDictionary(14, 50000, false));
            merchantList.AddRange(AddMerchantToDictionary(36, 5000, false));
            merchantList.AddRange(AddMerchantToDictionary(102, 500, false));
            merchantList.AddRange(AddMerchantToDictionary(207, 50, false));
            merchantList.AddRange(AddMerchantToDictionary(1002, 5, false));
            merchantList.AddRange(AddMerchantToDictionary(5001, 2, false));
            merchantList.AddRange(AddMerchantToDictionary(43638, 1, false));
            merchantList.Add(new Merchant("MIN50001", "ExtraMerchant", "fastfood"));

            foreach (Merchant merchant in merchantList)
            {
                merchantDictionary.Add(merchant.MerchantId, merchant);

                if (merchantsByType.ContainsKey(merchant.MerchantType))
                {
                    merchantsByType[merchant.MerchantType].Add(merchant);
                }
                else
                {
                    merchantsByType.Add(merchant.MerchantType, new List<Merchant>() { merchant });
                }
            }

            MerchantShopSystem aMerchantShopSystem = new MerchantShopSystem(merchantDictionary, merchantsByType);
            return aMerchantShopSystem;
        }

        public static MerchantShopSystem CreateSoloDictionary()
        {
            Dictionary<string, Merchant> merchantDictionary = new Dictionary<string, Merchant>();
            Dictionary<string, List<Merchant>> merchantsByType = new Dictionary<string, List<Merchant>>();
            Merchant lonelyMerchant = new Merchant("MIN1", "Belfast Coffee company", "restaurant");

            merchantDictionary.Add(lonelyMerchant.MerchantId, lonelyMerchant);
            merchantsByType.Add(lonelyMerchant.MerchantType, new List<Merchant>() { lonelyMerchant });
            MerchantShopSystem aMerchantShopSystem = new MerchantShopSystem(merchantDictionary, merchantsByType);
            return aMerchantShopSystem;
        }

        public static MerchantShopSystem CreateMiddleRangeDictionary()
        {
            int shopcount = 0;
            Dictionary<string, Merchant> merchantDictionary = new Dictionary<string, Merchant>();
            Dictionary<string, List<Merchant>> merchantsByType = new Dictionary<string, List<Merchant>>();

            List<Merchant> merchantList = new List<Merchant>(AddMerchantToDictionary(25000, 20, true));

            foreach (Merchant merchant in merchantList)
            {
                merchantDictionary.Add(merchant.MerchantId, merchant);

                if (merchantsByType.ContainsKey(merchant.MerchantType))
                {
                    merchantsByType[merchant.MerchantType].Add(merchant);
                }
                else
                {
                    merchantsByType.Add(merchant.MerchantType, new List<Merchant>() { merchant });
                }
            }

            MerchantShopSystem aMerchantShopSystem = new MerchantShopSystem(merchantDictionary, merchantsByType);
            return aMerchantShopSystem;
        }
        
        #endregion

        #region GetMerchant test cases
        public static bool Test_GetMerchant_Null_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();
            
            if (testMerchantShopSystem.GetMerchant(null) == null)
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_GetMerchant_EmptyString_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.GetMerchant("") == null)
            {
                return true;
            }
            throw new Exception();
        }

        public static bool Test_GetMerchant_WhiteSpace_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.GetMerchant("       ") == null)
            {
                return true;
            }
            throw new Exception();
        }

        public static bool Test_GetMerchant_NonExistentId_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.GetMerchant("Nonexistent") == null)
            {
                return true;
            }
            throw new Exception();
        }

        public static bool Test_GetMerchant_NonExistentId_50000()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = Create50000Dictionary();

            if (testMerchantShopSystem.GetMerchant("Nonexistent") == null)
            {
                return true;
            }
            throw new Exception();
        }


        public static bool Test_GetMerchant_ExistentId_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.GetMerchant("MIN5").MerchantId.Equals("MIN5"))
            {
                return true;
            }
            throw new Exception();
        }

        public static bool Test_GetMerchant_ExistentId_50000()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = Create50000Dictionary();

            if (testMerchantShopSystem.GetMerchant("MIN50000").MerchantId.Equals("MIN50000"))
            {
                return true;
            }
            throw new Exception();
        }


        public static bool Test_GetMerchant_ExistentId_50001()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = Create50001Dictionary();

            if (testMerchantShopSystem.GetMerchant("MIN50001").MerchantId.Equals("MIN50001"))
            {
                return true;
            }
            throw new Exception();
        }
        #endregion

        #region CreateMerchant test cases

        public static bool Test_CreateMerchant_Null_NA()
        {
            MerchantIdCounter = 0;
            try
            {
                Merchant newMerchant = new Merchant(null, null, null);
            }
            catch (ArgumentException e)
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_CreateMerchant_Emptystring_NA()
        {
            MerchantIdCounter = 0;
            try
            {
                Merchant newMerchant = new Merchant("", "", "");
            }
            catch (ArgumentException e)
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_CreateMerchant_WhiteSpace_NA()
        {
            MerchantIdCounter = 0;
            try
            {
                Merchant newMerchant = new Merchant("    ", "    ", "    ");
            }
            catch (ArgumentException e)
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_CreateMerchant_ValidInput_NA()
        {
            MerchantIdCounter = 0;

            Merchant newMerchant = new Merchant("MIN1", "McDonalds", "fastfood");

            if (newMerchant.MerchantId.Equals("MIN1") && newMerchant.MerchantName.Equals("McDonalds") &&
                newMerchant.MerchantType.Equals("fastfood"))
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
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.AddMerchant(null) == false)
            {
                return true;
            }

            throw new Exception();
        }

        public static bool Test_AddMerchant_ValidMerchantNotYetThere_EmptyDictionary()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateEmptyDictionary();

            testMerchantShopSystem.AddMerchant(new Merchant("NewMerchant", "MerchantName", "fastfood"));

            if (testMerchantShopSystem.GetMerchant("NewMerchant").MerchantId.Equals("NewMerchant"))
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_AddMerchant_ValidMerchantNotYetThere_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            testMerchantShopSystem.AddMerchant(new Merchant("NewMerchant", "MerchantName", "fastfood"));

            if (testMerchantShopSystem.GetMerchant("NewMerchant").MerchantId.Equals("NewMerchant"))
            {
                return true;
            }

            throw new Exception();
        }

        public static bool Test_AddMerchant_ValidMerchantNotYetThere_50000Dictionary()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            testMerchantShopSystem.AddMerchant(new Merchant("NewMerchant", "MerchantName", "fastfood"));

            if (testMerchantShopSystem.GetMerchant("NewMerchant").MerchantId.Equals("NewMerchant"))
            {
                return true;
            }

            throw new Exception();
        }

        public static bool Test_AddMerchant_ValidMerchantAlreadyThere_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            testMerchantShopSystem.AddMerchant(new Merchant("NewMerchant", "MerchantName", "fastfood"));

            if (!testMerchantShopSystem.AddMerchant(new Merchant("NewMerchant", "MerchantName", "fastfood")))
            {
                return true;
            }

            throw new Exception();
        }

        #endregion

        #region AddShop test cases

        public static bool Test_AddShop_Null_NA()
        {
            Merchant newMerchant = new Merchant("MIN1", "McDonalds", "fastfood");

            if (!newMerchant.AddShop(null))
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_AddShop_ValidShopNotYetThere_NA()
        {
            Merchant newMerchant = new Merchant("MIN1", "McDonalds", "fastfood");

            if (newMerchant.AddShop(new Shop("SIN1", "Small Bob")))
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_AddShop_ValidShopAlreadyThere_NA()
        {
            Merchant newMerchant = new Merchant("MIN1", "McDonalds", "fastfood");

            newMerchant.AddShop(new Shop("SIN1", "Small Bob"));

            try
            {
                newMerchant.AddShop(new Shop("SIN1", "Small Bob"));
            }
            catch (Exception e)
            {
                return true;
            }

            throw new Exception();
        }

        #endregion

        #region CreateShop test cases

        public static bool Test_CreateShop_Null_NA()
        {
            MerchantIdCounter = 0;
            try
            {
                Shop newShop = new Shop(null, null);
            }
            catch (ArgumentException e)
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_CreateShop_Emptystring_NA()
        {
            MerchantIdCounter = 0;
            try
            {
                Shop newShop = new Shop("", "");
            }
            catch (ArgumentException e)
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_CreateShop_WhiteSpace_NA()
        {
            MerchantIdCounter = 0;
            try
            {
                Shop newShop = new Shop("     ", "     ");
            }
            catch (ArgumentException e)
            {
                return true;
            }

            throw new Exception();
        }


        public static bool Test_CreateShop_ValidInput_NA()
        {
            MerchantIdCounter = 0;

            Shop newMerchant = new Shop("SIN", "Small Bob");

            if (newMerchant.ShopId.Equals("SIN") && newMerchant.ShopManager.Equals("Small Bob"))
            {
                return true;
            }

            throw new Exception();
        }

        #endregion

        #region FindMerchant's Shops test case

        public static bool Test_FindMerchantShops_ValidInput_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            Merchant testMerchant = new Merchant("Test1", "TestMerchant", "fastfood");
            testMerchant.AddShop(new Shop("Shop1", "Small Bob"));
            testMerchant.AddShop(new Shop("Shop2", "Big Bob"));
            testMerchant.AddShop(new Shop("Shop3", "Medium Bob"));
            testMerchantShopSystem.AddMerchant(testMerchant);

            if (testMerchantShopSystem.FindShopsByMerchant("Test1").ContainsKey("Shop1") && testMerchantShopSystem.
                FindShopsByMerchant("Test1").ContainsKey("Shop2") &&
                testMerchantShopSystem.FindShopsByMerchant("Test1").ContainsKey("Shop3"))
            {
                return true;
            }

            throw new Exception();
        }

        #endregion

        #region GetShopByType test cases

        public static bool Test_GetMerchantsByType_Null_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.GetShopsByMerchantType(null) == null)
            {
                return true;
            }

            throw new Exception();
        }

        public static bool Test_GetMerchantsByType_EmptyString_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.GetShopsByMerchantType("") == null)
            {
                return true;
            }

            throw new Exception();
        }

        public static bool Test_GetMerchantsByType_Whitespace_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.GetShopsByMerchantType("          ") == null)
            {
                return true;
            }

            throw new Exception();
        }

        public static bool Test_GetMerchantsByType_ValidTypeNotFound_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            if (testMerchantShopSystem.GetShopsByMerchantType("gaming") == null)
            {
                return true;
            }

            throw new Exception();
        }

        public static bool Test_GetMerchantsByType_ValidTypeFound_MiddleRange()
        {
            MerchantIdCounter = 0;
            MerchantShopSystem testMerchantShopSystem = CreateMiddleRangeDictionary();

            Merchant testMerchant = new Merchant("Test1", "TestMerchant", "testType");
            testMerchant.AddShop(new Shop("Shop1", "Small Bob"));
            testMerchant.AddShop(new Shop("Shop2", "Big Bob"));
            testMerchant.AddShop(new Shop("Shop3", "Medium Bob"));
            testMerchantShopSystem.AddMerchant(testMerchant);

            if (testMerchantShopSystem.GetShopsByMerchantType("testType").Count == 3)
            {
                return true;
            }
            throw new Exception();
        }



        #endregion


        public static void RunAllTests()
        {
          /*Test_GetMerchant_EmptyString_MiddleRange();
            Test_GetMerchant_NonExistentId_MiddleRange();
            Test_GetMerchant_NonExistentId_50000();
            Test_GetMerchant_ExistentId_MiddleRange();
            Test_GetMerchant_ExistentId_50000();
            Test_GetMerchant_ExistentId_50001();
            Test_GetMerchant_Null_MiddleRange();
            Test_GetMerchant_WhiteSpace_MiddleRange();

            Test_CreateMerchant_Null_NA();
            Test_CreateMerchant_Emptystring_NA();
            Test_CreateMerchant_WhiteSpace_NA();
            Test_CreateMerchant_ValidInput_NA();

            Test_AddMerchant_Null_MiddleRange();
            Test_AddMerchant_ValidMerchantNotYetThere_EmptyDictionary();
            Test_AddMerchant_ValidMerchantNotYetThere_MiddleRange();
            Test_AddMerchant_ValidMerchantNotYetThere_50000Dictionary();
            Test_AddMerchant_ValidMerchantAlreadyThere_MiddleRange();

            Test_AddShop_Null_NA();
            Test_AddShop_ValidShopNotYetThere_NA();
            Test_AddShop_ValidShopAlreadyThere_NA();

            Test_CreateShop_Null_NA();
            Test_CreateShop_Emptystring_NA();
            Test_CreateShop_WhiteSpace_NA();
            Test_CreateShop_ValidInput_NA();

            Test_GetMerchantsByType_Null_MiddleRange();
            Test_GetMerchantsByType_EmptyString_MiddleRange();
            Test_GetMerchantsByType_Whitespace_MiddleRange();
            Test_GetMerchantsByType_ValidTypeNotFound_MiddleRange();
            Test_GetMerchantsByType_ValidTypeFound_MiddleRange();

            Test_FindMerchantShops_ValidInput_MiddleRange();*/
        }

        static int Main(string[] args)
        {
            RunAllTests();
            //Console.ReadLine();
            return 0;
        } 
    }

}
