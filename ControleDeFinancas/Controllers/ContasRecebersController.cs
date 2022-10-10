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
    public class ContasRecebersController : Controller
    {
        private readonly AppDbContext _context;

        public ContasRecebersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContasRecebers
        public async Task<IActionResult> Index()
        {
              return View(await _context.contasReceber.ToListAsync());
        }

        // GET: ContasRecebers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.contasReceber == null)
            {
                return NotFound();
            }

            var contasReceber = await _context.contasReceber
                .FirstOrDefaultAsync(m => m.ContaReceberId == id);
            if (contasReceber == null)
            {
                return NotFound();
            }

            return View(contasReceber);
        }

        // GET: ContasRecebers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContasRecebers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContaReceberId,ContaReceberIdentificacao,Valor,PrevisaoRecebimento,Status,Observacao")] ContasReceber contasReceber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contasReceber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contasReceber);
        }

        // GET: ContasRecebers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.contasReceber == null)
            {
                return NotFound();
            }

            var contasReceber = await _context.contasReceber.FindAsync(id);
            if (contasReceber == null)
            {
                return NotFound();
            }
            return View(contasReceber);
        }

        // POST: ContasRecebers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContaReceberId,ContaReceberIdentificacao,Valor,PrevisaoRecebimento,Status,Observacao")] ContasReceber contasReceber)
        {
            if (id != contasReceber.ContaReceberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contasReceber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContasReceberExists(contasReceber.ContaReceberId))
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
            return View(contasReceber);
        }

        // GET: ContasRecebers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.contasReceber == null)
            {
                return NotFound();
            }

            var contasReceber = await _context.contasReceber
                .FirstOrDefaultAsync(m => m.ContaReceberId == id);
            if (contasReceber == null)
            {
                return NotFound();
            }

            return View(contasReceber);
        }

        // POST: ContasRecebers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.contasReceber == null)
            {
                return Problem("Entity set 'AppDbContext.contasReceber'  is null.");
            }
            var contasReceber = await _context.contasReceber.FindAsync(id);
            if (contasReceber != null)
            {
                _context.contasReceber.Remove(contasReceber);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContasReceberExists(int id)
        {
          return _context.contasReceber.Any(e => e.ContaReceberId == id);
        }
    }
}
