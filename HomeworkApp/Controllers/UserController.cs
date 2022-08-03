using Microsoft.AspNetCore.Mvc;
using HomeworkApp.BusinessLogic.Interfaces;
using HomeworkApp.Model.ViewModels.User;

namespace HomeworkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post(CreateUserViewModel model)
        {
            _userService.Create(model);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, EditUserViewModel model)
        {
            _userService.Edit(id, model);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
