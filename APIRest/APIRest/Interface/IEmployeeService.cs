using APIRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Interface
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employeeswithskills>> GetEmployees();
    }
}
