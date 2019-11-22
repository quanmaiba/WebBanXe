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
    public class DongXesController : Controller
    {
        private readonly WebContext _context;

        public DongXesController(WebContext context)
        {
            _context = context;
        }

        // GET: DongXes
        public async Task<IActionResult> Index()
        {
            var webContext = _context.DongXes.Include(d => d.HangXe).Include(d => d.PhanKhoi).Include(d => d.TheLoaiXe);
            return View(await webContext.ToListAsync());
        }

        // GET: DongXes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dongXe = await _context.DongXes
                .Include(d => d.HangXe)
                .Include(d => d.PhanKhoi)
                .Include(d => d.TheLoaiXe)
                .FirstOrDefaultAsync(m => m.DongXeId == id);
            if (dongXe == null)
            {
                return NotFound();
            }

            return View(dongXe);
        }

        // GET: DongXes/Create
        public IActionResult Create()
        {
            ViewData["HangXeId"] = new SelectList(_context.HangXes, "HangXeId", "TenHangXe");
            ViewData["PhanKhoiId"] = new SelectList(_context.PhanKhois, "PhanKhoiId", "TenPhanKhoi");
            ViewData["TheLoaiXeId"] = new SelectList(_context.TheLoaiXes, "TheLoaiXeId", "TenTheLoaiXe");
            return View();
        }

        // POST: DongXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DongXeId,TenDongXe,HangXeId,PhanKhoiId,TheLoaiXeId")] DongXe dongXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dongXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HangXeId"] = new SelectList(_context.HangXes, "HangXeId", "TenHangXe", dongXe.HangXeId);
            ViewData["PhanKhoiId"] = new SelectList(_context.PhanKhois, "PhanKhoiId", "TenPhanKhoi", dongXe.PhanKhoiId);
            ViewData["TheLoaiXeId"] = new SelectList(_context.TheLoaiXes, "TheLoaiXeId", "TenTheLoaiXe", dongXe.TheLoaiXeId);
            return View(dongXe);
        }

        // GET: DongXes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dongXe = await _context.DongXes.FindAsync(id);
            if (dongXe == null)
            {
                return NotFound();
            }
            ViewData["HangXeId"] = new SelectList(_context.HangXes, "HangXeId", "TenHangXe", dongXe.HangXeId);
            ViewData["PhanKhoiId"] = new SelectList(_context.PhanKhois, "PhanKhoiId", "TenPhanKhoi", dongXe.PhanKhoiId);
            ViewData["TheLoaiXeId"] = new SelectList(_context.TheLoaiXes, "TheLoaiXeId", "TenTheLoaiXe", dongXe.TheLoaiXeId);
            return View(dongXe);
        }

        // POST: DongXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DongXeId,TenDongXe,HangXeId,PhanKhoiId,TheLoaiXeId")] DongXe dongXe)
        {
            if (id != dongXe.DongXeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dongXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DongXeExists(dongXe.DongXeId))
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
            ViewData["HangXeId"] = new SelectList(_context.HangXes, "HangXeId", "TenHangXe", dongXe.HangXeId);
            ViewData["PhanKhoiId"] = new SelectList(_context.PhanKhois, "PhanKhoiId", "TenPhanKhoi", dongXe.PhanKhoiId);
            ViewData["TheLoaiXeId"] = new SelectList(_context.TheLoaiXes, "TheLoaiXeId", "TenTheLoaiXe", dongXe.TheLoaiXeId);
            return View(dongXe);
        }

        // GET: DongXes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dongXe = await _context.DongXes
                .Include(d => d.HangXe)
                .Include(d => d.PhanKhoi)
                .Include(d => d.TheLoaiXe)
                .FirstOrDefaultAsync(m => m.DongXeId == id);
            if (dongXe == null)
            {
                return NotFound();
            }

            return View(dongXe);
        }

        // POST: DongXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dongXe = await _context.DongXes.FindAsync(id);
            _context.DongXes.Remove(dongXe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DongXeExists(int id)
        {
            return _context.DongXes.Any(e => e.DongXeId == id);
        }
    }
}
