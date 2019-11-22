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
    public class LoaiXesController : Controller
    {
        private readonly WebContext _context;

        public LoaiXesController(WebContext context)
        {
            _context = context;
        }

        // GET: LoaiXes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiXes.ToListAsync());
        }

        // GET: LoaiXes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiXe = await _context.LoaiXes
                .FirstOrDefaultAsync(m => m.LoaiXeId == id);
            if (loaiXe == null)
            {
                return NotFound();
            }

            return View(loaiXe);
        }

        // GET: LoaiXes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaiXeId,TenLoaiXe")] LoaiXe loaiXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiXe);
        }

        // GET: LoaiXes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiXe = await _context.LoaiXes.FindAsync(id);
            if (loaiXe == null)
            {
                return NotFound();
            }
            return View(loaiXe);
        }

        // POST: LoaiXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoaiXeId,TenLoaiXe")] LoaiXe loaiXe)
        {
            if (id != loaiXe.LoaiXeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiXeExists(loaiXe.LoaiXeId))
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
            return View(loaiXe);
        }

        // GET: LoaiXes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiXe = await _context.LoaiXes
                .FirstOrDefaultAsync(m => m.LoaiXeId == id);
            if (loaiXe == null)
            {
                return NotFound();
            }

            return View(loaiXe);
        }

        // POST: LoaiXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiXe = await _context.LoaiXes.FindAsync(id);
            _context.LoaiXes.Remove(loaiXe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiXeExists(int id)
        {
            return _context.LoaiXes.Any(e => e.LoaiXeId == id);
        }
    }
}
