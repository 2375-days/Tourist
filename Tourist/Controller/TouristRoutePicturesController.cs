using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tourist.API.Services;
using Tourist.API.Dtos;
using AutoMapper;

namespace Tourist.API.Controller
{
    [Route("api/TouristRoutes/{TouristRouteId}/pictures")]
    [ApiController]
    public class TouristRoutePicturesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;
        private IMapper _mapper;
        public TouristRoutePicturesController(
            ITouristRouteRepository touristRouteRepositroy,
            IMapper mapper
        )
        {
            _touristRouteRepository = touristRouteRepositroy ??
                throw new ArgumentNullException(nameof(touristRouteRepositroy));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetPicturesByTouristRouteId(Guid TouristRouteId)
        {
            if (!_touristRouteRepository.TouristRouteExists(TouristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var pictures = _touristRouteRepository.GetPicturesByTouristRouteId(TouristRouteId);
            if (pictures == null)
            {
                return NotFound("图片资源不存在");
            }
            var pictursDto = _mapper.Map<IEnumerable<TouristRoutePictureDto>>(pictures);
            return Ok(pictursDto);
        }

        [HttpGet("{pictureId}")]
        public IActionResult GetPicture(Guid TouristRouteId, int pictureId)
        {
            if (!_touristRouteRepository.TouristRouteExists(TouristRouteId))
            { 
                return NotFound("旅游路线不存在");
            }
            var picture = _touristRouteRepository.GetPicture(pictureId);
            if (picture == null)
            { 
                return NotFound("图片不存在");
            }
            return Ok(_mapper.Map<TouristRoutePictureDto>(picture));
        }

    }
}
