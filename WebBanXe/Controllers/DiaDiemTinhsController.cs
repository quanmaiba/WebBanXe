using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebBanXe.Context;
using WebBanXe.Models;

namespace WebBanXe.Controllers
{
    public class DiaDiemTinhsController : Controller
    {
        private readonly WebContext _context;

        public DiaDiemTinhsController(WebContext context)
        {
            _context = context;
        }

        // GET: DiaDiemTinhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiaDiemTinhs.ToListAsync());
        }

        // GET: DiaDiemTinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiemTinh = await _context.DiaDiemTinhs
                .FirstOrDefaultAsync(m => m.DiaDiemTinhId == id);
            if (diaDiemTinh == null)
            {
                return NotFound();
            }

            return View(diaDiemTinh);
        }

        // GET: DiaDiemTinhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiaDiemTinhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiaDiemTinhId,TenDiaDiemTinh")] DiaDiemTinh diaDiemTinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaDiemTinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaDiemTinh);
        }

        // GET: DiaDiemTinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiemTinh = await _context.DiaDiemTinhs.FindAsync(id);
            if (diaDiemTinh == null)
            {
                return NotFound();
            }
            return View(diaDiemTinh);
        }

        // POST: DiaDiemTinhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiaDiemTinhId,TenDiaDiemTinh")] DiaDiemTinh diaDiemTinh)
        {
            if (id != diaDiemTinh.DiaDiemTinhId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaDiemTinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaDiemTinhExists(diaDiemTinh.DiaDiemTinhId))
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
            return View(diaDiemTinh);
        }

        // GET: DiaDiemTinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiemTinh = await _context.DiaDiemTinhs
                .FirstOrDefaultAsync(m => m.DiaDiemTinhId == id);
            if (diaDiemTinh == null)
            {
                return NotFound();
            }

            return View(diaDiemTinh);
        }

        // POST: DiaDiemTinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaDiemTinh = await _context.DiaDiemTinhs.FindAsync(id);
            _context.DiaDiemTinhs.Remove(diaDiemTinh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaDiemTinhExists(int id)
        {
            return _context.DiaDiemTinhs.Any(e => e.DiaDiemTinhId == id);
        }
    }
}
