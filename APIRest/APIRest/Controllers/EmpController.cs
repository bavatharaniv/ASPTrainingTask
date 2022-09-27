using APIRest.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmpController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _employeeService.GetEmployees();
            return View(result);
        }
    }
}
