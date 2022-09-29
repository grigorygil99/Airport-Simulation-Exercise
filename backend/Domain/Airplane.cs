namespace backend.Domain{
    public class Airplane{

        string airplaneModel;

        public Airplane(string airplaneModel){
            this.airplaneModel = airplaneModel;
        }

        override
        public string ToString(){
            return "{\"airplaneModel\": \"" + airplaneModel + "\"}";
        }
    }
}