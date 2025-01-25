using System;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this._context = context;
        }

        public Employee Add(Employee employee)
        {
            _context.empTarget.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id1)
        {
            Employee emp = _context.empTarget.Find(id1);
            if(emp != null)
            {
                _context.empTarget.Remove(emp);
                _context.SaveChanges();
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.empTarget;
        }

        public Employee GetEmployee(int id1)
        {
            return _context.empTarget.Find(id1);
        }

        public Employee Update(Employee eCh)
        {
            var employee = _context.empTarget.Attach(eCh);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return eCh;
        }
        

    }
}










