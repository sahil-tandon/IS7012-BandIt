using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BandIt.Models;

namespace BandIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {

        private readonly AppDbContext _context;
        public ValuesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<int[]> Get() {
            return new int[] {1,2,3,4,5};
        }
    }
}