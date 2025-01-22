using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository; 

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }

        public string Index()
        {
            return _employeeRepository.GetEmployee(3).name;

        }

    }
}










