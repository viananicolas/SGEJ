using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGEJ.Models.Context;
using SGEJ.Models.Entities;
using SGEJ.Models.Interface;

namespace SGEJ.Controllers
{
    public class JogosController : BaseController
    {

        public JogosController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            return View(UnitOfWork.GetRepositoryAsync<Jogo>().GetAsync(e=>!e.Excluido));
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await UnitOfWork.GetRepositoryAsync<Jogo>().SingleAsync(e => !e.Excluido && e.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeJogo,AnoLancamento,Id,DataCadastro,Excluido")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                jogo.DataCadastro = DateTime.Now;
                UnitOfWork.GetRepositoryAsync<Jogo>().UpdateAsync(jogo);
                UnitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await UnitOfWork.GetRepositoryAsync<Jogo>().SingleAsync(e => !e.Excluido && e.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomeJogo,AnoLancamento,Id,DataCadastro,Excluido")] Jogo jogo)
        {
            if (id != jogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.GetRepositoryAsync<Jogo>().UpdateAsync(jogo);
                    UnitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await UnitOfWork.GetRepositoryAsync<Jogo>().SingleAsync(e => !e.Excluido && e.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogo = await UnitOfWork.GetRepositoryAsync<Jogo>().SingleAsync(e => !e.Excluido && e.Id == id);
            jogo.Excluir();
            UnitOfWork.GetRepositoryAsync<Jogo>().UpdateAsync(jogo);
            UnitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(int id)
        {
            return UnitOfWork.GetRepository<Jogo>().Get(e => !e.Excluido && e.Id == id).Any();
        }
    }
}
