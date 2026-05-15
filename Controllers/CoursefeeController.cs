using Microsoft.AspNetCore.Mvc;
using EntityApp.Data;
using EntityApp.Models;

namespace EntityApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseFeeController : ControllerBase
    {
        private readonly AppDbContext _con; 
        public CourseFeeController (AppDbContext con)
        {
            _con=con;
            
        }
         
         [HttpGet]

         public IActionResult getFee()
        {
            return Ok(_con.CourseFees.ToList());
        }


    }
    
}