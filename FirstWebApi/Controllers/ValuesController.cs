using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    [RoutePrefix("ValuesApi")]

    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("Default")]
        [HttpGet]
        public IEnumerable<string> Default()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("SearchOrders/{id}")]
        public string SearchOrders(int id)
        {
            return "Result :" + id.ToString(); ;
        }


        [HttpGet]
        [Route("SearchTypes")]
        public string SearchTypes()
        {
            return "SearchTypes";
        }

        [HttpGet]
        [Route("Search")]
        public string SearchProvider()
        {
            return "Search";
        }

        [HttpGet]
        public string Get()
        {
            return "Get";
        }


        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
