using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPP.Data;
using TPP.Models;


namespace TPP.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);

            foreach (String s in studentRepository.GetCourses())
                Debug.WriteLine(s);

            return View(studentRepository.GetCourses());
        }

        public IActionResult GetStudentsByCourse(string x)
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            IEnumerable<Student> res = (IEnumerable<Student>)studentRepository.Find(v => v.course.ToLower() == x.ToLower());

           if (res.Count() != 0) ViewBag.Id = res.First().course;
            return View(res);
        }
        
    }
}

