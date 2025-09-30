using Microsoft.AspNetCore.Mvc;
using cis174DMACCJessicaJohnson.Models;
using System.Collections.Generic;

namespace cis174DMACCJessicaJohnson.Controllers
{
    public class AssignmentsController : Controller
    {
        [Route("Assignments/Assignment61/{accessLevel:int}")]
        public IActionResult Assignment61(int accessLevel)
        {
            if (accessLevel < 1 || accessLevel > 10)
                return BadRequest("Access level must be between 1 and 10.");

            var students = new List<Student>
    {
        new Student { FirstName="Alice", LastName="Smith", Grade="A" },
        new Student { FirstName="Bob", LastName="Johnson", Grade="B" },
        new Student { FirstName="Charlie", LastName="Brown", Grade="C" },
        new Student { FirstName="Diana", LastName="Lee", Grade="A+" }
    };

            ViewData["AccessLevel"] = accessLevel;

            return View(students);
        }

    }
}
