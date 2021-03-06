using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using Tourist.API.Services;
using AutoMapper;
using Tourist.API.Dtos;
using Tourist.API.ResouceParameters;
using Tourist.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Tourist.API.Helper;

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
            [FromQuery]TouristRouteResourceParameters parameters)
        {
            var routes = _touristRouteRepository.GetTouristRoutes(
                parameters.Keyword,
                parameters.RatingOperator,
                parameters.RatingValue
                );
            if (routes == null || routes.Count() <= 0) {
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

        [HttpPut("{touristRouteId}")]
        public IActionResult UpdateTouristRoute(
            [FromRoute] Guid touristRouteId,
            [FromBody] TouristRouteForUpdateDto touristRouteForUpdateDto)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var touristRoute = _touristRouteRepository.GetTouristRoute(touristRouteId);
            _mapper.Map(touristRouteForUpdateDto, touristRoute);
            _touristRouteRepository.Save();

            return NoContent();
        }

        [HttpPatch("{touristRouteId}")]
        public IActionResult PartiallyUpdateTouristRoute(
            [FromRoute] Guid touristRouteId,
            [FromBody] JsonPatchDocument<TouristRouteForUpdateDto> patchDocument)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            var touristRouteToPatch = _mapper.Map<TouristRouteForUpdateDto>(touristRouteFromRepo);
            patchDocument.ApplyTo(touristRouteToPatch, ModelState);
            if (!TryValidateModel(touristRouteToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(touristRouteToPatch, touristRouteFromRepo);
            _touristRouteRepository.Save();

            return NoContent();
        }

        [HttpDelete("{touristRouteId}")]
        public IActionResult DeleteTouristRoute([FromRoute]Guid touristRouteId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var touristRoute = _touristRouteRepository.GetTouristRoute(touristRouteId);
            _touristRouteRepository.DeleteTouristRoute(touristRoute);
            _touristRouteRepository.Save();

            return NoContent();
        }

        [HttpDelete("({touristIds})")]
        public IActionResult DeleteTouristRoutesByIds(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))][FromRoute]IEnumerable<Guid> touristIds)
        {
            if (touristIds == null)
            {
                return BadRequest();
            }
            var touristRoutes = _touristRouteRepository.GetTouristRoutesByIdList(touristIds);
            _touristRouteRepository.DeleteTouristRoutes(touristRoutes);
            _touristRouteRepository.Save();

            return NoContent();
        }

    }
}
