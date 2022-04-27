using FirstWebApi.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace FirstWebApi.Handlers
{
    public class ApiSecurityHandler : DelegatingHandler
    {
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var queryString = request.RequestUri.ParseQueryString();
             if (queryString.Count != 0)
            {
                var apiKey = queryString["apiKey"].ToString();

                var name = ValidateApiKey(apiKey);
                var principal = new ClaimsPrincipal(new GenericIdentity(name));

                HttpContext.Current.User = principal;
            }
            return base.SendAsync(request, cancellationToken);
        }

        private string ValidateApiKey(string apiKey)
        {
            ProductDatabaseEntities1 entity = new ProductDatabaseEntities1();

            string user = entity.Users.Where(x => x.UserKey == apiKey).FirstOrDefault().UserName;

            return user;
        }
    }
}