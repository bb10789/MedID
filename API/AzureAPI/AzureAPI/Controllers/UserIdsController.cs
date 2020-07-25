using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AzureAPI.Model;
using AzureAPI.Dtos;
using AutoMapper;

namespace AzureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIdsController : ControllerBase
    {
        private readonly MedidContext _context;
        private readonly IMapper _mapper;

        public UserIdsController(MedidContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/UserIds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserId>>> GetUserId()
        {
            return await _context.UserId.ToListAsync();
        }

        // GET: api/UserIds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserId>> GetUserId(int id)
        {
            var userId = await _context.UserId.FindAsync(id);

            if (userId == null)
            {
                return NotFound();
            }

            return userId;
        }

        // PUT: api/UserIds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserId(int id, UserId userId)
        {
            if (id != userId.Id)
            {
                return BadRequest();
            }

            _context.Entry(userId).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserIdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserIds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserId>> PostUserId(UserIdCreateDto userIdCreateDto)
        {
            var userId = _mapper.Map<UserId>(userIdCreateDto);
            _context.UserId.Add(userId);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserIdExists(userId.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetUserId", new { id = userId.Id }, userIdCreateDto);
        }

        // DELETE: api/UserIds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserId>> DeleteUserId(int id)
        {
            var userId = await _context.UserId.FindAsync(id);
            if (userId == null)
            {
                return NotFound();
            }

            _context.UserId.Remove(userId);
            await _context.SaveChangesAsync();

            return userId;
        }

        private bool UserIdExists(int id)
        {
            return _context.UserId.Any(e => e.Id == id);
        }
    }
}
