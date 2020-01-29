using DDD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AlunoesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Alunoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {
            return await _context.Aluno.ToListAsync();
        }

        // GET: api/Alunoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(Guid id)
        {
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/Alunoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(Guid id, Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Alunoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.AlunoId }, aluno);
        }

        // DELETE: api/Alunoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(Guid id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        private bool AlunoExists(Guid id)
        {
            return _context.Aluno.Any(e => e.AlunoId == id);
        }
    }
}
