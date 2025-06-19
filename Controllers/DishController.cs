using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controllers
{
   public class DishController
    {
        private DishesContext _context = new DishesContext();

        public Dish Get(int id)
        {
            var dish = _context.Dishes.Find(id);
            if (dish != null)
                _context.Entry(dish).Reference(d => d.DishType).Load();
            return dish;
        }

        public List<Dish> GetAll()
        {
            return _context.Dishes.Include("DishType").ToList(); 
        }
        public void Create(Dish dish)
        {
            if (dish == null || string.IsNullOrWhiteSpace(dish.Name) || dish.Price <= 0 || dish.WeightGrams <= 0)
                return;

            _context.Dishes.Add(dish);
            _context.SaveChanges();
        }

        public void Update(int id, Dish dish)
        {
            var existing = _context.Dishes.Find(id);
            if (existing == null || dish == null) return;

            existing.Name = dish.Name;
            existing.Description = dish.Description;
            existing.Price = dish.Price;
            existing.WeightGrams = dish.WeightGrams;
            existing.DishTypeId = dish.DishTypeId;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dish = _context.Dishes.Find(id);
            if (dish == null) return;

            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }
    }
}