using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();

            return View(model);

        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel hDVM = new HomeDetailsViewModel()
            {
                employee = _employeeRepository.GetEmployee(id ?? 1),
                pageTitle = "Jello Details"
            };

            return View(hDVM);

        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmp = new Employee
                {
                    name = model.name,
                    email = model.email,
                    department = model.department,
                    PhotoPath = uniqueFileName

                };
                _employeeRepository.Add(newEmp);
                return RedirectToAction("details", new { id = newEmp.id });
            }
            return View();

        }

    }
}









