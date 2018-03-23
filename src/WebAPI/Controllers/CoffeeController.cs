using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [Authorize(Roles ="SuperStar")]
    [Produces("application/json")]
    [Route("api/Coffee")]
    public class CoffeeController : Controller
    {
        private Coffee _coffee;


        public CoffeeController(Coffee coffee)
        {
            _coffee = coffee  ;
        }
        // GET: api/Coffee
        [HttpGet]
        public List<Coffee> Get()
        {
            return _coffee.GetAllCoffees();
        }
        
        
    }
}
