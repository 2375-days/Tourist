using System;
using System.Collections.Generic;
using System.Linq;
using Tourist.API.database;
using Tourist.API.models;

namespace Tourist.API.services
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
            return _context.TouristRoutes.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.TouristRoutes;
        }
    }
}
