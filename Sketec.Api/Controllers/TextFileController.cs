using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sketec.FileWriter.Textfile;

namespace Sketec.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("textfile")]
    public class TextFileController : Controller
    {
        private readonly TextFileManager _manager;

        //public TextFileController(TextFileManager manager)
        //{
        //    _manager = manager;
        //}
        
        //[HttpGet("wht_request")]
        //public async Task<IActionResult> WhtRequest()
        //{
        //    await _manager.GenerateWhtRequest();
        //    return NoContent();
        //}
        
        //[HttpGet("wht_response")]
        //public async Task<IActionResult> WhtResponse()
        //{
        //    await _manager.ReadWhtResponse();
        //    return NoContent();
        //}
        
        //[HttpGet("rpa")]
        //public async Task<IActionResult> Rpa()
        //{
        //    await _manager.GenerateRpaRequest();
        //    return NoContent();
        //}
        
        //[HttpGet("rpa_ar")]
        //public async Task<IActionResult> RpaAr()
        //{
        //    await _manager.GenerateRpaArRequest();
        //    return NoContent();
        //}

        //[HttpGet("rpa_read")]
        //public async Task<IActionResult> RpaRead()
        //{
        //    await _manager.ReadRpaResponse();
        //    return NoContent();
        //}
        
        //[HttpGet("rpa_read_pdf")]
        //public async Task<IActionResult> RpaPdfRead()
        //{
        //    await _manager.ReadRpaPdfResponse();
        //    return NoContent();
        //}

        //[HttpGet("post_clearing_request")]
        //public async Task<IActionResult> PostClearingRequest()
        //{
        //    await _manager.GeneratePostClearing();
        //    return NoContent();
        //}
        
        //[HttpGet("post_clearing_response")]
        //public async Task<IActionResult> PostClearingResponse()
        //{
        //    await _manager.ReadPostClearing();
        //    return NoContent();
        //}
        
        //[HttpGet("baseline_request")]
        //public async Task<IActionResult> BaseLineRequest()
        //{
        //    await _manager.BaseLineRequest();
        //    return NoContent();
        //}
    }
}