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
    public class DoiXeDongXesController : Controller
    {
        private readonly WebContext _context;

        public DoiXeDongXesController(WebContext context)
        {
            _context = context;
        }

        // GET: DoiXeDongXes
        public async Task<IActionResult> Index()
        {
            var webContext = _context.DoiXeDongXes.Include(d => d.DoiXe).Include(d => d.DongXe);
            return View(await webContext.ToListAsync());
        }

        // GET: DoiXeDongXes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiXeDongXe = await _context.DoiXeDongXes
                .Include(d => d.DoiXe)
                .Include(d => d.DongXe)
                .FirstOrDefaultAsync(m => m.DoiXeDongXeId == id);
            if (doiXeDongXe == null)
            {
                return NotFound();
            }

            return View(doiXeDongXe);
        }

        // GET: DoiXeDongXes/Create
        public IActionResult Create()
        {
            ViewData["DoiXeId"] = new SelectList(_context.DoiXes, "DoiXeId", "DoiXeId");
            ViewData["DongXeId"] = new SelectList(_context.DongXes, "DongXeId", "DongXeId");
            return View();
        }

        // POST: DoiXeDongXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoiXeDongXeId,DongXeId,DoiXeId")] DoiXeDongXe doiXeDongXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doiXeDongXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoiXeId"] = new SelectList(_context.DoiXes, "DoiXeId", "DoiXeId", doiXeDongXe.DoiXeId);
            ViewData["DongXeId"] = new SelectList(_context.DongXes, "DongXeId", "DongXeId", doiXeDongXe.DongXeId);
            return View(doiXeDongXe);
        }

        // GET: DoiXeDongXes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiXeDongXe = await _context.DoiXeDongXes.FindAsync(id);
            if (doiXeDongXe == null)
            {
                return NotFound();
            }
            ViewData["DoiXeId"] = new SelectList(_context.DoiXes, "DoiXeId", "DoiXeId", doiXeDongXe.DoiXeId);
            ViewData["DongXeId"] = new SelectList(_context.DongXes, "DongXeId", "DongXeId", doiXeDongXe.DongXeId);
            return View(doiXeDongXe);
        }

        // POST: DoiXeDongXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoiXeDongXeId,DongXeId,DoiXeId")] DoiXeDongXe doiXeDongXe)
        {
            if (id != doiXeDongXe.DoiXeDongXeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doiXeDongXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoiXeDongXeExists(doiXeDongXe.DoiXeDongXeId))
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
            ViewData["DoiXeId"] = new SelectList(_context.DoiXes, "DoiXeId", "DoiXeId", doiXeDongXe.DoiXeId);
            ViewData["DongXeId"] = new SelectList(_context.DongXes, "DongXeId", "DongXeId", doiXeDongXe.DongXeId);
            return View(doiXeDongXe);
        }

        // GET: DoiXeDongXes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiXeDongXe = await _context.DoiXeDongXes
                .Include(d => d.DoiXe)
                .Include(d => d.DongXe)
                .FirstOrDefaultAsync(m => m.DoiXeDongXeId == id);
            if (doiXeDongXe == null)
            {
                return NotFound();
            }

            return View(doiXeDongXe);
        }

        // POST: DoiXeDongXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doiXeDongXe = await _context.DoiXeDongXes.FindAsync(id);
            _context.DoiXeDongXes.Remove(doiXeDongXe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoiXeDongXeExists(int id)
        {
            return _context.DoiXeDongXes.Any(e => e.DoiXeDongXeId == id);
        }
    }
}
