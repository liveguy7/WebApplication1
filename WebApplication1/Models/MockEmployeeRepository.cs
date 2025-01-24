using System;

namespace WebApplication1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _empList;
        public MockEmployeeRepository()
        {
            _empList = new List<Employee>()
            {
                new Employee() {id=1, name="Jello", department=Dept.HR, email="jello@na.com"},
                new Employee() {id=2, name="Pan", department=Dept.IT, email="pan@na.com"},
                new Employee() {id=3, name="Han", department=Dept.IT, email="han@na.com"}

            };
        }
        
        public Employee GetEmployee(int id1)
        {
            return _empList.FirstOrDefault(e => e.id == id1);

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _empList;

        }

        public Employee Add(Employee emp1)
        {
            emp1.id = _empList.Max(e => e.id) + 1;
            _empList.Add(emp1);

            return emp1;
        }


    }
}


























