using System.Web.Http;
using System.Security.Claims;

namespace ADPocAct.Controllers
{
    [Authorize]
    [RoutePrefix("")]
    public class HelloController : ApiController
    {
        [Route("")]
        public string GetHelloWorld()
        {
            string owner = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value;
            return $"Hello {owner}";
        }
    }
}
