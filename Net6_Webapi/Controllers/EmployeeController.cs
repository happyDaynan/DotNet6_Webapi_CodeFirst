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


        // Get all data
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllemp()
        {           

            return Ok(empData);
        }

        // Get Single data
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Getemp(int id)
        {
            var emp = empData.Find(x => x.Id == id);

            return (emp is null) ? BadRequest("Emp not found"): Ok(emp);            
        }

        // Add new data
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> Addemp(Employee newemp)
        {
            empData.Add(newemp);
            return Ok(empData);
        }

        // Update data
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> Updateemp(Employee requestEmp)
        {
            var updatedata = empData.Find(x => x.Id == requestEmp.Id);

            if(updatedata is null)
            {
                return BadRequest("Emp not found");
            }

            updatedata.FirstName = requestEmp.FirstName;
            updatedata.LastName = requestEmp.LastName;
            updatedata.Birthday = requestEmp.Birthday;
            updatedata.Address = requestEmp.Address;

            return Ok(empData);
        }

        // Delete data
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> Deleteemp(int id)
        {
            var emp = empData.Find(x => x.Id == id);

            if (emp is null)
            {
                return BadRequest("Emp not found");
            }

            empData.Remove(emp);

            return Ok(empData);
        }


    }
}
