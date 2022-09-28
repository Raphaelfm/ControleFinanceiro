using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeFinancas.Context;
using ControleDeFinancas.Models;

namespace ControleDeFinancas.Controllers
{
    public class ContasPagarController : Controller
    {
        private readonly AppDbContext _context;

        public ContasPagarController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContasPagar
        public async Task<IActionResult> Index()
        {
              return View(await _context.contasPagar.ToListAsync());
        }

        // GET: ContasPagar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.contasPagar == null)
            {
                return NotFound();
            }

            var contasPagar = await _context.contasPagar
                .FirstOrDefaultAsync(m => m.ContaPagarId == id);
            if (contasPagar == null)
            {
                return NotFound();
            }

            return View(contasPagar);
        }

        // GET: ContasPagar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContasPagar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContaPagarId,ContaPagarIdentificacao,PrevisaoPagamento,Status,Observacao")] ContasPagar contasPagar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contasPagar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contasPagar);
        }

        // GET: ContasPagar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.contasPagar == null)
            {
                return NotFound();
            }

            var contasPagar = await _context.contasPagar.FindAsync(id);
            if (contasPagar == null)
            {
                return NotFound();
            }
            return View(contasPagar);
        }

        // POST: ContasPagar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContaPagarId,ContaPagarIdentificacao,PrevisaoPagamento,Status,Observacao")] ContasPagar contasPagar)
        {
            if (id != contasPagar.ContaPagarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contasPagar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContasPagarExists(contasPagar.ContaPagarId))
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
            return View(contasPagar);
        }

        // GET: ContasPagar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.contasPagar == null)
            {
                return NotFound();
            }

            var contasPagar = await _context.contasPagar
                .FirstOrDefaultAsync(m => m.ContaPagarId == id);
            if (contasPagar == null)
            {
                return NotFound();
            }

            return View(contasPagar);
        }

        // POST: ContasPagar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.contasPagar == null)
            {
                return Problem("Entity set 'AppDbContext.contasPagar'  is null.");
            }
            var contasPagar = await _context.contasPagar.FindAsync(id);
            if (contasPagar != null)
            {
                _context.contasPagar.Remove(contasPagar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContasPagarExists(int id)
        {
          return _context.contasPagar.Any(e => e.ContaPagarId == id);
        }
    }
}
