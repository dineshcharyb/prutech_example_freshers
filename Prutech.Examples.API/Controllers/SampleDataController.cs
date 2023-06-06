using Microsoft.AspNetCore.Mvc;
using Prutech.Examples.API.Models;

namespace Prutech.Examples.API.Controllers;

[Route("[controller]")]
[ApiController]
public class SampleDataController : ControllerBase
{
    private static List<Employee> employees = new List<Employee>();

    public SampleDataController()
    {

    }

    // GET:employees
    [HttpGet]
    public IActionResult GetEmployees()
    {
        return Ok(employees);
    }

    // GET: employees/{id}
    [HttpGet("{id}")]
    public IActionResult GetEmployee(int id)
    {
        var employee = employees.Find(e => e.EmployeeId == id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    // POST: api/employees
    [HttpPost]
    public IActionResult CreateEmployee(Employee employee)
    {
        employee.EmployeeId = GenerateEmployeeId();
        employees.Add(employee);
        return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
    }

    // PUT: api/employees/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
    {
        var employee = employees.Find(e => e.EmployeeId == id);
        if (employee == null)
        {
            return NotFound();
        }

        // Update employee properties
        employee.EmployeeName = updatedEmployee.EmployeeName;
        employee.DateOfBirth = updatedEmployee.DateOfBirth;
        employee.Gender = updatedEmployee.Gender;
        employee.CurrentAddress = updatedEmployee.CurrentAddress;
        employee.PermanentAddress = updatedEmployee.PermanentAddress;
        employee.City = updatedEmployee.City;
        employee.Nationality = updatedEmployee.Nationality;
        employee.PINCode = updatedEmployee.PINCode;

        return NoContent();
    }

    // DELETE: api/employees/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = employees.Find(e => e.EmployeeId == id);
        if (employee == null)
        {
            return NotFound();
        }
        employees.Remove(employee);
        return NoContent();
    }

    // Generate a unique employee ID (just for demonstration)
    private int GenerateEmployeeId()
    {
        var random = new Random();
        return random.Next(1000, 9999);
    }




}
