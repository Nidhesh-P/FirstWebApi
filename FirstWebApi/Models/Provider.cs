using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

        private static string connectionString = @"Data Source=LAPTOP-HKBN8ODT\NIDHESH;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing2";

        public static List<Provider> GetProviderData()
        {
            List<Provider> p = new List<Provider>();
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand command = new SqlCommand("select * from Provider", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(command);
            DataSet ds = new DataSet();


            adaptor.Fill(ds);
            foreach (DataRow data in ds.Tables[0].Rows)
            {
                p.Add(new Provider()
                {
                    ProviderId = Convert.ToInt32(data[0].ToString()),
                    ProviderName = data[1].ToString(),
                    ProviderType = data[2].ToString()
                });
            }

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
                    ProviderType = data[2].ToString()
                });
            }

            return p.FirstOrDefault();
        }

        internal static void InsertProvider(Provider p)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"insert into Provider (ProviderName, ProviderType) values ('{p.ProviderName}','{p.ProviderType}')";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        internal static void UpdateProvider(Provider p)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"update provider set providertype='{p.ProviderType}', providername='{p.ProviderName}' where providerid={p.ProviderId}";
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