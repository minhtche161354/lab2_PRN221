using System.ComponentModel.DataAnnotations;

namespace Lab2.Validation
{
    public class CustomerValidation : ValidationAttribute
    {
        public CustomerValidation()
        {
            ErrorMessage = "YOB can not be geater than current year (2023).";
        }
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return false;
            }
            int number = Int32.Parse(value.ToString());
            return (number < 2023);
            }
    }
}
