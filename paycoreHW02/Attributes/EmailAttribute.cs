using System.ComponentModel.DataAnnotations;

namespace paycoreHW02.Attributes;

public class EmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        try
        {
            if (value.ToString().Any(x => char.IsDigit(x) )) return new ValidationResult("Invalid email digit.");
            string check = value.ToString().Replace(".", "").Replace("@","");
            
            if (check.Any(x => !char.IsLetter(x)))
                return new ValidationResult("Invalid email with special chars.");
            var email = value as string;

            // Is this a valid email address?
            if (this.IsValidEmailAddress(email)) return ValidationResult.Success;
            else
            {
                return new ValidationResult("Invalid email. parameter");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ValidationResult("Invalid Email. error");
        }
    }
    private bool IsValidEmailAddress(string emailToValidate)
    {
        var emailAttribute = new EmailAddressAttribute();

        return emailAttribute.IsValid(emailToValidate);
    }
}