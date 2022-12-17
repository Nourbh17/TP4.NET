using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPP.Data;
using TPP.Models;


namespace TPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            List<Student> s = universityContext.Student.ToList();
            foreach (Student student in s)
            {
                Debug.WriteLine("Student:  {0} {1} {2} {3} {4} {5} {6}   ", student.id, student.first_name, student.last_name, student.phone_number, student.university, student.timestamp, student.course);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}