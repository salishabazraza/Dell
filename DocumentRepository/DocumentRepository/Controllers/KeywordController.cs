using DocumentRepository.API.CommonCode.Attributes;
using DocumentRepository.API.CommonCode.Helpers;
using DocumentRepository.BLL.Services;
using DocumentRepository.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DocumentRepository.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/", Order = 1)]
    [ApiVersion("1.0")]
    [APIAuthentication]
    public class KeywordController : Controller
    {
        
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           int UserId = SecurityTokenClaimHelper.GetUserIdFromToken(HttpContext);
            if (UserId > 0)
            {
                if (id > 0)
                {

                    var result = await KeywordLogicServices.Instance.GetKeywords(id);
                    return Ok(result);
                }
                return BadRequest();
            }
            return Unauthorized();
        }
        [HttpGet("all/records")]
        public async Task<IActionResult> Get()
        {
           int UserId = SecurityTokenClaimHelper.GetUserIdFromToken(HttpContext);
            if (UserId > 0)
            {
                var result = await KeywordLogicServices.Instance.GetKeywords(null);
                return Ok(result);
            }
            return Unauthorized();
        }
        [HttpPost("saveorupdate")]
        public async Task<IActionResult> POST(List<KeywordPostModel> model)
        {
           int UserId = SecurityTokenClaimHelper.GetUserIdFromToken(HttpContext);
            if (UserId > 0)
            {
                var result = await KeywordLogicServices.Instance.AddorUpdateKeywords(model, UserId);
                return Ok(result);
            }
            return Unauthorized();
        }
        [HttpPost("mapping/document/saveorupdate")]
        public async Task<IActionResult> POST(KeywordDocumentPostModel model)
        {
           int UserId = SecurityTokenClaimHelper.GetUserIdFromToken(HttpContext);
            if (UserId > 0)
            {
                var result = await KeywordLogicServices.Instance.AddorUpdateKeywordWithDocument(model, UserId);
                return Ok(result);
            }
            return Unauthorized();
        }
        [HttpPost("search/documents")]
        public async Task<IActionResult> Search(List<int> keywordIds, int pageNo = 1)
        {
            pageNo = pageNo > 0 ? pageNo : 1;
            int UserId = SecurityTokenClaimHelper.GetUserIdFromToken(HttpContext);
            if (UserId > 0)
            {
                var result = await KeywordLogicServices.Instance.SearchDocumentByKeywords(keywordIds, pageNo);
                return Ok(result);
            }
            return Unauthorized();
        }
        [HttpDelete("Delete/Keyword")]
        public async Task<IActionResult> Search(int keywordId)
        {
            int UserId = SecurityTokenClaimHelper.GetUserIdFromToken(HttpContext);
            if (UserId > 0)
            {
                var result = await KeywordLogicServices.Instance.DeletedKeywords(keywordId);
                return Ok(result);
            }
            return Unauthorized();
        }
    }
}
