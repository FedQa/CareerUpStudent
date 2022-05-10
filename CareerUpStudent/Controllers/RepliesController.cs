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
    public class RepliesController : Controller
    {
        private readonly CareerUpStudentContext _context;

        public RepliesController(CareerUpStudentContext context)
        {
            _context = context;
        }

        // GET: Replies
        public async Task<IActionResult> Index()
        {
            List<Reply> replies = _context.Replies.ToList();
            ReplyResume replies1 = new ReplyResume();
            foreach(var rep in replies)
            {
                if (rep.IdResume == _context.Resumes.Where(e => e.IdStudent.Equals(1)).First().Id)
                {
                    replies1.ResumeId = rep.IdResume;
                    replies1.Resume = _context.Resumes.Where(e => e.Id.Equals(rep.IdResume)).First();
                    replies1.VacancyId = rep.IdVacancy;
                    replies1.Vacancy = _context.Vacancies.Where(e => e.Id.Equals(rep.IdVacancy)).First();
                    break;
                }
            }
            return View(replies1);
        }
        //public IActionResult Reply()
        //{
        //    return View();
        //}

        // GET: Replies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Replies
                .Include(r => r.IdResumeNavigation)
                .Include(r => r.IdVacancyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // GET: Replies/Create
        public IActionResult Create(int id)
        {
            Reply reply = new Reply();
            reply.IdVacancy = id;
            reply.IdResume = _context.Resumes.Where(e => e.IdStudent.Equals(1)).First().Id;
            reply.AnswerDate = DateTime.Now;
            reply.Answer = 1;
            foreach (var response in _context.Replies)
            {
                if (reply.Id == response.Id)
                    return RedirectToAction(nameof(Index));

            }
            _context.Add(reply);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: Replies/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, Reply reply1)
        {
            Reply reply = new Reply();
            reply.IdVacancy = id;
            reply.IdResume = _context.Resumes.Where(e => e.IdStudent.Equals(1)).First().Id;
            reply.AnswerDate = DateTime.Now;
            reply.Answer = 1;
            foreach(var response in _context.Replies)
            {
                if(reply.Id == response.Id)
                    return RedirectToAction(nameof(Index));
                
            }
            _context.Add(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Replies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Replies.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            ViewData["IdResume"] = new SelectList(_context.Resumes, "Id", "Name", reply.IdResume);
            ViewData["IdVacancy"] = new SelectList(_context.Vacancies, "Id", "City", reply.IdVacancy);
            return View(reply);
        }

        // POST: Replies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Answer,AnswerDate,IdResume,IdVacancy")] Reply reply)
        {
            if (id != reply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReplyExists(reply.Id))
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
            ViewData["IdResume"] = new SelectList(_context.Resumes, "Id", "Name", reply.IdResume);
            ViewData["IdVacancy"] = new SelectList(_context.Vacancies, "Id", "City", reply.IdVacancy);
            return View(reply);
        }

        // GET: Replies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Replies
                .Include(r => r.IdResumeNavigation)
                .Include(r => r.IdVacancyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reply = await _context.Replies.FindAsync(id);
            _context.Replies.Remove(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReplyExists(int id)
        {
            return _context.Replies.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Replies.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            ViewData["IdResume"] = new SelectList(_context.Resumes, "Id", "Name", reply.IdResume);
            ViewData["IdVacancy"] = new SelectList(_context.Vacancies, "Id", "City", reply.IdVacancy);
            return View(reply);
        }

        // POST: Replies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reply(int id, [Bind("Id,Answer,AnswerDate,IdResume,IdVacancy")] Reply reply)
        {
            if (id != reply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReplyExists(reply.Id))
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
            ViewData["IdResume"] = new SelectList(_context.Resumes, "Id", "Name", reply.IdResume);
            ViewData["IdVacancy"] = new SelectList(_context.Vacancies, "Id", "City", reply.IdVacancy);
            return View(reply);
        }
    }
}
