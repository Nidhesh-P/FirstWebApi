using FirstWebApi.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FirstWebApi.Handlers
{
    public class ApiSecurityAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            var user = HttpContext.Current.User.Identity.Name;

            ProductDatabaseEntities2 entity = new ProductDatabaseEntities2();
            var role = entity.Users.Where(x => x.UserName == user).FirstOrDefault()?.Role;
            
            //var role = entity.Users.Where(x => x.UserName == user).FirstOrDefault()?.Role;


            var roles = Roles.Split(',');


            if (!Roles.Contains(role))
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage
                    (System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}