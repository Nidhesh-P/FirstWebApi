using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApi.Handlers;
using FirstWebApi.Models;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace FirstWebApi.Controllers
{
    public class ProviderController : ApiController
    {
        [ApiSecurityAuthorize(Roles ="admin")]
        public List<ProviderModel> GetProviders()
        {
            return ProviderModel.GetProviderData(); 
        }


        [ApiSecurityAuthorize(Roles = "user, admin")]
        public ProviderModel GetProviderById(int id)
        {
            return ProviderModel.GetProviderDataByProviderId(id);
        }

        //[HttpPost]
        //public void AddProvider(Object p)
        //{
        //    var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString()); 

        //    Provider.InsertProvider(provider);
        //}


        [HttpPost]
        public void AddProvider([FromBody] ProviderModel p)
        {
            //var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString());

            ProviderModel.InsertProvider(p);
        }

        //[HttpPost]
        //public void AddProvider([FromBody] Provider p)
        //{
        //    //var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString());

        //    Provider.InsertProvider(p);
        //}

        [HttpPatch]
        public void UpdateProvider([FromBody] ProviderModel P)
        {
            ProviderModel.UpdateProvider(P);
        }

        [HttpDelete]
        public void UpdateProvider(int id)
        {
            ProviderModel.DeleteProvider(id);
        }

    }
}
