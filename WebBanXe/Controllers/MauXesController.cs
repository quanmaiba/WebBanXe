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
    public class MauXesController : Controller
    {
        private readonly WebContext _context;

        public MauXesController(WebContext context)
        {
            _context = context;
        }

        // GET: MauXes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MauXes.ToListAsync());
        }

        // GET: MauXes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mauXe = await _context.MauXes
                .FirstOrDefaultAsync(m => m.MauXeId == id);
            if (mauXe == null)
            {
                return NotFound();
            }

            return View(mauXe);
        }

        // GET: MauXes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MauXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MauXeId,TenMauXe")] MauXe mauXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mauXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mauXe);
        }

        // GET: MauXes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mauXe = await _context.MauXes.FindAsync(id);
            if (mauXe == null)
            {
                return NotFound();
            }
            return View(mauXe);
        }

        // POST: MauXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MauXeId,TenMauXe")] MauXe mauXe)
        {
            if (id != mauXe.MauXeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mauXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MauXeExists(mauXe.MauXeId))
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
            return View(mauXe);
        }

        // GET: MauXes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mauXe = await _context.MauXes
                .FirstOrDefaultAsync(m => m.MauXeId == id);
            if (mauXe == null)
            {
                return NotFound();
            }

            return View(mauXe);
        }

        // POST: MauXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mauXe = await _context.MauXes.FindAsync(id);
            _context.MauXes.Remove(mauXe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MauXeExists(int id)
        {
            return _context.MauXes.Any(e => e.MauXeId == id);
        }
    }
}
