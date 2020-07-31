using AzureAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase{


        private readonly MedidContext _context;

        public SearchController(MedidContext context) {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Interaction> findUserInteraction(int id) {
            return  Ok(_context.Interaction
                .Where(s => s.Id1 == id).Select(s=> s.Id2).Distinct().ToList());
        } 

        
    }
}
