﻿using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
        }

        [HttpPost]
        public IActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");
            
            return Ok(new { data = "Inbound test of Platforms Controller" });
        }
    }
}