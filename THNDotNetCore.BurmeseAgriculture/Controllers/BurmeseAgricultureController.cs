using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace THNDotNetCore.BurmeseAgricultureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurmeseAgricultureController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var filePath = "wwwroot/Data/BurmeseAgriculture.json";
            string JsonStr = System.IO.File.ReadAllText(filePath);
            var result = JsonConvert.DeserializeObject<BurmeseAgricultureReponseModel>(JsonStr);
            return Ok(result.Tbl_BurmeseAgriculture);
        }
    }
}




