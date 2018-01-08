using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using PWService;
using PWEntity;
using System.Text;
using System.Security.Principal;
using System.Threading;

namespace PWApi.Attributes
{
    public class BasicAuthentication: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedCredential = actionContext.Request.Headers.Authorization.Parameter;
                string decodedCredential = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredential));
                string[] arr = decodedCredential.Split(':');
                string email = arr[0];
                string password = arr[1];

                UserDetailService userDetailService = new UserDetailService();
                int userId = userDetailService.Login(email, password);
                if (userId == 0)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userId.ToString(), email), new string[] { userId.ToString() });
                }
            }
        }
    }
}