using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestSampleCtrlSamples.Controllers
{
    [Route("api/[controller]")]
    public class MyController : ControllerBase
    {
        public string GetName()
        {
            return "My Hossein Rahmati";
        }

        [HttpGet("GetName1")]
        public string GetName1()
        {
            return "My Name 1 Hossein Rahmati ";
        }

        [HttpGet("GetName1/{id}")]
        public string GetName1(int id)
        {
            return $"My Name 1 Hossein Rahmati {id}";
        }

        [HttpGet("GetName2/{id}")]
        public IActionResult GetName2(int id)
        {
            return Ok($"My Name 2 Hossein Rahmati {id}");
        }


    }
}
