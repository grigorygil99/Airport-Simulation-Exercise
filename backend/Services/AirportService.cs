using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using backend.Domain;

namespace backend.Services
{
    public class AirportService : IAirportService
    {

        Airport airport;
        
        public AirportService()
        {
            //this should have been a repository class
            this.airport = Airport.Instance;
        }

        public string GetTraffic(){
            return this.airport.controlTower.traffic.ToString();
        }

        public string GetRequests(){
            return this.airport.controlTower.RequestsToString();
        }

        public bool RequestLanding(string flightCode){

            Airplane airplane = new Airplane("Boeing 737");
            Flight flight = new Flight(flightCode, airplane);            

            return this.airport.controlTower.RequestLand(flight);
        }

        public bool RequestDeparture(string flightCode){

            Airplane airplane = new Airplane("Boeing 737");
            Flight flight = new Flight(flightCode, airplane);            

            return this.airport.controlTower.RequestDepart(flight);
        }
        
        public bool FinishLanding(string flightCode){

            Airplane airplane = new Airplane("Boeing 737");
            Flight flight = new Flight(flightCode, airplane);            

            return this.airport.controlTower.FinishLand(flight);
        }

        public bool FinishDeparture(string flightCode){
 
            Airplane airplane = new Airplane("Boeing 737");
            Flight flight = new Flight(flightCode, airplane);            

            return this.airport.controlTower.FinishDepart(flight);   
        }
    }
}