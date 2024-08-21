using BookManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {
            var books = await _context.Books.Include(b => b.Publisher)
                                                     .Include(b => b.BookAuthors)
                                                     .ThenInclude(ba => ba.Author)
                                                     .ToListAsync();
            return View(books);
        }

        //Details : View details of a specfic book
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var book = await _context.Books.Include(b => b.Publisher)
                                           .Include(b => b.BookAuthors)
                                           .ThenInclude(ba => ba.Author)
                                           .FirstOrDefaultAsync(m => m.Id == id);
            if(book == null) 
            { 
                return NotFound();
            }
            return View(book);
        }
        //Show the form to create a new book
        public IActionResult Create() 
        {
            ViewBag.PublisherId = new SelectList(_context.Publishers, "Id", "Name");
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            return View();
        }
    }
}
