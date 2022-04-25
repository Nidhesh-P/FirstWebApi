using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApi.Models;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace FirstWebApi.Controllers
{
    public class ProviderController : ApiController
    {
        [Authorize(Users ="admin")]
        public List<Provider> GetProviders()
        {
            return  Provider.GetProviderData(); 
        }


        [Authorize]
        public Provider GetProviderById(int id)
        {
            return Provider.GetProviderDataByProviderId(id);
        }

        //[HttpPost]
        //public void AddProvider(Object p)
        //{
        //    var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString()); 

        //    Provider.InsertProvider(provider);
        //}


        [HttpPost]
        public void AddProvider([FromBody] Provider p)
        {
            //var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString());

             Provider.InsertProvider(p);
        }

        //[HttpPost]
        //public void AddProvider([FromBody] Provider p)
        //{
        //    //var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString());

        //    Provider.InsertProvider(p);
        //}

        [HttpPatch]
        public void UpdateProvider([FromBody]Provider P)
        {
            Provider.UpdateProvider(P);
        }

        [HttpDelete]
        public void UpdateProvider(int id)
        {
            Provider.DeleteProvider(id);
        }

    }
}
