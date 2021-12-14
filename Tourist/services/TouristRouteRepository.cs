using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tourist.API.database;
using Tourist.API.Models;

namespace Tourist.API.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;
        public TouristRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string rating)
        {
            //var result = _context.TouristRoutes
            //    .Include(t => t.TouristRoutePictures);
            IQueryable<TouristRoute> result = _context.TouristRoutes
                .Include(t => t.TouristRoutePictures);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(t => t.Title.Contains(keyword));
            }
            if (!string.IsNullOrWhiteSpace(rating))
            {
                var regex = new Regex(@"([A-Za-z0-9\-]+)(\d+)");
                string operatorType = "";
                int ratingValue = -1;
                Match match = regex.Match(rating);
                if (match.Success)
                {
                    operatorType = match.Groups[1].Value;
                    ratingValue = Int32.Parse(match.Groups[2].Value);
                }
                //switch (operatorType)
                //{
                //    case "largerThan":
                //        result = result.Where(t => t.Rating >= ratingValue);
                //        break;
                //    case "lessThan":
                //        result = result.Where(t => t.Rating <= ratingValue);
                //        break;
                //    case "equal":
                //    default:
                //        break;
                //}
                result = operatorType switch
                {
                    "largerThan" => result.Where(t => t.Rating >= ratingValue),
                    "lessThan" => result.Where(t => t.Rating <= ratingValue),
                    //"equal" => result.Where(t => t.Rating == ratingValue),
                    _ => result.Where(t => t.Rating == ratingValue),
                };
            }
            return result.ToList();
        }

        public TouristRoute GetTouristRoute(Guid id)
        {
            return _context.TouristRoutes
                .Include(t => t.TouristRoutePictures)
                .FirstOrDefault(t => t.Id == id);
        }

        public bool TouristRouteExists(Guid id)
        {
            return _context.TouristRoutes.Any(t => t.Id == id);
        }

        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            return _context.TouristRoutesPictures
                .Where(t => t.TouristRouteId == touristRouteId ).ToList();
        }

        public TouristRoutePicture GetPicture(int pictureId)
        {
            return _context.TouristRoutesPictures.FirstOrDefault(t => t.Id == pictureId);
        }
    }
}
