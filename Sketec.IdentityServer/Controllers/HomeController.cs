using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Sketec.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        IAntiforgery antiforgery;
        TelemetryClient telemetry;
        public HomeController(IAntiforgery antiforgery, TelemetryClient telemetry)
        {
            this.antiforgery = antiforgery;
            this.telemetry = telemetry;
        }

        [HttpGet("App")]
        public string App()
        {
            telemetry.TrackEvent("Wakanda Forever");

            return "Wakanda Forevera1z";
        }

        [HttpGet("CSRF")]
        public AntiforgeryTokenSet GenerateCSRF()
        {

            var token = antiforgery.GetAndStoreTokens(HttpContext);

            return token;
        }

        [HttpGet("Validate")]
        public async Task<bool> ValidateCSRFAsync()
        {
            await antiforgery.ValidateRequestAsync(HttpContext);
            return true;
        }
    }
}
