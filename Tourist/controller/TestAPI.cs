using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Tourist.API.Controllers
{
    public class TestController : Controller
    {
        [Route("api/test")]
        public IEnumerable<string> Test()
        {
            return new string[] { "val1", "val2"};    
        }
    }
}
