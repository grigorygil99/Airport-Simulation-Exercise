
namespace backend.Domain{
    public class Request{
        private Flight flight;
        private string requestType;
        private bool authorization;

        public Request(Flight flight, string requestType, bool authorization){
            this.flight = flight;
            this.requestType = requestType;
            this.authorization = authorization;
        }

        override
        public string ToString(){
            return "{ \"Flight\": " + flight.ToString() + ", \"requestType\": \"" +  requestType 
            + "\", \"authorization\" : " + (this.authorization? "true" : "false")+" }";           
        }


    }

}