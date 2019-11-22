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
    public class TheLoaiXesController : Controller
    {
        private readonly WebContext _context;

        public TheLoaiXesController(WebContext context)
        {
            _context = context;
        }

        // GET: TheLoaiXes
        public async Task<IActionResult> Index()
        {
            var webContext = _context.TheLoaiXes.Include(t => t.LoaiXe);
            return View(await webContext.ToListAsync());
        }

        // GET: TheLoaiXes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theLoaiXe = await _context.TheLoaiXes
                .Include(t => t.LoaiXe)
                .FirstOrDefaultAsync(m => m.TheLoaiXeId == id);
            if (theLoaiXe == null)
            {
                return NotFound();
            }

            return View(theLoaiXe);
        }

        // GET: TheLoaiXes/Create
        public IActionResult Create()
        {
            ViewData["LoaiXeId"] = new SelectList(_context.LoaiXes, "LoaiXeId", "LoaiXeId");
            return View();
        }

        // POST: TheLoaiXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TheLoaiXeId,TenTheLoaiXe,LoaiXeId")] TheLoaiXe theLoaiXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theLoaiXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiXeId"] = new SelectList(_context.LoaiXes, "LoaiXeId", "LoaiXeId", theLoaiXe.LoaiXeId);
            return View(theLoaiXe);
        }

        // GET: TheLoaiXes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theLoaiXe = await _context.TheLoaiXes.FindAsync(id);
            if (theLoaiXe == null)
            {
                return NotFound();
            }
            ViewData["LoaiXeId"] = new SelectList(_context.LoaiXes, "LoaiXeId", "LoaiXeId", theLoaiXe.LoaiXeId);
            return View(theLoaiXe);
        }

        // POST: TheLoaiXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TheLoaiXeId,TenTheLoaiXe,LoaiXeId")] TheLoaiXe theLoaiXe)
        {
            if (id != theLoaiXe.TheLoaiXeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theLoaiXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheLoaiXeExists(theLoaiXe.TheLoaiXeId))
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
            ViewData["LoaiXeId"] = new SelectList(_context.LoaiXes, "LoaiXeId", "LoaiXeId", theLoaiXe.LoaiXeId);
            return View(theLoaiXe);
        }

        // GET: TheLoaiXes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theLoaiXe = await _context.TheLoaiXes
                .Include(t => t.LoaiXe)
                .FirstOrDefaultAsync(m => m.TheLoaiXeId == id);
            if (theLoaiXe == null)
            {
                return NotFound();
            }

            return View(theLoaiXe);
        }

        // POST: TheLoaiXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theLoaiXe = await _context.TheLoaiXes.FindAsync(id);
            _context.TheLoaiXes.Remove(theLoaiXe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheLoaiXeExists(int id)
        {
            return _context.TheLoaiXes.Any(e => e.TheLoaiXeId == id);
        }
    }
}
