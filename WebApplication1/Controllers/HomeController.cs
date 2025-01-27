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
            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("employeenotfound", id.Value);
            }

            HomeDetailsViewModel hDVM = new HomeDetailsViewModel()
            {
                employee = employee,
                pageTitle = "Jello Details"
            };

            return View(hDVM);

        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel empEVM = new EmployeeEditViewModel
            {
                id = employee.id,
                name = employee.name,
                email = employee.email,
                department = employee.department,
                existingphotopath = employee.PhotoPath
            };
            return View(empEVM);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.id);
                employee.name = model.name;
                employee.email = model.email;
                employee.department = model.department;

                string uniqueFileName = ProcessUploadedFile(model);

                Employee newEmp = new Employee
                {
                    name = model.name,
                    email = model.email,
                    department = model.department,
                    PhotoPath = uniqueFileName

                };
                _employeeRepository.Update(employee);
                return RedirectToAction("index");
            }
            return View();

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
                string uniqueFileName = ProcessUploadedFile(model);
     
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

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            return uniqueFileName;
        }

    }
}




















