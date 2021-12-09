using System;
using System.Collections.Generic;
using Tourist.API.models;

namespace Tourist.API.services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid id);
    }
}
