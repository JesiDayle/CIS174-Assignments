using Microsoft.AspNetCore.Mvc;

namespace HomeworkDemoApp.Controllers
{
    public class AssignmentsController : Controller
    {
        // Default routing
        public IActionResult DefaultPage()
        {
            ViewData["Title"] = "Default Routing Page";
            return View();
        }

        // Custom routing
        public IActionResult CustomRoutePage()
        {
            ViewData["Title"] = "Custom Routing Page";
            return View();
        }

        // Attribute routing
        [Route("Assignments/Attribute")]
        public IActionResult AttributeRoutePage()
        {
            ViewData["Title"] = "Attribute Routing Page";
            return View();
        }
    }
}
