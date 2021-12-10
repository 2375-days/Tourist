using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Tourist.API.models;
using System.Text;
using System;

namespace Tourist.API.controller
{
    public class TestController : Controller
    {
        [Route("api/test")]
        public IEnumerable<string> Test()
        {
            return new string[] { "val1", "val2" };
        }

        [Route("api/testFileRead")]
        public IActionResult TestFileRead()
        {
            var touristRouteJsonData = System.IO.File.ReadAllText(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + 
                @"/Database/touristRoutesMockData.json"
                );
            IList<TouristRoute> touristRoutes = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJsonData);
            Console.WriteLine(touristRouteJsonData);
            Console.WriteLine(touristRoutes);
            return Ok(touristRouteJsonData);
        }
    }
}
