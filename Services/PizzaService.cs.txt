using YourProjectName.Models;
using YourProjectName.Data;

namespace YourProjectName.Services
{
    public class PizzaService
    {
        private readonly ApplicationDbContext _context;

        public PizzaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pizza> GetAllPizzas() => _context.Pizzas.ToList();

        public Pizza? GetPizzaById(int id) => _context.Pizzas.FirstOrDefault(p => p.Id == id);

        public void AddPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }
    }
}
