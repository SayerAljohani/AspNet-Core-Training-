using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspCoreTraining.Data;
using aspCoreTraining.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspCoreTraining.Controllers
{
    public class LecturesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public LecturesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: LecturesController
        public async Task<ActionResult> Index()
        {
            var result = await _dbContext.Lectures.ToListAsync();
            return View(result);
        }

        // GET: LecturesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dbContext.Lectures.SingleOrDefaultAsync(l=>l.Id ==id);
            return View(result);
        }

        // GET: LecturesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LecturesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LecturesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dbContext.Lectures.SingleOrDefaultAsync(l => l.Id == id);
            return View(result);
            
        }

        // POST: LecturesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Lecture lecture)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //dbContext.Courses.FindById(c=>c.id=id);
                    var _lecture = await _dbContext.Lectures.AsNoTracking().SingleOrDefaultAsync(c => c.Id == lecture.Id);

                    _lecture = lecture;
                    // dbContext.Courses
                    _dbContext.Update(_lecture);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        // GET: LecturesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LecturesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
