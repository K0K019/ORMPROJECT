using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class DishType
    {

        public int DishTypeId { get; set; }

    
        public string TypeName { get; set; }

        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
