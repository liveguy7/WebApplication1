using System;

namespace WebApplication1.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id1);
        IEnumerable<Employee> GetAllEmployees();
        Employee Add(Employee employee);
    }

}
