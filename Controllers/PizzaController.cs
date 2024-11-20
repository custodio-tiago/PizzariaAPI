using Microsoft.AspNetCore.Mvc;
using YourProjectName.Models;
using YourProjectName.Services;

namespace YourProjectName.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET /api/pizza
        [HttpGet]
        public IActionResult GetAll()
        {
            var pizzas = _pizzaService.GetAllPizzas();
            return Ok(pizzas);
        }

        // GET /api/pizza/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var pizza = _pizzaService.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound(new { message = $"Pizza com ID {id} não encontrada." });
            }
            return Ok(pizza);
        }

        // POST /api/pizza
        [HttpPost]
        public IActionResult Create([FromBody] Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPizza = _pizzaService.CreatePizza(pizza);
            return CreatedAtAction(nameof(GetById), new { id = createdPizza.Id }, createdPizza);
        }

        // PUT /api/pizza/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Pizza updatedPizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pizza = _pizzaService.UpdatePizza(id, updatedPizza);
            if (pizza == null)
            {
                return NotFound(new { message = $"Pizza com ID {id} não encontrada." });
            }

            return Ok(pizza);
        }

        // PATCH /api/pizza/{id}
        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, [FromBody] Pizza updatedProperties)
        {
            var pizza = _pizzaService.PatchPizza(id, updatedProperties);
            if (pizza == null)
            {
                return NotFound(new { message = $"Pizza com ID {id} não encontrada." });
            }

            return Ok(pizza);
        }

        // DELETE /api/pizza/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _pizzaService.DeletePizza(id);
            if (!result)
            {
                return NotFound(new { message = $"Pizza com ID {id} não encontrada." });
            }

            return NoContent();
        }
    }
}
