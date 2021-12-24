using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tourist.API.Services;
using Tourist.API.Dtos;
using AutoMapper;
using Tourist.API.Models;

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
        public IActionResult GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var pictures = _touristRouteRepository.GetPicturesByTouristRouteId(touristRouteId);
            if (pictures == null)
            {
                return NotFound("图片资源不存在");
            }
            var pictursDto = _mapper.Map<IEnumerable<TouristRoutePictureDto>>(pictures);
            return Ok(pictursDto);
        }

        [HttpGet("{pictureId}", Name = "GetPicture")]
        public IActionResult GetPicture(Guid touristRouteId, int pictureId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
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

        [HttpPost]
        public IActionResult CreateTouristPicture(
           [FromRoute] Guid touristRouteId,
           [FromBody] TouristRoutePictureForCreationDto touristRoutePictureForCreationDto)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var pictureModel = _mapper
                .Map<TouristRoutePictureForCreationDto, TouristRoutePicture>(touristRoutePictureForCreationDto);
            _touristRouteRepository.AddTouristRoutePicture(touristRouteId, pictureModel);
            _touristRouteRepository.Save();
            var pictureToreturn = _mapper.Map<TouristRoutePicture, TouristRoutePictureDto>(pictureModel);
            return CreatedAtRoute(
                "GetPicture",
                new { 
                    touristRouteId = pictureModel.TouristRouteId,
                    pictureId = pictureModel.Id
                },
                pictureToreturn
            );
        }

        [HttpDelete("{pictureId}")]
        public IActionResult DeletePicture(
            [FromRoute] Guid touristRouteId,
            [FromRoute] int pictureId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var picture = _touristRouteRepository.GetPicture(pictureId);
            if (picture == null)
            {
                return NotFound("图片不存在");
            }
            _touristRouteRepository.DeleteTouristRoutePicture(picture);
            _touristRouteRepository.Save();

            return NoContent();
        }

    }
}
