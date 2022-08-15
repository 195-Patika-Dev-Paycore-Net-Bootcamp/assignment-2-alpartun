using Microsoft.AspNetCore.Mvc;
using paycoreHW02.Models;

namespace paycoreHW02.Controllers;

[Route("api/[controller]")]
[ApiController]

public class StaffController : ControllerBase
{
    static List<Staff> staffList = new List<Staff>();
    
    public StaffController()
    {

    }
    // GET
    [HttpGet("Get")]
    public IActionResult Get()
    {
        return Ok(staffList);
    }
    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var result = staffList.FirstOrDefault(x => x.Id == id);
        return Ok(result);
    }
    [HttpPost("Post")]
    public IActionResult Post([FromBody]StaffModel staffModel)
    {
        if (staffModel == null) return Ok(new { message = "Error" });
        
        var item = new Staff
        {
            Id =  staffModel.Id,
            Name = staffModel.Name,
            Lastname = staffModel.Lastname,
            DateOfBirth = staffModel.DateOfBirth,
            Email = staffModel.Email,
            PhoneNumber = staffModel.PhoneNumber,
            Salary = staffModel.Salary
        };

        staffList.Add(item);
        return Ok(//new{message = "Staff is added succesfully."}
                  staffList);
    }
    [HttpPut("Put")]
    public IActionResult Put(int id,[FromBody] StaffModel staffModel)
    {
        var removeStaff  = staffList.FirstOrDefault(x => x.Id == id);
        if (removeStaff == null) return Ok(new{message = "Staff can not be founded."});
        Staff staff = new Staff
        {
            Id = staffModel.Id,
            Name = staffModel.Name,
            Lastname = staffModel.Lastname,
            DateOfBirth = staffModel.DateOfBirth,
            Email = staffModel.Email,
            PhoneNumber = staffModel.PhoneNumber,
            Salary = staffModel.Salary
        };
        staffList.Remove(removeStaff);
        staffList.Add(staff);
        return Ok(new{message = $"Staff is changed. {staff}"});
    }
    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        var deleteStaff = staffList.FirstOrDefault(x => x.Id == id);
        if (deleteStaff == null) return Ok(new { message = "Staff not found." });

        staffList.Remove(deleteStaff);
        return Ok(new{message="Deletion is succesfully."});
    }
}