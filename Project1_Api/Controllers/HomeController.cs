using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Index")]
        [Authorize(Roles= "Customer")]
        public IActionResult Index()
        {
            return Ok("You are a verified user");
        }
        [HttpGet("Privacy")]
        [Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            return Ok("only admins can access");
        }
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok();
        }
    }
}
