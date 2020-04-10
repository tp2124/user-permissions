using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserPermissions.API.Data;
using UserPermissions.API.Models;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context) {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync(); // Need to use ToList() in order to evaluate the query.

            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string newUserName)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            newUserName = newUserName.ToLower();

            if (await _context.Users.AnyAsync(u => u.Username.Equals(newUserName)))
                return BadRequest("User already exists.");

            // Converting from Dto or input from client to Model to pass to Repository logic. Repository will be able to handle
            // both data formats (Dto and DB Models).
            User user = new User {
                Username = newUserName
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}