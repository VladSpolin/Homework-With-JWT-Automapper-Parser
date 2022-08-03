using Microsoft.AspNetCore.Mvc;
using HomeworkApp.BusinessLogic.Interfaces;


namespace HomeworkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly IClothesService _clothesService;
        public ClothesController(IClothesService clothesService)
        {
            _clothesService = clothesService;
        }
        // GET: api/<ClothesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clothesService.GetAll());
        }

        // GET api/<ClothesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_clothesService.Get(id));
        }

        // POST api/<ClothesController>
        [HttpPost]
        public IActionResult Post()
        {
            _clothesService.Add();
            return Ok();
        }


        // DELETE api/<ClothesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clothesService.Delete(id);
            return Ok();
        }
    }
}
