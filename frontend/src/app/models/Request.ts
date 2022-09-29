export interface Airplane{
    airplaneModel : string;   
}

export interface Flight{
    flightcode : string;
    airplane : Airplane;

}

export interface RequestModel{
    flight : Flight;
    requestType : string;
    authorization : boolean;
}