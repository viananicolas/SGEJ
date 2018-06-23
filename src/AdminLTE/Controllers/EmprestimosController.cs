using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGEJ.Attributes;
using SGEJ.Models.Context;
using SGEJ.Models.Entities;
using SGEJ.Models.Interface;
using SGEJ.Models.Models.EmprestimosViewModel;

//Bind("DataPrevistaDevolucao,DataDevolucao,Id,DataCadastro,Excluido")]
namespace SGEJ.Controllers
{
    public class EmprestimosController : BaseController
    {

        public EmprestimosController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        private void InicializaViewData(CadastroEmprestimoViewModel emprestimo = null)
        {
            ViewData["Amigo"] = new SelectList(UnitOfWork.GetRepositoryAsync<Amigo>().GetAsync(e => !e.Excluido).OrderBy(e => e.Nome), "Id", "Nome", emprestimo?.Amigo);
            var jogos = UnitOfWork.GetRepositoryAsync<Jogo>()
                .GetAsync(e => !e.Excluido && e.Emprestimos.All(i => i.Emprestimo.DataDevolucao != null),
                    include: i => i.Include(e => e.Emprestimos)).ToList();
            if (emprestimo != null)
            {
                jogos.AddRange(emprestimo.Jogos.Select(emprestimoJogo => UnitOfWork.GetRepositoryAsync<Jogo>().SingleAsync(e => e.Id == emprestimoJogo).Result));
                //jogos.AddRange(emprestimo.Jogos.Select(emprestimoJogo => await UnitOfWork.GetRepositoryAsync<Jogo>().Sin().FirstOrDefault(e => e.Id == emprestimoJogo)));
            }
            ViewData["Jogos"] = new MultiSelectList(jogos.OrderBy(e => e.NomeJogo), "Id", "NomeJogo", emprestimo?.Jogos);
        }
        // GET: Emprestimos
        public async Task<IActionResult> Index()
        {
            return View(UnitOfWork.GetRepositoryAsync<Emprestimo>().GetAsync(e => !e.Excluido, include: e => e.Include(i => i.Amigo)));
        }

        // GET: Emprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await UnitOfWork.GetRepositoryAsync<Emprestimo>().SingleAsync(e => !e.Excluido && e.Id == id, include: e => e.Include(i => i.Emprestimos).ThenInclude(i => i.Jogo).Include(i => i.Amigo));
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public IActionResult Create()
        {
            InicializaViewData();
            return View();
        }

        // POST: Emprestimos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amigo,Jogos,DataPrevistaDevolucao,DataDevolucao")] CadastroEmprestimoViewModel emprestimoViewModel)
        {
            if (ModelState.IsValid)
            {
                var emprestimo = new Emprestimo
                {
                    DataCadastro = DateTime.Now,
                    DataPrevistaDevolucao = emprestimoViewModel.DataPrevistaDevolucao,
                    Amigo = await UnitOfWork.GetRepositoryAsync<Amigo>()
                        .SingleAsync(e => e.Id == emprestimoViewModel.Amigo),
                    Emprestimos = new List<EmprestimoJogo>()
                };
                foreach (var jogo in emprestimoViewModel.Jogos)
                    emprestimo.Emprestimos.Add(new EmprestimoJogo
                    {
                        DataCadastro = DateTime.Now,
                        Emprestimo = emprestimo,
                        Jogo = await UnitOfWork.GetRepositoryAsync<Jogo>().SingleAsync(e => e.Id == jogo)
                    });
                emprestimo.DataCadastro = DateTime.Now;
                UnitOfWork.GetRepositoryAsync<Emprestimo>().UpdateAsync(emprestimo);
                UnitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(emprestimoViewModel);
        }
        // GET: Emprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await UnitOfWork.GetRepositoryAsync<Emprestimo>().SingleAsync(e => !e.Excluido && e.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimo = await UnitOfWork.GetRepositoryAsync<Emprestimo>().SingleAsync(e => !e.Excluido && e.Id == id);
            if (emprestimo.DataDevolucao != null)
            {
                emprestimo.Excluir();
                UnitOfWork.GetRepositoryAsync<Emprestimo>().UpdateAsync(emprestimo);
                UnitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Os jogos ainda não foram devolvidos.");
            return View();
        }
        [HttpPost, ServiceFilter(typeof(ValidateHeaderAntiForgeryTokenAttribute), IsReusable = true)]
        public async Task<IActionResult> EncerrarEmprestimo(int id)
        {
            try
            {
                var emprestimo = await UnitOfWork.GetRepositoryAsync<Emprestimo>().SingleAsync(e => !e.Excluido && e.Id == id, include: e => e.Include(i => i.Emprestimos).ThenInclude(i => i.Jogo).Include(i => i.Amigo));
                if (emprestimo == null)
                {
                    return NotFound();
                }
                emprestimo.DataDevolucao = DateTime.Now;
                UnitOfWork.GetRepositoryAsync<Emprestimo>().UpdateAsync(emprestimo);
                UnitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }
        private bool JogoExists(int id)
        {
            return UnitOfWork.GetRepository<Emprestimo>().Get(e => !e.Excluido && e.Id == id).Any();
        }
    }
}

