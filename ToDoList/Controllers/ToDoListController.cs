using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoListController(ApplicationDbContext context)
        {
            _context = context;
        }


        // Get all tasks
        public IActionResult Index()
        {
            var result = _context.ToDoLists.ToList();
            return View(result);
        }


        // Get task by Id
        public IActionResult TaskDetails(int? id)
        {
            if (id == null || _context.ToDoLists == null)
            {
                return NotFound();
            }
            var result = _context.ToDoLists.Find(id);

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }


        // Get 
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoList);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(todoList);
        }


        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.ToDoLists == null)
            {
                return NotFound();
            }

            var result = _context.ToDoLists.Find(id);

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                _context.Update(todoList);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoList);
        }


        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var result = _context.ToDoLists.Find(id);

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }


        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var result = _context.ToDoLists.Find(id);

            if (result == null)
            {
                return NotFound();
            }
            _context.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
