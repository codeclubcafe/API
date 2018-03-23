using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Coffee
    {
        public string Name { get; set;}
        public int Price { get; set; }
        public string Size { get; set;}

        public List<Coffee> GetAllCoffees()
        {
            var coffeelist = new List<Coffee>
            {
                new Coffee{ Name="Mocho", Price=2, Size="L"  },
                new Coffee{ Name="Latte", Price=3, Size="XL"  },
                new Coffee{ Name="Americano", Price=2, Size="L"  },
                new Coffee{ Name="Expresso", Price=1, Size="XS"  }

            };
           
            return coffeelist;
        }
    }


}
