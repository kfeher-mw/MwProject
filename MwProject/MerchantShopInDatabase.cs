using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MwProject
{
    class MerchantShopInDatabase : IMerchantShop
    {

        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=MwProject;Integrated Security=True";
        
        public MerchantShopInDatabase(){}
        
        public Merchant GetMerchant(string merchantId)
        {
            //set the connection up
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                //set the command up
                SqlCommand command = new SqlCommand("uspGetMerchant", dbConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@merchant_id", SqlDbType.VarChar).Value = merchantId;
                
                //open connection and execute command
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string merchantIdFromDb = (string)reader["merchant_id"];
                        string merchantNameFromDb = (string)reader["merchant_name"];
                        string merchantTypeFromDb = (string)reader["merchant_type"];
                        return new Merchant(merchantIdFromDb, merchantNameFromDb, merchantTypeFromDb);
                    }
                }
                else
                {
                    return null;
                }
                reader.Close();
            }
            return null;
        }

        public Dictionary<string, Shop> FindShopsByMerchant(string merchantId)
        {
            Dictionary<string, Shop> returnDictionary = new Dictionary<string, Shop>();
            
            //set the connection up
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                //set the command up
                SqlCommand command = new SqlCommand("uspGetMerchantShops", dbConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@merchant_id", SqlDbType.VarChar).Value = merchantId;

                //open connection and execute command
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string shopIdFromDbFromDb = (string)reader["shop_id"];
                        string shopManagerFromDb = (string)reader["shop_manager"];
                        returnDictionary.Add(shopIdFromDbFromDb, new Shop(shopIdFromDbFromDb, shopManagerFromDb));
                    }
                }
                reader.Close();
            }
            return returnDictionary;
        }

        public Dictionary<string, List<Shop>> GetShopsByMerchantType(string merchantType)
        {
            Dictionary<string, List<Shop>> returnDictionary = new Dictionary<string, List<Shop>>();

            //set the connection up
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                //set the command up
                SqlCommand command = new SqlCommand("uspGetShopsByType", dbConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@shop_type", SqlDbType.VarChar).Value = merchantType;

                //open connection and execute command
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string shopIdFromDbFromDb = (string)reader["shop_id"];
                        string shopManagerFromDb = (string)reader["shop_manager"];
                        string merchantIdFromDb = (string)reader["merchant_id"];

                        if (returnDictionary.ContainsKey(merchantIdFromDb))
                        {
                            returnDictionary[merchantIdFromDb].Add(new Shop(shopIdFromDbFromDb, shopManagerFromDb));
                        }
                        else
                        {
                            List<Shop> currentShops = new List<Shop>();
                            currentShops.Add(new Shop(shopIdFromDbFromDb, shopManagerFromDb));
                            returnDictionary.Add(merchantIdFromDb, currentShops);
                        }
                    }
                }
                reader.Close();
            }
            return returnDictionary;
        }

        public bool AddMerchant(Merchant newMerchant)
        {
            return false;
        }

        public bool RemoveMerchant(string merchantId)
        {
            throw new NotImplementedException();
        }
    }
}
