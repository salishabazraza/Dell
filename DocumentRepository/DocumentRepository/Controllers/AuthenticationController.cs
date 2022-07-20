using DocumentRepository.BLL.Models;
using DocumentRepository.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DocumentRepository.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]", Order = 1)]
    [ApiVersion("1.0")]
    public class AuthenticationController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginLogicModel model)
        {
            var result = await LoginLogicServices.Instance.LoginVerify(model);
            return Ok(result);
        }
    }
}
