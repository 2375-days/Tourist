using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tourist.API.ValidationAttributes;

namespace Tourist.API.Dtos
{
    public class TouristRouteForUpdateDto:TouristRouteForManipulationDto
    {
        [Required(ErrorMessage = "Description更新必备")]
        [MaxLength(100)]
        public override string Description { get; set; }
    }
}
