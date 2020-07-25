using AutoMapper;
using AzureAPI.Dtos;
using AzureAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAPI.Controllers {
    public class InteractionController : ControllerBase{
        private readonly MedidContext _context;
        private readonly IMapper _mapper;

        public InteractionController(MedidContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interaction>>> GetInteraction() {
            return await _context.Interaction.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetInteraction")]
        public async Task<ActionResult<Interaction>> GetInteraction(int id) {
            var interactionId = await _context.Interaction.FindAsync(id);
            if (interactionId == null) {
                return NotFound();
            }
            return Ok(interactionId);
        }

        [HttpPost]
        public async Task<ActionResult<Interaction>> PostInteraction(InteractionCreateDto interactionCreateDto) {
            var interaction = _mapper.Map<Interaction>(interactionCreateDto);
            await _context.SaveChangesAsync();
            return CreatedAtRoute(nameof(GetInteraction), new { id = interaction.InteractionId }, interaction);

        }
        
        [HttpPost]
        public async Task<ActionResult> PutInteraction(int id, Interaction interaction) {
            if (id != interaction.InteractionId) {
                return BadRequest();
            }
            _context.Entry(interaction).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!InteractionExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Interaction>> DeleteInteraction(int id) {
            var interaction = await _context.Interaction.FindAsync(id);
            if (interaction == null) {
                return NotFound();
            }
            _context.Interaction.Remove(interaction);
            await _context.SaveChangesAsync();
            return interaction;
        }

        private bool InteractionExists(int id) {
            return _context.Interaction.Any(e => e.InteractionId == id);
        }
    }


}
