using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Controllers
{
    public class BaseController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BaseApiController : ControllerBase
        {

        }
    }
}
