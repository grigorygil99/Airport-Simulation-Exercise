using System.Collections.Generic;

namespace backend.Domain{
    public class ControlTower{
    
        public Traffic traffic {get;}
        private Stack<Request> requests {get;}

        public ControlTower(Traffic traffic){
            this.traffic = traffic;
            this.requests = new Stack<Request>();
        }

        public bool RequestDepart(Flight flight){
            bool authorization = this.traffic.StartDeparting(flight);
            Request r = new Request(flight, "startDeparting", authorization);
            requests.Push(r);
            return authorization;
        }
        
        public bool RequestLand(Flight flight){
            bool authorization = this.traffic.StartLanding(flight);
            Request r = new Request(flight, "startLanding", authorization);
            requests.Push(r);
            return authorization;
        }

       public bool FinishDepart(Flight flight){
            bool authorization = this.traffic.FinishDeparting(flight);
            Request r = new Request(flight, "finishDeparting", authorization);
            requests.Push(r);
            return authorization;
        }

       public bool FinishLand(Flight flight){
            bool authorization = this.traffic.FinishLanding(flight);
            Request r = new Request(flight, "finishLanding", authorization);
            requests.Push(r);
            return authorization;
        }

        public string RequestsToString(){
            string requestsString = "{\n\"requests\": [";
            foreach(Request request in this.requests)
                requestsString = requestsString + "\n\t" +request.ToString() + ",";
            
            if(requestsString[requestsString.Length-1]!='[')
                requestsString = requestsString.Substring(0,requestsString.Length-1);    
            requestsString = requestsString + " ]\n}";
        
            return requestsString;
        }


    }
}