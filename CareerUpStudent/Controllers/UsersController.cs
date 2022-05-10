using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerUpStudent.Models;

namespace CareerUpStudent.Controllers
{
    public class UsersController : Controller
    {
        private readonly CareerUpStudentContext _context;

        public UsersController(CareerUpStudentContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var careerUpStudentContext = _context.Users.Include(u => u.IdHrNavigation).Include(u => u.IdRoleNavigation).Include(u => u.IdStudentNavigation);
            return View(await careerUpStudentContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.IdHrNavigation)
                .Include(u => u.IdRoleNavigation)
                .Include(u => u.IdStudentNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.IdHrNavigation)
                .Include(u => u.IdRoleNavigation)
                .Include(u => u.IdStudentNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["IdHr"] = new SelectList(_context.Hrs, "Id", "Id");
            ViewData["IdRole"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "EduForm");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Patronymic,UserName,IdRole,IdStudent,IdHr")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHr"] = new SelectList(_context.Hrs, "Id", "Id", user.IdHr);
            ViewData["IdRole"] = new SelectList(_context.Roles, "Id", "Name", user.IdRole);
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "EduForm", user.IdStudent);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["IdHr"] = new SelectList(_context.Hrs, "Id", "Id", user.IdHr);
            ViewData["IdRole"] = new SelectList(_context.Roles, "Id", "Name", user.IdRole);
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "EduForm", user.IdStudent);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Patronymic,UserName,IdRole,IdStudent,IdHr")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["IdHr"] = new SelectList(_context.Hrs, "Id", "Id", user.IdHr);
            ViewData["IdRole"] = new SelectList(_context.Roles, "Id", "Name", user.IdRole);
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "EduForm", user.IdStudent);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.IdHrNavigation)
                .Include(u => u.IdRoleNavigation)
                .Include(u => u.IdStudentNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
