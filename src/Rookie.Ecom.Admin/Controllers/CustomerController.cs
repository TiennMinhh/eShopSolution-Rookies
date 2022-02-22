using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using System;
using System.Threading.Tasks;

namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IIdentityProviderService _identityProviderService;
        public CustomerController(IIdentityProviderService identityProviderService)
        {
            _identityProviderService = identityProviderService;
        }

        [HttpGet]
        public async Task<ActionResult> HelloAsync([FromQuery] string yourName)
        {
            var result = await _identityProviderService.SayHello(yourName);
            return Ok(result);
        }
    }
}
