using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataRepository.Models.ELD.Prod1;

namespace EndorsementDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UndFormVersionsController : ControllerBase
    {
        private readonly ELD_PRODUCTION_31Context _context;

        public UndFormVersionsController(ELD_PRODUCTION_31Context context)
        {
            _context = context;
        }

        // GET: api/UndFormVersions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UndFormVersion>>> GetUndFormVersion()
        {
            return await _context.UndFormVersion.ToListAsync();
        }

        // GET: api/UndFormVersions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UndFormVersion>> GetUndFormVersion(int id)
        {
            var undFormVersion = await _context.UndFormVersion.FindAsync(id);

            if (undFormVersion == null)
            {
                return NotFound();
            }

            return undFormVersion;
        }

        // PUT: api/UndFormVersions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUndFormVersion(int id, UndFormVersion undFormVersion)
        {
            if (id != undFormVersion.FormVersionId)
            {
                return BadRequest();
            }

            _context.Entry(undFormVersion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UndFormVersionExists(id))
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

        // POST: api/UndFormVersions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UndFormVersion>> PostUndFormVersion(UndFormVersion undFormVersion)
        {
            _context.UndFormVersion.Add(undFormVersion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUndFormVersion", new { id = undFormVersion.FormVersionId }, undFormVersion);
        }

        // DELETE: api/UndFormVersions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUndFormVersion(int id)
        {
            var undFormVersion = await _context.UndFormVersion.FindAsync(id);
            if (undFormVersion == null)
            {
                return NotFound();
            }

            _context.UndFormVersion.Remove(undFormVersion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UndFormVersionExists(int id)
        {
            return _context.UndFormVersion.Any(e => e.FormVersionId == id);
        }
    }
}
