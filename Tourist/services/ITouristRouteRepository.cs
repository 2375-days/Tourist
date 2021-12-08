using System;
using System.Collections.Generic;
using Tourist.models;

namespace Tourist.services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid id);
    }
}
