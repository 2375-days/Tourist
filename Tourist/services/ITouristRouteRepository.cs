using System;
using System.Collections.Generic;
using Tourist.API.Models;
using Tourist.API.ResouceParameters;

namespace Tourist.API.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string ratingOperator, int? ratingValue);
        TouristRoute GetTouristRoute(Guid id);
        bool TouristRouteExists(Guid id);
        IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId);
        TouristRoutePicture GetPicture(int pictureId);
        void AddTouristRoute(TouristRoute touristRouteModel);
        bool Save();
        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture pictureModel);
        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutePicture(TouristRoutePicture picture);
        IEnumerable<TouristRoute> GetTouristRoutesByIdList(IEnumerable<Guid> touristIds);
        void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes);
    }
}
