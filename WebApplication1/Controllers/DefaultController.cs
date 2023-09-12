using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.DataAccess;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values=c.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();

            }
            else
            {
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(Employee employee)
        {
            using var c = new Context();
            var em = c.Find<Employee>(employee.ID);
            if (em == null)
            {
                return NotFound();

            }
            else
            {
                em.Name = employee.Name;
                c.Update(em);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
