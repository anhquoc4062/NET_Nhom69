using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom69MidTermDotNet.Models;

namespace Nhom69MidTermDotNet.Controllers
{
    public class BangChamCongsController : Controller
    {
        private readonly QLNhansuContext _context;

        public BangChamCongsController(QLNhansuContext context)
        {
            _context = context;
        }

        // GET: BangChamCongs
        public IActionResult Index()
        {
            var qLNhansuContext = _context.BangChamCong.Include(b => b.MaNvNavigation);
            return View(qLNhansuContext.ToList());
        }

        // GET: BangChamCongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bangChamCong = await _context.BangChamCong
                .Include(b => b.MaNvNavigation)
                .FirstOrDefaultAsync(m => m.MaCc == id);
            if (bangChamCong == null)
            {
                return NotFound();
            }

            return View(bangChamCong);
        }

        // GET: BangChamCongs/Create
        public IActionResult Create()
        {
            ViewData["MaNv"] = new SelectList(_context.NhanVien, "MaNv", "Hoten");
            return View();
        }

        // POST: BangChamCongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCc,Nam,Thang,MaNv,Songay")] BangChamCong bangChamCong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bangChamCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNv"] = new SelectList(_context.NhanVien, "MaNv", "Hoten", bangChamCong.MaNv);
            return View(bangChamCong);
        }

        // GET: BangChamCongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bangChamCong = await _context.BangChamCong.FindAsync(id);
            if (bangChamCong == null)
            {
                return NotFound();
            }
            ViewData["MaNv"] = new SelectList(_context.NhanVien, "MaNv", "Hoten", bangChamCong.MaNv);
            return View(bangChamCong);
        }

        // POST: BangChamCongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCc,Nam,Thang,MaNv,Songay")] BangChamCong bangChamCong)
        {
            if (id != bangChamCong.MaCc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bangChamCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BangChamCongExists(bangChamCong.MaCc))
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
            ViewData["MaNv"] = new SelectList(_context.NhanVien, "MaNv", "Hoten", bangChamCong.MaNv);
            return View(bangChamCong);
        }

        // GET: BangChamCongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bangChamCong = await _context.BangChamCong
                .Include(b => b.MaNvNavigation)
                .FirstOrDefaultAsync(m => m.MaCc == id);
            if (bangChamCong == null)
            {
                return NotFound();
            }

            return View(bangChamCong);
        }

        // POST: BangChamCongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bangChamCong = await _context.BangChamCong.FindAsync(id);
            _context.BangChamCong.Remove(bangChamCong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BangChamCongExists(int id)
        {
            return _context.BangChamCong.Any(e => e.MaCc == id);
        }
    }
}
