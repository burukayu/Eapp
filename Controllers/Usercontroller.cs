using EntityApp.Data;
using EntityApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityApp.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly AppDbContext _con;
        public UserController(AppDbContext con)
        {
            _con=con;
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            return Ok(_con.user.ToList());
        }
        [HttpPost]
        public IActionResult createUser(User user)
        {  try{
            _con.Add(user);
          var res=  _con.SaveChanges();
          if(res==1)
            return Ok(user);
            else
            return BadRequest("some thing else");
        }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}