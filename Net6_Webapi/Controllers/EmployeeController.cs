using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net6_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> empData = new List<Employee>
        {
            new Employee {
                FirstName = "Alen",
                LastName = "Wu",
                Birthday = "2022-01-01",
                Address = "KaohsiungCity"
            },
        };



        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllemp()
        {
            

            return Ok(empData);
        }
    }
}
