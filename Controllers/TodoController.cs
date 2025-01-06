using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Todo
        public async Task<IActionResult> Index()
        {
            var items = await _context.TodoItems.ToListAsync();
            return View(items);
        }

        // GET: /Todo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                todoItem.CreatedDate = DateTime.Now;
                _context.Add(todoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }
    }
}