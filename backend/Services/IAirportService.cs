
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IAirportService
    {
        string GetTraffic();

        string GetRequests();

        bool RequestLanding(string flightCode);

        bool RequestDeparture(string flightCode);
        
        bool FinishLanding(string flightCode);

        bool FinishDeparture(string flightCode);
    }
}