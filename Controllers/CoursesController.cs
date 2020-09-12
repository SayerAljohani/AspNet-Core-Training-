using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspCoreTraining.Data;
using aspCoreTraining.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspCoreTraining.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public CoursesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: CoursesController
        public async Task<IActionResult> Index()
        {
            var c = await dbContext.Courses.ToListAsync();
            return View(c);
        }

        // GET: CoursesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> Lectures(int id)
        {
           var result = await dbContext.Lectures.Where(l => l.CourseId == id).ToListAsync();
            return View(result);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> AttendLecture(int id,int courseId)
        {
            var user = await GetCurrentUserAsync();
            
            try
            {
                if (ModelState.IsValid)
                {
                    //dbContext.Courses.FindById(c=>c.id=id);
                    var _lecture = await dbContext.Lectures.SingleOrDefaultAsync(c => c.Id == id);

                    var sl = new LectureStudent
                    {
                        LectureId = _lecture.Id,
                        ApplicationUserId =user?.Id
                    };
                    
                    // dbContext.Courses
                    dbContext.LectureStudents.Add(sl);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("Lectures",new { id = courseId });
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }


        // GET: CoursesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lecture lecture )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lect = new Lecture
                    {
                        Course = lecture.Course,
                        Name = lecture.Name
                    };
                    dbContext.Lectures.Add(lect);
                    dbContext.SaveChanges();

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoursesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
          var c=   await dbContext.Courses.SingleOrDefaultAsync(c => c.Id == id);
            return View(c);
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //dbContext.Courses.FindById(c=>c.id=id);
                    var _course = await dbContext.Courses.AsNoTracking().SingleOrDefaultAsync(c => c.Id == course.Id);
                  
                    _course = course;
                    // dbContext.Courses
                    dbContext.Update(_course);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View();
            }
        }

        // GET: CoursesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoursesController/Delete/5
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
