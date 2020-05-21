using Microsoft.AspNetCore.Mvc;

namespace prj_core_api.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class AlunoController : Controller
    {
        public AlunoController()
        {
            
        }
        [HttpGet()]
        public IActionResult get()
        {
            return Ok();            
        }

        [HttpGet("{Id}")]
        public IActionResult get(int Id)
        {
            return Ok();            
        }

        [HttpPost]
        public IActionResult post()
        {
            return Ok();            
        }

        [HttpPut("{Id}")]
        public IActionResult put(int Id)
        {
            return Ok();            
        }

        [HttpDelete("{Id}")]
        public IActionResult delete(int Id)
        {
            return Ok();
        }

    }
}