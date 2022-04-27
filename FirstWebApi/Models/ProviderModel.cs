using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FirstWebApi.DataObject;
using FirstWebApi.Handlers;

namespace FirstWebApi.Models
{
    public class ProviderModel
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public String State { get; set; }

        private static string connectionString = @"Data Source=DESKTOP-9AO2BIN;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing2";

        public static List<ProviderModel> GetProviderData()
        {
            List<ProviderModel> p = new List<ProviderModel>();
            //SqlConnection conn = new SqlConnection(connectionString);

            //conn.Open();
            //SqlCommand command = new SqlCommand("select * from Provider", conn);
            //SqlDataAdapter adaptor = new SqlDataAdapter(command);
            //DataSet ds = new DataSet();
            //adaptor.Fill(ds);

            ProductDatabaseEntities1 entity = new ProductDatabaseEntities1();
            var result = entity.Providers.ToList();

            foreach (var data in result)
            {
                p.Add(new ProviderModel()
                {
                    ProviderId = Convert.ToInt32(data.ProviderId),
                    ProviderName = data.ProviderName,
                    ProviderType = data.ProviderType,
                    Address = data.Address,
                    City = data.City,
                    State = data.State,
                });
            }

            return p;
        }

        public static ProviderModel GetProviderDataByProviderId(int id)
        {
            ProviderModel p = new ProviderModel();
            //SqlConnection conn = new SqlConnection(connectionString);

            //conn.Open();
            //SqlCommand command = new SqlCommand($"select * from Provider where providerid = {id}", conn);
            //SqlDataAdapter adaptor = new SqlDataAdapter(command);
            //DataSet ds = new DataSet();
            //adaptor.Fill(ds);
            
            //foreach (DataRow data in ds.Tables[0].Rows)
            //{
            //    p.Add(new ProviderModel()
            //    {
            //        ProviderId = Convert.ToInt32(data[0].ToString()),
            //        ProviderName = data[1].ToString(),
            //        ProviderType = data[2].ToString(),
            //        Address = data["Address"].ToString(),
            //        City = data["City"].ToString(),
            //        State = data["State"].ToString(),
            //    });
            //}

            //return p.FirstOrDefault();


            ProductDatabaseEntities1 entity = new ProductDatabaseEntities1();
            var result = entity.Providers.Where(pr => pr.ProviderId == id).FirstOrDefault();

            var mapper = AutoMapperConfig.AutoMapperConfiguration();
            mapper.Map(result, p);

            return p;            
        }

        internal static void InsertProvider(ProviderModel p)
        {
            //SqlConnection conn = new SqlConnection(connectionString);

            //string insertCmd = $"insert into Provider (ProviderName, ProviderType, Address, City, State) values " +
            //    $"('{p.ProviderName}','{p.ProviderType}','{p.Address}','{p.City}','{p.State}')";
            //conn.Open();
            //SqlCommand command = new SqlCommand(insertCmd, conn);
            //command.ExecuteNonQuery();

            Provider newProvider = new Provider();
            var mapper = AutoMapperConfig.AutoMapperConfiguration();
            mapper.Map(p, newProvider);

            newProvider = new Provider()
            {
                Address = p.Address,

            };


            ProductDatabaseEntities1 entity = new ProductDatabaseEntities1();
            entity.Providers.Add(newProvider);
            entity.SaveChanges();
        }

        internal static void UpdateProvider(ProviderModel p)
        {
            //SqlConnection conn = new SqlConnection(connectionString);

            //string insertCmd = $"update provider set providertype='{p.ProviderType}', providername='{p.ProviderName}' " +
            //    $", Address='{p.Address}', City='{p.City}', State='{p.State}' where providerid={p.ProviderId}";
            //conn.Open();
            //SqlCommand command = new SqlCommand(insertCmd, conn);
            //command.ExecuteNonQuery();

            ProductDatabaseEntities1 entity = new ProductDatabaseEntities1();
            var providerToBeUpdated = entity.Providers.Where(pr => pr.ProviderId == p.ProviderId).FirstOrDefault();

            //var mapper = AutoMapperConfig.AutoMapperConfiguration();
            //mapper.Map(p, providerToBeUpdated);

            providerToBeUpdated.ProviderName = p.ProviderName;
            providerToBeUpdated.ProviderType = p.ProviderType;
            providerToBeUpdated.City = p.City;
            providerToBeUpdated.Address = p.Address;
            providerToBeUpdated.State = p.State;

            entity.SaveChanges();
        }

        internal static void DeleteProvider(int p)
        {
            //SqlConnection conn = new SqlConnection(connectionString);

            //string insertCmd = $"Delete provider where providerid={p}";
            //conn.Open();
            //SqlCommand command = new SqlCommand(insertCmd, conn);
            //command.ExecuteNonQuery();
            

            ProductDatabaseEntities1 entity = new ProductDatabaseEntities1();
            var providerToBeDeleted = entity.Providers.Where(pr => pr.ProviderId == p).FirstOrDefault();
            entity.Providers.Remove(providerToBeDeleted);
            entity.SaveChanges();


        }
    }
}