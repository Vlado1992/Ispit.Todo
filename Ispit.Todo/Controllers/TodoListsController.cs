using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Controllers
{
    [Authorize]
    public class TodoListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TodoLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.TodoLists.ToListAsync());
        }

        // GET: TodoLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoList == null)
            {
                return NotFound();
            }

            return View(todoList);
        }

        // GET: TodoLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserId")] TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoList);
        }

        // GET: TodoLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }
            return View(todoList);
        }

        // POST: TodoLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserId")] TodoList todoList)
        {
            if (id != todoList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoListExists(todoList.Id))
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
            return View(todoList);
        }

        // GET: TodoLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoList == null)
            {
                return NotFound();
            }

            return View(todoList);
        }

        // POST: TodoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList != null)
            {
                _context.TodoLists.Remove(todoList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoListExists(int id)
        {
            return _context.TodoLists.Any(e => e.Id == id);
        }
    }
}
