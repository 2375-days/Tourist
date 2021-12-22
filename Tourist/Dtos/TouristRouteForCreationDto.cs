using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tourist.API.ValidationAttributes;

namespace Tourist.API.Dtos
{
    public class TouristRouteForCreationDto : TouristRouteForManipulationDto  //:IValidatableObject
    {

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult(
        //            "Title和Description不能相同",
        //            new[] { "TouristRouteForCreationDto" });
        //    }
        //}
    }
}
