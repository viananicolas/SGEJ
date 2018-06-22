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
    public class AmigosController : BaseController
    {

        public AmigosController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // GET: Amigos
        public async Task<IActionResult> Index()
        {
            return View(UnitOfWork.GetRepositoryAsync<Amigo>().GetAsync(e => !e.Excluido));
        }

        // GET: Amigos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await UnitOfWork.GetRepositoryAsync<Amigo>().SingleAsync(e => !e.Excluido && e.Id == id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // GET: Amigos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amigos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Celular,Id,DataCadastro,Excluido")] Amigo amigo)
        {
            if (ModelState.IsValid)
            {
                amigo.DataCadastro = DateTime.Now;
                UnitOfWork.GetRepositoryAsync<Amigo>().UpdateAsync(amigo);
                UnitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(amigo);
        }

        // GET: Amigos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await UnitOfWork.GetRepositoryAsync<Amigo>().SingleAsync(e => !e.Excluido && e.Id == id);
            if (amigo == null)
            {
                return NotFound();
            }
            return View(amigo);
        }

        // POST: Amigos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Celular,Id,DataCadastro,Excluido")] Amigo amigo)
        {
            if (id != amigo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.GetRepositoryAsync<Amigo>().UpdateAsync(amigo);
                    UnitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(amigo.Id))
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
            return View(amigo);
        }

        // GET: Amigos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await UnitOfWork.GetRepositoryAsync<Amigo>().SingleAsync(e => !e.Excluido && e.Id == id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // POST: Amigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amigo = await UnitOfWork.GetRepositoryAsync<Amigo>().SingleAsync(e => !e.Excluido && e.Id == id);
            amigo.Excluir();
            UnitOfWork.GetRepositoryAsync<Amigo>().UpdateAsync(amigo);
            UnitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(int id)
        {
            return UnitOfWork.GetRepository<Amigo>().Get(e => !e.Excluido && e.Id == id).Any();
        }
    }
}
