using System.ComponentModel.DataAnnotations;

namespace paycoreHW02.Models;

public class Staff
{
    
    public int Id { get; set; }
    public string Name { get; set; } = null!; // null-forgiving operation for = null!;
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Salary { get; set; }
    
}