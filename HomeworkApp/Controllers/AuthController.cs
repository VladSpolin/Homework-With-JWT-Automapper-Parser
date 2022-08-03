using Microsoft.AspNetCore.Mvc;
using HomeworkApp.BusinessLogic.Interfaces;
using HomeworkApp.Model.ViewModels.Auth;


namespace HomeworkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IActionResult Get(TokenViewModel model)
        {
            return Ok(_authService.SingIn(model));
        }
     
    }
}
