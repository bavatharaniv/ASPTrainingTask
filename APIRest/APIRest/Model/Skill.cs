using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Model
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public ICollection<SkillMap> SkillMap { get; set; }
    }
    public class Skillswithemployees
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public List<string> Employees { get; set; }

    }
}
