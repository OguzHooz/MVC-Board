using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBoard.Data;
using MvcBoard.Models;

namespace MvcBoard.Controllers
{
    public class BoardsController : Controller
    {
        private readonly MvcBoardContext _context;

        public BoardsController(MvcBoardContext context)
        {
            _context = context;
        }

        // GET: Boards
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentfilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            if(searchString != null)
            {
                pageNumber = 1;
            } else { searchString = currentfilter; }


            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewData["LengthSortParm"] = sortOrder == "length" ? "length_desc" : "length";
            ViewData["WidthSortParm"] = sortOrder == "width" ? "width_desc" : "width";
            ViewData["ThicknessSortParm"] = sortOrder == "thickness" ? "thickness_desc" : "thickness";
            ViewData["VolumeSortParm"] = sortOrder == "volume" ? "volume_desc" : "volume";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";

            var boards = from b in _context.Board
                           select b;
            switch (sortOrder)
            {
                case "name":
                    boards = boards.OrderBy(b => b.Name);
                    break;
                case "length":
                    boards = boards.OrderBy(b => b.Length);
                    break;
                case "length_desc":
                    boards = boards.OrderByDescending(b => b.Length);
                    break;
                case "width":
                    boards = boards.OrderBy(b => b.Width);
                    break;
                case "width_desc":
                    boards = boards.OrderByDescending(b => b.Width);
                    break;
                case "thickness":
                    boards = boards.OrderBy(b => b.Thickness);
                    break;
                case "thickness_desc":
                    boards = boards.OrderByDescending(b => b.Thickness);
                    break;
                case "volume":
                    boards = boards.OrderBy(b => b.Volume);
                    break;
                case "volume_desc":
                    boards = boards.OrderByDescending(b => b.Volume);
                    break;
                case "price":
                    boards = boards.OrderBy(b => b.Price);
                    break;
                case "price_desc":
                    boards = boards.OrderByDescending(b => b.Price);
                    break;
                default:
                    boards = boards.OrderBy(b => b.Name);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                boards = boards.Where(b => b.Name.Contains(searchString) || b.Equipment.Contains(searchString));
            }

            int pageSize = 5;
            return View(await PaginatedList<Board>.CreateAsync(boards.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Boards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Board == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // GET: Boards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Length,Width,Thickness,Volume,Type,Price,Equipment")] Board board)
        {
            if (ModelState.IsValid)
            {
                _context.Add(board);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Boards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Board == null)
            {
                return NotFound();
            }

            var board = await _context.Board.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Length,Width,Thickness,Volume,Type,Price,Equipment")] Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(board);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.Id))
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
            return View(board);
        }

        // GET: Boards/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Board == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Board == null)
            {
                return Problem("Entity set 'MvcBoardContext.Board'  is null.");
            }
            var board = await _context.Board.FindAsync(id);
            if (board != null)
            {
                _context.Board.Remove(board);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(int id)
        {
          return (_context.Board?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
