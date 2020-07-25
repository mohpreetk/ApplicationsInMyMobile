using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationsInMyMobile.Data;
using ApplicationsInMyMobile.Models;

namespace ApplicationsInMyMobile.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Apps
        [HttpGet]
        public IEnumerable<App> GetApp()
        {
            return _context.App;
        }

        // GET: api/Apps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var app = await _context.App.FindAsync(id);

            if (app == null)
            {
                return NotFound();
            }

            return Ok(app);
        }

        // PUT: api/Apps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApp([FromRoute] int id, [FromBody] App app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != app.Id)
            {
                return BadRequest();
            }

            _context.Entry(app).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppExists(id))
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

        // POST: api/Apps
        [HttpPost]
        public async Task<IActionResult> PostApp([FromBody] App app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.App.Add(app);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApp", new { id = app.Id }, app);
        }

        // DELETE: api/Apps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var app = await _context.App.FindAsync(id);
            if (app == null)
            {
                return NotFound();
            }

            _context.App.Remove(app);
            await _context.SaveChangesAsync();

            return Ok(app);
        }

        private bool AppExists(int id)
        {
            return _context.App.Any(e => e.Id == id);
        }
    }
}