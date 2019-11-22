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
    public class KmDaDisController : Controller
    {
        private readonly WebContext _context;

        public KmDaDisController(WebContext context)
        {
            _context = context;
        }

        // GET: KmDaDis
        public async Task<IActionResult> Index()
        {
            return View(await _context.KmDaDis.ToListAsync());
        }

        // GET: KmDaDis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kmDaDi = await _context.KmDaDis
                .FirstOrDefaultAsync(m => m.KmDaDiId == id);
            if (kmDaDi == null)
            {
                return NotFound();
            }

            return View(kmDaDi);
        }

        // GET: KmDaDis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KmDaDis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KmDaDiId,TenKmDaDi")] KmDaDi kmDaDi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kmDaDi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kmDaDi);
        }

        // GET: KmDaDis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kmDaDi = await _context.KmDaDis.FindAsync(id);
            if (kmDaDi == null)
            {
                return NotFound();
            }
            return View(kmDaDi);
        }

        // POST: KmDaDis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KmDaDiId,TenKmDaDi")] KmDaDi kmDaDi)
        {
            if (id != kmDaDi.KmDaDiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kmDaDi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KmDaDiExists(kmDaDi.KmDaDiId))
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
            return View(kmDaDi);
        }

        // GET: KmDaDis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kmDaDi = await _context.KmDaDis
                .FirstOrDefaultAsync(m => m.KmDaDiId == id);
            if (kmDaDi == null)
            {
                return NotFound();
            }

            return View(kmDaDi);
        }

        // POST: KmDaDis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kmDaDi = await _context.KmDaDis.FindAsync(id);
            _context.KmDaDis.Remove(kmDaDi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KmDaDiExists(int id)
        {
            return _context.KmDaDis.Any(e => e.KmDaDiId == id);
        }
    }
}
