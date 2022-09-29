using System.Diagnostics;

namespace backend.Domain{

    public sealed class Airport{

        public ControlTower controlTower;

        private static Airport instance = null;

        public static Airport Instance {
            get {
                if(instance == null)
                    instance = new Airport();
            return instance;
            }
        }

        private Airport(){
            //bootstrap sequence
            Airplane a1 = new Airplane("Boeing 737");
            Airplane a2 = new Airplane("Airbus A300");


            Flight f1 = new Flight("code1", a1);
            Flight f2 = new Flight("code2", a2);
            Flight f3 = new Flight("code3", a1);

            Traffic t1 = new Traffic();

            t1.AddDeparture(f1);
            t1.AddDeparture(f2);
            t1.AddDeparture(f3);
            t1.AddLanding(f1);
            t1.AddLanding(f2);


            ControlTower ct = new ControlTower(t1);

            ct.RequestDepart(f2);
            ct.RequestDepart(f2); 
            ct.RequestLand(f1);
            
            
            Debug.WriteLine(t1.ToString());
            
            ct.FinishLand(f1);
        
            Debug.WriteLine(t1.ToString());


            ct.RequestDepart(f2);
            ct.RequestDepart(f2);
            Debug.WriteLine(t1.ToString());
        
            ct.RequestDepart(f1);
            Debug.WriteLine(t1.ToString());

            Debug.WriteLine(ct.RequestsToString());

            this.controlTower = ct;
        }
    }


}