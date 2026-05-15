using EntityApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EntityApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        
        private readonly AppDbContext _con;
        public CourseController(AppDbContext con)
        {
            _con =con;
        }

        [HttpGet]
        public IActionResult getcourses()
        {
            return Ok(_con.Courses.ToList());
        }
    }
}