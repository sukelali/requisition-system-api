using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequisitionSystemApi.Data;

namespace RequisitionSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitionController : ControllerBase
    {
        private readonly RequisitionSystemApiContext _context;

        public RequisitionController(RequisitionSystemApiContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Get All Requisitions
        /// </summary>
        /// <response code="200">Requisition retrieved</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Requisition>>> GetRequisitions()
        {
            return await _context.Requisitions.Include( r => r.RequisitionItems).ToListAsync();
        }

        /// <summary>
        /// Gets a specific requisition by ID.
        /// </summary>
        /// <param name="id">The ID of the requisition.</param>
        /// <response code="200">Requisition retrieved </response>
        /// <response code="404">Requisition not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<ActionResult<Requisition>> GetRequisition(long id)
        {
            var requisition = await _context.Requisitions
                                                    .Include(r => r.RequisitionItems)
                                                    .SingleOrDefaultAsync( r => r.Id == id);

            if (requisition == null)
            {
                return NotFound();
            }

            return requisition;
        }


        /// <summary>
        /// Updates an existing requisition.
        /// </summary>
        /// <param name="id">The ID of the requisition to update.</param>
        /// <param name="requisition">The updated requisition.</param>
        /// <response code="204">Requisition Updated </response>
        /// <response code="400">Requisition Id Doesn't Match </response>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateRequisition(long id, [Bind("Buyer,CreatedBy,RequisitionItems")] Requisition requisition)
        {
            if (id != requisition.Id)
            {
                return BadRequest();
            }

            _context.Entry(requisition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisitionExists(id))
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



        /// <summary>
        /// Create a new requisition.
        /// </summary>
        /// <param name="requisition">The requisition to create.</param>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<Requisition>> CreateRequisition([Bind("Buyer,CreatedBy,RequisitionItems") ] Requisition requisition)
        {
            _context.Requisitions.Add(requisition);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequisition", new { id = requisition.Id }, requisition);
        }

        /// <summary>
        /// Deletes a specific requisition.
        /// </summary>
        /// <param name="id">The ID of the requisition to delete.</param>
        /// <response code="204"> Requisition Delete </response>
        /// <response code="404"> Requisition Not Found </response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisition(long id)
        {
            var requisition = await _context.Requisitions.FindAsync(id);
            if (requisition == null)
            {
                return NotFound();
            }

            _context.Requisitions.Remove(requisition);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool RequisitionExists(long id)
        {
            return _context.Requisitions.Any(e => e.Id == id);
        }
    }
}
