using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using Tourist.API.Services;
using AutoMapper;
using Tourist.API.Dtos;
using Tourist.API.Models;

namespace Tourist.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;
        public TouristRoutesController(
            ITouristRouteRepository touristRouteRepository,
            IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public IActionResult GetTouristRoutes(
            [FromQuery] string keyword,
            [FromQuery] string rating)
        {
            var routes = _touristRouteRepository.GetTouristRoutes(keyword, rating);
            if (routes == null || routes.Count() <= 0)
            {
                return NotFound("没有旅游路线");
            }
            var routesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(routes);
            return Ok(routesDto);
        }

        [HttpGet("{touristRouteId}",Name = "GetTouristRoute")]
        [HttpHead("{touristRouteId}")]
        public IActionResult GetTouristRoute(Guid touristRouteId)
        {
            var route = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (route == null)
            {
                return NotFound($"旅游路线{touristRouteId}未找到");
            }
            var routeDto = _mapper.Map<TouristRouteDto>(route);
            return Ok(routeDto);
        }

        [HttpPost]
        public IActionResult CreateTouristRoute(
            [FromBody]TouristRouteForCreationDto touristRouteForCreationDto)
        {
            var touristRouteModel = _mapper.Map<TouristRoute>(touristRouteForCreationDto);
            _touristRouteRepository.AddTouristRoute(touristRouteModel);
            _touristRouteRepository.Save();
            var touristRouteReturn = _mapper.Map<TouristRouteDto>(touristRouteModel);
            return CreatedAtRoute(
                "GetTouristRoute", 
                new { touristRouteId = touristRouteReturn.Id}, 
                touristRouteReturn);

        }

    }
}
