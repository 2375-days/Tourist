using System;
using System.Collections.Generic;
using Tourist.API.Models;

namespace Tourist.API.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string rating);
        TouristRoute GetTouristRoute(Guid id);
        bool TouristRouteExists(Guid id);
        IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId);
        TouristRoutePicture GetPicture(int pictureId);
        void AddTouristRoute(TouristRoute touristRouteModel);
        bool Save();
    }
}
