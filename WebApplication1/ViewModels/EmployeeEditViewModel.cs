using Microsoft.Identity.Client;
using System;

namespace WebApplication1.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int id { get; set; }
        public string existingphotopath { get; set; }

    }
}
