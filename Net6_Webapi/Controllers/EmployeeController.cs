using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net6_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        // Get all data
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllemp()
        {          
            return Ok(await _context.Employees.ToArrayAsync());
        }

        // Get Single data
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Getemp(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            return (emp is null) ? BadRequest("Emp not found"): Ok(emp);            
        }

        // Add new data
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> Addemp(Employee newemp)
        {
            _context.Employees.Add(newemp);
            await _context.SaveChangesAsync();            
            
            return Ok(await _context.Employees.ToArrayAsync());
        }

        // Update data
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> Updateemp(Employee requestEmp)
        {
            var updatedata = await _context.Employees.FindAsync(requestEmp.Id);            

            if(updatedata is null)
            {
                return BadRequest("Emp not found");
            }

            updatedata.FirstName = requestEmp.FirstName;
            updatedata.LastName = requestEmp.LastName;
            updatedata.Birthday = requestEmp.Birthday;
            updatedata.Address = requestEmp.Address;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToArrayAsync());
        }

        // Delete data
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> Deleteemp(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp is null)
            {
                return BadRequest("Emp not found");
            }
            
            _context.Remove(emp);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToArrayAsync());
        }

    }
}
