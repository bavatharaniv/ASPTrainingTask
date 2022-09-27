using APIRest.Interface;
using APIRest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Service
{
    public class SkillService : ISkillService
    {
        private readonly RestDbContext _restdbContext;
        public SkillService(RestDbContext restdbContext)
        {
            _restdbContext = restdbContext;
        }
        public async Task<IEnumerable<SkillResponse>> GetAllSkills()
        {
            var result = await _restdbContext.Skills.Include(x => x.SkillMap).ThenInclude(x => x.Skills).Select(x => new SkillResponse
            {
                SkillId = x.SkillId,
                Name = x.SkillName,
                Employee = x.SkillMap.Select(y => y.Employee.EmpName).ToList()
            }).ToListAsync();
            return result;
        }
    }
}
