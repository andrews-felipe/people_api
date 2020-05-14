using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using people_api.Data;
using people_api.Models;

namespace People_api.Controllers
{
    [Route("api/pessoas")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // Instancia do bando context
        private readonly DataContext _context;

        // Inciando construtor injetando o context
        public PeopleController(DataContext context)
        {
            _context = context;
        }

        // Listar todas as pessoas cadastradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> List()
        {
            return await _context.Peoples.ToListAsync();
        }


        // Consultar por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetById(long id)
        {
            var people = await _context.Peoples.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            return people;
        }

        // Atualizar pessoa
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, People people)
        {
            if (id != people.Id)
            {
                return BadRequest();
            }
            _context.Entry(people).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
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

        // Cadastrar Pessoa
        [HttpPost]
        public async Task<ActionResult<People>> Post(People people)
        {
            _context.Peoples.Add(people);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new { id = people.Id }, people);
        }

        // Excluir Pessoa
        [HttpDelete("{id}")]
        public async Task<ActionResult<People>> Delete(long id)
        {
            var people = await _context.Peoples.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            _context.Peoples.Remove(people);
            await _context.SaveChangesAsync();
            return people;
        }

        // Método que verifica se há um usuário na base com o id fornecido
        private bool Exists(long id)
        {
            return _context.Peoples.Any(e => e.Id == id);
        }
    }
}
