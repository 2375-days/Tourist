using System;
using System.Collections.Generic;
using System.Linq;
using Tourist.API.Models;

namespace Tourist.API.Services
{
    public class MockTouristRouteRepository : ITouristRouteRepository
    {
        private List<TouristRoute> _routes;
        public MockTouristRouteRepository()
        {
            if (_routes == null)
            {
                InitializeTouristRoute();
            }
        }

        public void InitializeTouristRoute()
        {
            _routes = new List<TouristRoute>
            {
                new TouristRoute{
                    Id = Guid.NewGuid(),
                    Title = "黄山",
                    Description = "黄山真好玩",
                    OriginalPrice = 1299,
                    Features = "<p>吃喝玩乐，行住游娱</p>",
                    Notes="<p>小心危险</p>"
                },
                new TouristRoute {
                    Id = Guid.NewGuid(),
                    Title = "华山",
                    Description="华山真好玩",
                    OriginalPrice = 1299,
                    Features = "<p>吃住行游购娱</p>",
                    Fees = "<p>交通费用自理</p>",
                    Notes="<p>小心危险</p>"
                }
            };
        }
        public TouristRoute GetTouristRoute(Guid id)
        {
            return _routes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _routes;
        }
    }
}
