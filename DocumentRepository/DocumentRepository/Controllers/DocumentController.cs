using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using DocumentRepository.API.CommonCode.Attributes;
using DocumentRepository.BLL.Services;
using DocumentRepository.Models;
using DocumentRepository.API.CommonCode.Helpers;

namespace DocumentRepository.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/", Order = 1)]
    [ApiVersion("1.0")]
    [APIAuthentication]
    public class DocumentController : Controller
    {
         
        [HttpGet("record/{id}")]
        public async Task<IActionResult> Get(int id)
        {
           int UserId = SecurityTokenClaimHelper.GetUserIdFromToken(HttpContext);
            if (UserId > 0)
            {
                if (id > 0)
                {
                    var result = await DocumentLogicServices.Instance.GetDocuments(id);
                    return Ok(result);
                }
                return BadRequest();
            }
            return Unauthorized();
        }
        [HttpGet("all/records")]
        public async Task<IActionResult> GetAll(int pageNo = 1)
        {
            pageNo = pageNo > 0 ? pageNo : 1;
           int UserId = SecurityTokenClaimHelper.GetUserIdFromToken(HttpContext);
            if (UserId > 0)
            {
                var result = await DocumentLogicServices.Instance.GetDocuments(null, pageNo);
                return Ok(result);
            }
            return Unauthorized();
        }
    }
}
