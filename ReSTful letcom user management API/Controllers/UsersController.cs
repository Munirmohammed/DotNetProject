using Microsoft.AspNetCore.Mvc;
using ReSTful_letcom_user_management_API.Models;
using ReSTful_letcom_user_management_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReSTful_letcom_user_management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<Users>> Get()
        {
            return userService.Get();
        }
           
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(string id)
        {
            var user = userService.Get(id);
            if (user == null)
            {

                return NotFound($"user with id = {id} couldn't be found");
            }
            return user;
        }

        // POST api/<UsersController>
        [HttpPost("register")]
        public ActionResult Post([FromBody] Users users)
        {
            userService.Create(users);
            return CreatedAtAction(nameof(Get), new {id = users.Id}, users);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Users users)
        {
            var existingUser = userService.Get(id);
            if (existingUser == null)
            {
                return NotFound($"user with id = {id} couldn't be found");
            }
            userService.Update(id, users);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var user = userService.Get(id);
            if (user == null )
            {
                return NotFound($"user with id = {id} couldn't be found");
            }
            userService.Remove(user.Id);
            return Ok($"user with id  = {id} deleted successfully!!");
        }
    }
}
