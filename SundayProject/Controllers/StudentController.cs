using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SundayProject.Data;
using SundayProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SundayProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _studentContext;
        public StudentController(StudentContext studentContext) 
        {
            _studentContext = studentContext;
        }  
        public async Task<IActionResult> Index()
        {
            List<Student> students= await _studentContext.StudentsTable.ToListAsync();
            return View(students);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentContext.StudentsTable.Add(student);
                await _studentContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public async Task<IActionResult> Details(int id)
        {
            Student student = await _studentContext.StudentsTable.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Student student = await _studentContext.StudentsTable.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _studentContext.Update(student);
                await _studentContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            Student student = await _studentContext.StudentsTable.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


    }
}
