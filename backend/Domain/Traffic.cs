using System.Collections.Generic;

namespace backend.Domain{
    public class Traffic{
        private Queue<Flight> toDepart;
        private Queue<Flight> toLand;

        private Stack<Flight> hasDeparted;
        private Stack<Flight> hasLanded;

        private Flight track;

        private bool isLanding;
        private bool isDeparting;

        public Traffic(){
            this.toDepart = new Queue<Flight>();
            this.toLand = new Queue<Flight>();

            this.hasDeparted = new Stack<Flight>();
            this.hasLanded = new Stack<Flight>();

            this.track = null;
            this.isLanding = false;
            this.isDeparting = false;
        }

        public void AddDeparture(Flight flight){
            this.toDepart.Enqueue(flight);
        }

        public void AddLanding(Flight flight){
            this.toLand.Enqueue(flight);
        }
        
        public bool StartDeparting(Flight flight){
            if(this.toLand.Count == 0 && this.toDepart.Peek().CompareTo(flight) == 0 && track == null){
                this.toDepart.Dequeue();
                this.isDeparting = true;
                this.track = flight;
                return true;
            } else 
            {
                return false;
            }
        }

        public bool FinishDeparting(Flight flight){
            if(this.track.CompareTo(flight) == 0 && this.isDeparting){
                this.isDeparting = false;
                this.track = null;
                this.hasDeparted.Push(flight);
                return true;
            } else {
                return false;
            }
        }

        public bool StartLanding(Flight flight){
            if(this.toLand.Peek().CompareTo(flight) == 0 && track == null) {
                this.toLand.Dequeue();
                this.isLanding = true;
                this.track = flight;
                return true;
            } else
            {
                return false;
            }
        }

        public bool FinishLanding(Flight flight){
            if(this.track.CompareTo(flight) == 0 && this.isLanding){
                this.isLanding = false;
                this.track = null;
                this.hasLanded.Push(flight);
                return true;
            } else {
                return false;
            }
        }
        //JSON parsed string
        override    
        public string ToString(){
            string trackString = "\n\"track\": " + ((track==null)? "{}" : track.ToString()) ;
            string isLandingString = "\n\"isLanding\": " + (this.isLanding? "true" : "false");
            string isDepartingString = "\n\"isDeparting\": " + (this.isDeparting? "true" : "false");

            string toLandString = "\n\"toLand\": [";
            foreach(Flight flight in this.toLand)
                toLandString = toLandString + "\n\t" +flight.ToString() + ",";
            
            if(toLandString[toLandString.Length-1]!='[')
                toLandString = toLandString.Substring(0,toLandString.Length-1);    
            toLandString = toLandString + " ]";
    
            string toDepartString = "\n\"toDepart\": [";
            foreach(Flight flight in this.toDepart)
                toDepartString = toDepartString + "\n\t" + flight.ToString() + ",";
            
            if(toDepartString[toDepartString.Length-1]!='[')
                toDepartString = toDepartString.Substring(0,toDepartString.Length-1);    
            toDepartString = toDepartString + " ]";      

            string hasLandedString = "\n\"hasLanded\": [";
            foreach(Flight flight in this.hasLanded)
                hasLandedString = hasLandedString + "\n\t" +flight.ToString() + ",";
            
            if(hasLandedString[hasLandedString.Length-1]!='[')
                hasLandedString = hasLandedString.Substring(0,hasLandedString.Length-1);    
            hasLandedString = hasLandedString + " ]";
    
            string hasDepartedString = "\n\"hasDeparted\": [";
            foreach(Flight flight in this.hasDeparted)
                hasDepartedString = hasDepartedString + "\n\t" + flight.ToString() + ",";
            
            if(hasDepartedString[hasDepartedString.Length-1]!='[')
                hasDepartedString = hasDepartedString.Substring(0,hasDepartedString.Length-1);    
            hasDepartedString = hasDepartedString + " ]";      


            return "{\n" + trackString + "," + isLandingString + "," + isDepartingString + "," + 
            toLandString + "," + toDepartString + "," + hasLandedString + "," + hasDepartedString +"\n}";
        }

    }
}