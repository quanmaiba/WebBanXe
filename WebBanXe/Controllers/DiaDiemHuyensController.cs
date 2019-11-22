using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebBanXe.Context;
using WebBanXe.Models;

namespace WebBanXe.Controllers
{
    public class DiaDiemHuyensController : Controller
    {
        private readonly WebContext _context;

        public DiaDiemHuyensController(WebContext context)
        {
            _context = context;
        }

        // GET: DiaDiemHuyens
        public async Task<IActionResult> Index()
        {
            var webContext = _context.DiaDiemHuyens.Include(d => d.DiaDiemTinh);
            return View(await webContext.ToListAsync());
        }

        // GET: DiaDiemHuyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiemHuyen = await _context.DiaDiemHuyens
                .Include(d => d.DiaDiemTinh)
                .FirstOrDefaultAsync(m => m.DiaDiemHuyenId == id);
            if (diaDiemHuyen == null)
            {
                return NotFound();
            }

            return View(diaDiemHuyen);
        }

        // GET: DiaDiemHuyens/Create
        public IActionResult Create()
        {
            ViewData["DiaDiemTinhId"] = new SelectList(_context.DiaDiemTinhs, "DiaDiemTinhId", "DiaDiemTinhId");
            return View();
        }

        // POST: DiaDiemHuyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiaDiemHuyenId,TenDiaDiemHuyen,DiaDiemTinhId")] DiaDiemHuyen diaDiemHuyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaDiemHuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiaDiemTinhId"] = new SelectList(_context.DiaDiemTinhs, "DiaDiemTinhId", "DiaDiemTinhId", diaDiemHuyen.DiaDiemTinhId);
            return View(diaDiemHuyen);
        }

        // GET: DiaDiemHuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiemHuyen = await _context.DiaDiemHuyens.FindAsync(id);
            if (diaDiemHuyen == null)
            {
                return NotFound();
            }
            ViewData["DiaDiemTinhId"] = new SelectList(_context.DiaDiemTinhs, "DiaDiemTinhId", "DiaDiemTinhId", diaDiemHuyen.DiaDiemTinhId);
            return View(diaDiemHuyen);
        }

        // POST: DiaDiemHuyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiaDiemHuyenId,TenDiaDiemHuyen,DiaDiemTinhId")] DiaDiemHuyen diaDiemHuyen)
        {
            if (id != diaDiemHuyen.DiaDiemHuyenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaDiemHuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaDiemHuyenExists(diaDiemHuyen.DiaDiemHuyenId))
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
            ViewData["DiaDiemTinhId"] = new SelectList(_context.DiaDiemTinhs, "DiaDiemTinhId", "DiaDiemTinhId", diaDiemHuyen.DiaDiemTinhId);
            return View(diaDiemHuyen);
        }

        // GET: DiaDiemHuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiemHuyen = await _context.DiaDiemHuyens
                .Include(d => d.DiaDiemTinh)
                .FirstOrDefaultAsync(m => m.DiaDiemHuyenId == id);
            if (diaDiemHuyen == null)
            {
                return NotFound();
            }

            return View(diaDiemHuyen);
        }

        // POST: DiaDiemHuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaDiemHuyen = await _context.DiaDiemHuyens.FindAsync(id);
            _context.DiaDiemHuyens.Remove(diaDiemHuyen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaDiemHuyenExists(int id)
        {
            return _context.DiaDiemHuyens.Any(e => e.DiaDiemHuyenId == id);
        }
    }
}
