using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exemplo_MVC.Context;
using Exemplo_MVC.Models;

namespace Exemplo_MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context) {
            _context = context;
        }



        public IActionResult Index() {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }



        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contato contato) {
            if(ModelState.IsValid) {
                _context.Contatos.Add(contato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }


        public IActionResult Edit(int id) {
            var contato = _context.Contatos.Find(id);

            if(contato == null) {
                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }


        [HttpPost]
        public IActionResult Edit(Contato contato) {
            var contatoRetornado = _context.Contatos.Find(contato.Id);

            if(contatoRetornado == null) {
                return RedirectToAction(nameof(Index));
            }

            contatoRetornado.Nome = contato.Nome;
            contatoRetornado.Telefone = contato.Telefone;
            contatoRetornado.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoRetornado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Detail(int id) {
            var contato = _context.Contatos.Find(id);

            if(contato == null) {
                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }


        public IActionResult Delete(int id) {
            var contato = _context.Contatos.Find(id);

            if(contato == null) {
                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }


        [HttpPost]
        public IActionResult Delete(Contato contato) {
            var contatoRetornado = _context.Contatos.Find(contato.Id);

            if(contatoRetornado == null) {
                return RedirectToAction(nameof(Index));
            }

            _context.Contatos.Remove(contatoRetornado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}