using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controllers
{
   public class DishTypeController
    {
        private DishesContext _dishesContext = new DishesContext(); 

      
        public List<Dish> GetAllDishes()
        {
            return _dishesContext.Dishes.ToList();
        }

        public string GetDishById(int id)
        {
            var dish = _dishesContext.Dishes.Find(id);
            return dish != null ? dish.Name : "Непознато ястие";
        }

    }
}
