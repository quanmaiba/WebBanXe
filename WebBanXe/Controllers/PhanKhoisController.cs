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
    public class PhanKhoisController : Controller
    {
        private readonly WebContext _context;

        public PhanKhoisController(WebContext context)
        {
            _context = context;
        }

        // GET: PhanKhois
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhanKhois.ToListAsync());
        }

        // GET: PhanKhois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanKhoi = await _context.PhanKhois
                .FirstOrDefaultAsync(m => m.PhanKhoiId == id);
            if (phanKhoi == null)
            {
                return NotFound();
            }

            return View(phanKhoi);
        }

        // GET: PhanKhois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhanKhois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhanKhoiId,TenPhanKhoi")] PhanKhoi phanKhoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanKhoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phanKhoi);
        }

        // GET: PhanKhois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanKhoi = await _context.PhanKhois.FindAsync(id);
            if (phanKhoi == null)
            {
                return NotFound();
            }
            return View(phanKhoi);
        }

        // POST: PhanKhois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhanKhoiId,TenPhanKhoi")] PhanKhoi phanKhoi)
        {
            if (id != phanKhoi.PhanKhoiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanKhoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanKhoiExists(phanKhoi.PhanKhoiId))
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
            return View(phanKhoi);
        }

        // GET: PhanKhois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanKhoi = await _context.PhanKhois
                .FirstOrDefaultAsync(m => m.PhanKhoiId == id);
            if (phanKhoi == null)
            {
                return NotFound();
            }

            return View(phanKhoi);
        }

        // POST: PhanKhois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanKhoi = await _context.PhanKhois.FindAsync(id);
            _context.PhanKhois.Remove(phanKhoi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanKhoiExists(int id)
        {
            return _context.PhanKhois.Any(e => e.PhanKhoiId == id);
        }
    }
}
