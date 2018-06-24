using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCalculator.Api.Model;
using WebCalculator.Calculation.Service;

namespace WebCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    public class CalculateController : Controller
    {
        private readonly ICalculator calculator;

        public CalculateController(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        // GET api/calculate/(6+5)
        [HttpGet("{*expression}")]
        public ResultViewModel Get(string expression)
        {
            return new ResultViewModel()
            {
                Result = calculator.Calculate(expression)
            };
        }
    }
}
