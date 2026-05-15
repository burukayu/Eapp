using Microsoft.AspNetCore.Mvc;
using EntityApp.Data;
using EntityApp.Models;

namespace EntityApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student);
        }
    }
}