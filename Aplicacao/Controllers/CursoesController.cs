﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DDD.Data;
using DDD.Models;

namespace DDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public CursoesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Cursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            return await _context.Curso.ToListAsync();
        }

        // GET: api/Cursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(Guid id)
        {
            var curso = await _context.Curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(Guid id, Curso curso)
        {
            if (id != curso.CursoId)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/Cursoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso", new { id = curso.CursoId }, curso);
        }

        // DELETE: api/Cursoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Curso>> DeleteCurso(Guid id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();

            return curso;
        }

        private bool CursoExists(Guid id)
        {
            return _context.Curso.Any(e => e.CursoId == id);
        }
    }
}
