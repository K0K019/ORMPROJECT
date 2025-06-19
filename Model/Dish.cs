using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Dish
    {
     
        public int DishId { get; set; }

      
        public string Name { get; set; }


        public string Description { get; set; }

   
        public decimal Price { get; set; }

        public int WeightGrams { get; set; }

        public int DishTypeId { get; set; }

    
        public DishType DishType { get; set; }
    }
}
