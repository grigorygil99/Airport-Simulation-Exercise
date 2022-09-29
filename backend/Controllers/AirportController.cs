using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Domain;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {

        private readonly ILogger<AirportController> _logger;

        private readonly IAirportService _iAirportService;

        public AirportController(ILogger<AirportController> logger,
            IAirportService IAirportService)
        {
            _logger = logger;
            _iAirportService = IAirportService;
        }

        //GET api/Airport
        [HttpGet("traffic")]
        public string GetTraffic()
        {
            return this._iAirportService.GetTraffic();
        }

        //GET api/Airport
        [HttpGet("requests")]
        public string GetRequests()
        {
            return this._iAirportService.GetRequests();
        }

        //UC 01: As a pilot I want to request a landing
        [HttpPut("requestlanding={flightCode}")] 
        public bool RequestLanding(string flightCode){
            return this._iAirportService.RequestLanding(flightCode);
        }
        //UC 02: As a pilot I want to request a departure
        [HttpPut("requestdeparture={flightCode}")] 
        public bool RequestDeparture(string flightCode){
            return this._iAirportService.RequestDeparture(flightCode);
        }
        
        //UC 03: As a pilot I want to notify I finished landing
        [HttpPut("finishlanding={flightCode}")] 
        public bool FinishLanding(string flightCode){
            return this._iAirportService.FinishLanding(flightCode);
        }

        //UC 04: As a pilot I want to notify I finished departing
        [HttpPut("finishdeparture={flightCode}")] 
        public bool FinishDeparture(string flightCode){
            return this._iAirportService.FinishDeparture(flightCode);
        }
    }
}
