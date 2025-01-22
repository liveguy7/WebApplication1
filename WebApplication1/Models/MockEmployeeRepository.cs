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
                new Employee() {id=1, name="Jello", department="HR", email="jello@na.com"},
                new Employee() {id=2, name="Pan", department="HR", email="pan@na.com"},
                new Employee() {id=3, name="Han", department="IT", email="han@na.com"}

            };
        }
        
        public Employee GetEmployee(int id1)
        {
            return _empList.FirstOrDefault(e => e.id == id1);

        }


    }
}











