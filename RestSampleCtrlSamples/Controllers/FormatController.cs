using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSample.Model;

namespace RestSampleCtrlSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        [HttpGet("str")]
        public string GetStr()
        {
            return "Heelo World";
        }

        [HttpGet("int")]
        public int GetInt() => 1;

        [HttpGet("object")]
        public Object GetObject() => new
        {
            FirstName="Hossein",
            LastName="Rahmati"
        };
    }
}
