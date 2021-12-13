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
        public TouristRoute GetTouristRoute(Guid id)
        {
            return _context.TouristRoutes
                .Include(n => n.TouristRoutePictures)
                .FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.TouristRoutes
                .Include(n => n.TouristRoutePictures);
        }

        public bool TouristRouteExists(Guid id)
        {
            return _context.TouristRoutes.Any(n => n.Id == id);
        }

        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            return _context.TouristRoutesPictures
                .Where(n => n.TouristRouteId == touristRouteId ).ToList();
        }

        public TouristRoutePicture GetPicture(int pictureId)
        {
            return _context.TouristRoutesPictures.FirstOrDefault(n => n.Id == pictureId);
        }
    }
}
