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
    public class VacanciesController : Controller
    {
        private readonly CareerUpStudentContext _context;

        public VacanciesController(CareerUpStudentContext context)
        {
            _context = context;
        }

        // GET: Vacancies
        public async Task<IActionResult> Index(string vacancyCity, string searchString, string EmploymentType, string Experience, string Salary)
        {
            var careerUpStudentContext = _context.Vacancies.Include(v => v.IdCompanyNavigation);

            var SalaryList = new List<string>();
            var SalaryQry = from s in _context.Vacancies
                            orderby s.Salary
                            select s.Salary;
            SalaryList.AddRange(SalaryQry.Distinct());
            ViewBag.Salary = new SelectList(SalaryList);


            var EmploymentList = new List<string>();
            var EmploymentQry = from e in _context.Vacancies
                                orderby e.EmploymentType
                                select e.EmploymentType;
            EmploymentList.AddRange(EmploymentQry.Distinct());
            ViewBag.EmploymentType = new SelectList(EmploymentList);


            var ExperienceList = new List<string>();
            var ExperienceQry = from ex in _context.Vacancies
                                orderby ex.ExperienceRequired
                                select ex.ExperienceRequired;
            ExperienceList.AddRange(ExperienceQry.Distinct());
            ViewBag.Experience = new SelectList(ExperienceList);

            var CityList = new List<string>();
            var CityQry = from d in _context.Vacancies
                          orderby d.City
                          select d.City;

            CityList.AddRange(CityQry.Distinct());
            ViewBag.vacancyCity = new SelectList(CityList);
            var vacancies = from v in _context.Vacancies
                         select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vacancies = vacancies.Where(s => s.Name.Contains(searchString));
            }
            if(!String.IsNullOrEmpty(vacancyCity))
            {
                vacancies = vacancies.Where(x => x.City == vacancyCity);
            }
            if (!String.IsNullOrEmpty(EmploymentType))
            {
                vacancies = vacancies.Where(e => e.EmploymentType == EmploymentType);
            }
            if (!String.IsNullOrEmpty(Experience))
            {
                vacancies = vacancies.Where(ex => ex.ExperienceRequired == Experience);
            }
            if (!String.IsNullOrEmpty(Salary))
            {
                vacancies = vacancies.Where(s => s.Salary == Salary);
            }
            return View(vacancies);
        }

        // GET: Vacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancies
                .Include(v => v.IdCompanyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // GET: Vacancies/Create
        public IActionResult Create()
        {
            ViewData["IdCompany"] = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        // POST: Vacancies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,City,ExperienceRequired,PublicationDate,EmploymentType,Responsibilities,Requirements,Conditions,Salary,IsActive,IdCompany,IdHr")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompany"] = new SelectList(_context.Companies, "Id", "Name", vacancy.IdCompany);
            return View(vacancy);
        }
        public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            ViewData["IdCompany"] = new SelectList(_context.Companies, "Id", "Name", vacancy.IdCompany);
            return LocalRedirectPermanent("~/Replies/Create/{id}");
        }

        // POST: Vacancies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reply(int id, Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyExists(vacancy.Id))
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
            ViewData["IdCompany"] = new SelectList(_context.Companies, "Id", "Name", vacancy.IdCompany);
            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            ViewData["IdCompany"] = new SelectList(_context.Companies, "Id", "Name", vacancy.IdCompany);
            return View(vacancy);
        }

        // POST: Vacancies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,City,ExperienceRequired,PublicationDate,EmploymentType,Responsibilities,Requirements,Conditions,Salary,IsActive,IdCompany,IdHr")] Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyExists(vacancy.Id))
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
            ViewData["IdCompany"] = new SelectList(_context.Companies, "Id", "Name", vacancy.IdCompany);
            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancies
                .Include(v => v.IdCompanyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);
            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyExists(int id)
        {
            return _context.Vacancies.Any(e => e.Id == id);
        }
    }
}
