using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string WFManager { get; set; }
        public string Email { get; set; }
        public string Lockstatus { get; set; }
        public decimal Experience { get; set; }
        public int ProfileId { get; set; }       
        public ICollection<SkillMap> SkillMap { get; set; }
    }
    public class Employeeswithskills
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string WFManager { get; set; }
        public string Email { get; set; }
        public string Lockstatus { get; set; }
        public decimal Experience { get; set; }
        public int ProfileId { get; set; }
        [NotMapped]
        public List<string> Skills { get; set; }
    }
}
