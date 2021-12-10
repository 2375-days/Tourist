using System;
using System.Collections.Generic;
using Tourist.API.Models;

namespace Tourist.API.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid id);
    }
}
