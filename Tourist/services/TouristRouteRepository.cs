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

        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword)
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
