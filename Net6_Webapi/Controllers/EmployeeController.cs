using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net6_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> empData = new()
        {
            new Employee {
                Id = 1,
                FirstName = "Alen",
                LastName = "Wu",
                Birthday = "2022-01-01",
                Address = "KaohsiungCity"
            },
            new Employee {
                Id=2,
                FirstName = "Tony",
                LastName = "Stark",
                Birthday = "1989-10-12",
                Address = "TaipeiCity"
            },
        };



        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllemp()
        {           

            return Ok(empData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Getemp(int id)
        {
            var emp = empData.Find(x => x.Id == id);

            return (emp is null) ? BadRequest("Emp not found"): Ok(emp);            
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> Addemp(Employee newemp)
        {
            empData.Add(newemp);
            return Ok(empData);
        }
    }
}
