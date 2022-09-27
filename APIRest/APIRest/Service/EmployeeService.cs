using APIRest.Interface;
using APIRest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RestDbContext _restdbContext;
        public EmployeeService(RestDbContext restdbContext)
        {
            _restdbContext = restdbContext;
        }
        public async Task<IEnumerable<Employeeswithskills>> GetEmployees()
        {
            var data = await _restdbContext.Employees.Include(x => x.SkillMap).ThenInclude(x => x.Skills).Select(x => new Employeeswithskills()
            {
                EmployeeId = x.EmployeeId,
                EmpName = x.EmpName,
                Status = x.Status,
                Manager = x.Manager,
                WFManager = x.WFManager,
                Email = x.Email,
                Experience = x.Experience,
                Lockstatus = x.Lockstatus,
                ProfileId = x.ProfileId,
                Skills = x.SkillMap.Select(y => y.Skills.SkillName).ToList()
            }).ToListAsync();

            if (data != null)
            {
                return data;
            }
            return new List<Employeeswithskills>();
        }
    }
}
