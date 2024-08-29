using BookManager.Data;
using BookManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookManager.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string? author;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _context.Authors.ToListAsync();
            return View();
        }
        //View details of a specific author
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) 
            {
                return NotFound();
            }
            var author = await _context.Authors
                                .Include(a => a.BookAuthors)
                                .ThenInclude(ba => ba.Book)
                                .FirstOrDefaultAsync(m => m.Id == id);
            if(author == null) 
            {
                return NotFound();
            }
            return View(author);
        }
        //show the form to create a new author
        public IActionResult Create()
        {
            return View();
        }
        //Save the author the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
               await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        //show form to edit an existing author
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);
            if(author == null) 
            {
                return NotFound();
            }
            return View(author);
        }
        //save the edited author to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int  id, Author author)
        {
            if(id != author.Id) 
            {
                return NotFound();
            }
            if (ModelState.IsValid) 
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!AuthorExists(author.Id))
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
            return View(author);
        }
        //show conformation page to delete an author
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if(author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id) 
        {
            return _context.Authors.Any(a => a.Id == id);
        }
        // Check the github for changes add edit and delete view
    }
}
