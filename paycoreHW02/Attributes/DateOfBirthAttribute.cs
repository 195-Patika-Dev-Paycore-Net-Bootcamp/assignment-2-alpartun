using System.ComponentModel.DataAnnotations;

namespace paycoreHW02.Attributes;

public class DateOfBirthAttribute:ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        try
        {
            if (value.ToString().Length != 10) return new ValidationResult("Invalid");
            if (!(value.ToString().Any(x=> char.IsDigit(x) && value.ToString().Contains('-') && !char.IsLetter(x)))) return new ValidationResult("Invalid Date of Birth");
            string[] text = value.ToString().Split("-");


            DateTime date = new DateTime(Convert.ToInt32(text[2]),Convert.ToInt32(text[1]),Convert.ToInt32(text[0]));
            var max = new DateTime(2002,10,10);
            var min = new DateTime(1945,11,11);
            var msg = string.Format($"Please enter a value between {min:MM/dd/yyyy} and {max:MM/dd/yyyy}");
            if (date < min || date > max)
                return new ValidationResult(msg);
            else
                return ValidationResult.Success;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ValidationResult("Invalid Date of Birth");
        }
    }
}