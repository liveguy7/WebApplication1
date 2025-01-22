using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository; 

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

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

    }
}























