using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Tourist.API.Services;

namespace Tourist.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteRepository _touristRouteRepository;
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _touristRouteRepository = touristRouteRepository;
        }

        [HttpGet]
        public IActionResult GetTouristRoutes()
        { 
            var routes =  _touristRouteRepository.GetTouristRoutes();
            if (routes == null || routes.Count() <= 0) {
                return NotFound("没有旅游路线");
            }
            return Ok(routes);
        }

        [HttpGet("{touristRouteId}")]
        public IActionResult GetTouristRoute(Guid touristRouteId)
        {
            var route = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (route == null) 
            {
                return NotFound($"旅游路线{touristRouteId}未找到");
            }
            return Ok(route);
        }

    }
}
