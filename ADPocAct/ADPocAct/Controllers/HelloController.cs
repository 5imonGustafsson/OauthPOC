using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Security.Claims;

namespace ADPocAct.Controllers
{
    [RoutePrefix("")]
    public class HelloController : ApiController
    {
        [Route("")]
        [Authorize]
        public IEnumerable<string> GetHelloWorld() => new[]
        {
            $"Hello {ClaimsPrincipal.Current.FindFirst("name")?.Value}"
        }.Concat(ClaimsPrincipal.Current.Claims.Select(c => $"{c.Value} ({c.Type})"));

        [Route("anon")]
        public IEnumerable<string> GetAnonymouseHello() => new[] {$"Hello, {ClaimsPrincipal.Current?.FindFirst("name")?.Value ?? "anon"}!"};
    }
}
