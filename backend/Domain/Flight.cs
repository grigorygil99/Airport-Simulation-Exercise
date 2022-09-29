using System;


namespace backend.Domain{
    public class Flight : IComparable<Flight>{

        private string flightCode;
        Airplane airplane;

        public Flight(string flightCode, Airplane airplane){
            this.flightCode = flightCode;
            this.airplane = airplane;
        }

        public int CompareTo(Flight o){
            return this.flightCode.CompareTo(o.flightCode);
        }

        override
        public string ToString(){
           return "{ \"flightCode\": \"" + flightCode + "\", \"Airplane\": "+ airplane.ToString() + " }";
        }
    }
}