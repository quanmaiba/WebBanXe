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
    public class XuatXusController : Controller
    {
        private readonly WebContext _context;

        public XuatXusController(WebContext context)
        {
            _context = context;
        }

        // GET: XuatXus
        public async Task<IActionResult> Index()
        {
            return View(await _context.XuatXus.ToListAsync());
        }

        // GET: XuatXus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatXu = await _context.XuatXus
                .FirstOrDefaultAsync(m => m.XuatXuId == id);
            if (xuatXu == null)
            {
                return NotFound();
            }

            return View(xuatXu);
        }

        // GET: XuatXus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: XuatXus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("XuatXuId,TenXuatXu")] XuatXu xuatXu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xuatXu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(xuatXu);
        }

        // GET: XuatXus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatXu = await _context.XuatXus.FindAsync(id);
            if (xuatXu == null)
            {
                return NotFound();
            }
            return View(xuatXu);
        }

        // POST: XuatXus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("XuatXuId,TenXuatXu")] XuatXu xuatXu)
        {
            if (id != xuatXu.XuatXuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xuatXu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XuatXuExists(xuatXu.XuatXuId))
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
            return View(xuatXu);
        }

        // GET: XuatXus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatXu = await _context.XuatXus
                .FirstOrDefaultAsync(m => m.XuatXuId == id);
            if (xuatXu == null)
            {
                return NotFound();
            }

            return View(xuatXu);
        }

        // POST: XuatXus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var xuatXu = await _context.XuatXus.FindAsync(id);
            _context.XuatXus.Remove(xuatXu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XuatXuExists(int id)
        {
            return _context.XuatXus.Any(e => e.XuatXuId == id);
        }
    }
}
