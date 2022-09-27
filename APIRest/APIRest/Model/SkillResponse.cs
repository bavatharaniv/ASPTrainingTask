using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Model
{
    public class SkillResponse
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public List<string> Employee { get; set; }
    }
}
