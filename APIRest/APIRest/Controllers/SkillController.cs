using APIRest.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skill;
        public SkillController(ISkillService skill)
        {
            _skill = skill;
        }
        // GET: api/Skills
        [HttpGet]
        [Route("GetSkillsData")]
        public async Task<IActionResult> GetSkillsData()
        {
            try
            {
                var result = await _skill.GetAllSkills();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
