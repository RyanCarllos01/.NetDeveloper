using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        // está recebendo via contrutor pro _context e está passando pro context
        // isso se chama injeção de dependencias
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            // pra todos menos o Http get vai usar o .savechanges
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterporID), new {id = contato.Id}, contato);
        }

        // procurando contato por id 
        [HttpGet("{id}")]
        public IActionResult ObterporID(int id)
        {
            var contato = _context.Contatos.Find(id);

            //validando se passamos o id errado
            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        // Procurando contato por nome
        [HttpGet("ObterPorNome")]
        public IActionResult ObterporNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }
        //criando update 
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);
            // esse contato banco é o contato que está no banco de dados 
            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        // Criando endpoint de delete
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);
            // esse contato banco é o contato que está no banco de dados 
            if (contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}