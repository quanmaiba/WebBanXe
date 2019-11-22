using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanXe.Context;
using WebBanXe.Models;

namespace WebBanXe.Controllers
{
    public class DoiXesController : Controller
    {
        private readonly WebContext _context;

        public DoiXesController(WebContext context)
        {
            _context = context;
        }

        // GET: DoiXes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoiXes.ToListAsync());
        }

        // GET: DoiXes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiXe = await _context.DoiXes
                .FirstOrDefaultAsync(m => m.DoiXeId == id);
            if (doiXe == null)
            {
                return NotFound();
            }

            return View(doiXe);
        }

        // GET: DoiXes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoiXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoiXeId,TenDoiXe")] DoiXe doiXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doiXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doiXe);
        }

        // GET: DoiXes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiXe = await _context.DoiXes.FindAsync(id);
            if (doiXe == null)
            {
                return NotFound();
            }
            return View(doiXe);
        }

        // POST: DoiXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoiXeId,TenDoiXe")] DoiXe doiXe)
        {
            if (id != doiXe.DoiXeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doiXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoiXeExists(doiXe.DoiXeId))
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
            return View(doiXe);
        }

        // GET: DoiXes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiXe = await _context.DoiXes
                .FirstOrDefaultAsync(m => m.DoiXeId == id);
            if (doiXe == null)
            {
                return NotFound();
            }

            return View(doiXe);
        }

        // POST: DoiXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doiXe = await _context.DoiXes.FindAsync(id);
            _context.DoiXes.Remove(doiXe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoiXeExists(int id)
        {
            return _context.DoiXes.Any(e => e.DoiXeId == id);
        }
    }
}
