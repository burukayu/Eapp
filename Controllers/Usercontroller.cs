using EntityApp.Data;
using EntityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return Ok(_con.Users.ToList());
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
       [HttpDelete("{userId}")]
        public IActionResult ForgetUser(Guid userId)
        {
            var user = _con.Users.FirstOrDefault(x => x.userId == userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            _con.Users.Remove(user);

            var res = _con.SaveChanges();

            if (res > 0)
                return Ok("Successfully deleted");

            return BadRequest("Cannot delete user");
        }
                
    }
}