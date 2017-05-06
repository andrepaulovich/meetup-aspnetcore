using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Meetup.Security.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PublicController : Controller
    {
        public PublicController()
        {
            
        }

        // GET: api/values
        [HttpGet]        
        public object Get()
        {            
            return "Public api " + DateTime.Now.ToString();            
        }
    }
}
