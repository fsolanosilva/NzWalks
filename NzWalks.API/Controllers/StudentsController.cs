using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NzWalks.API.Controllers
{
    // GET: https://localhost:portnumber/api/studentes
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: https://localhost:portnumber/api/studentes
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studenteNames = new string[] { "Jhon", "Jane", "Mark", "Emily", "David" };

            return Ok(studenteNames);
        }
    }
}
