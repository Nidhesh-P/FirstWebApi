using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FirstWebApi.DataObject;


namespace FirstWebApi.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public String State { get; set; }

        private static string connectionString = @"Data Source=DESKTOP-9AO2BIN;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing2";

        public static List<Provider> GetProviderData()
        {
            List<Provider> p = new List<Provider>();
            //SqlConnection conn = new SqlConnection(connectionString);

            //conn.Open();
            //SqlCommand command = new SqlCommand("select * from Provider", conn);
            //SqlDataAdapter adaptor = new SqlDataAdapter(command);
            //DataSet ds = new DataSet();


            //adaptor.Fill(ds);


            ProductDatabaseEntities entity = new ProductDatabaseEntities();
            var result = entity.Providers.ToList();



            //foreach (DataRow data in ds.Tables[0].Rows)
            //{
            //    p.Add(new Provider()
            //    {
            //        ProviderId = Convert.ToInt32(data[0].ToString()),
            //        ProviderName = data[1].ToString(),
            //        ProviderType = data[2].ToString(),
            //        Address= data["Address"].ToString(),
            //        City = data["City"].ToString(),
            //        State = data["State"].ToString(),
            //    });
            //}

            return p;
        }

        public static Provider GetProviderDataByProviderId(int id)
        {
            List<Provider> p = new List<Provider>();
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand command = new SqlCommand($"select * from Provider where providerid = {id}", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);            

            foreach (DataRow data in ds.Tables[0].Rows)
            {
                p.Add(new Provider()
                {
                    ProviderId = Convert.ToInt32(data[0].ToString()),
                    ProviderName = data[1].ToString(),
                    ProviderType = data[2].ToString(),
                    Address = data["Address"].ToString(),
                    City = data["City"].ToString(),
                    State = data["State"].ToString(),
                });
            }

            return p.FirstOrDefault();
        }

        internal static void InsertProvider(Provider p)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"insert into Provider (ProviderName, ProviderType, Address, City, State) values " +
                $"('{p.ProviderName}','{p.ProviderType}','{p.Address}','{p.City}','{p.State}')";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        internal static void UpdateProvider(Provider p)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"update provider set providertype='{p.ProviderType}', providername='{p.ProviderName}' " +
                $", Address='{p.Address}', City='{p.City}', State='{p.State}' where providerid={p.ProviderId}";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        internal static void DeleteProvider(int p)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"Delete provider where providerid={p}";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }        
    }
}