using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tourist.API.ValidationAttributes;

namespace Tourist.API.Dtos
{
    [TitleMustBeDifferentFromDesctiption]
    public class TouristRouteForCreationDto //:IValidatableObject
    {
        [Required(ErrorMessage ="title不可为空")]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        public decimal OriginalPrice { get; set; }

        [DiscountPercentCannotLargerThanOne]
        public double? DiscountPercent { get; set; }
        
        //public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime? DepartureTime { get; set; }

        public string Features { get; set; }

        public string Fees { get; set; }

        public string Notes { get; set; }

        public double? Rating { get; set; }

        public string TravelDays { get; set; }

        public string TripType { get; set; }

        public string DepartureCity { get; set; }

        public ICollection<TouristRoutePictureForCreationDto> TouristRoutePictures { get; set; }
            = new List<TouristRoutePictureForCreationDto>();

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
