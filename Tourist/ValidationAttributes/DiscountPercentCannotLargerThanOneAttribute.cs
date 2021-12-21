using System.ComponentModel.DataAnnotations;

namespace Tourist.API.ValidationAttributes
{
    public class DiscountPercentCannotLargerThanOneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if ((double)value > 1)
            {
                return new ValidationResult(
                    "折扣不能大于1");
            }
            return ValidationResult.Success;
        }
    }

}
