using System.Collections.Generic;

namespace Winsibo.sensibo
{
    class Json
    {
    }
    public class Room
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class Pod
    {
        public string Id { get; set; }
        public Room Room { get; set; }

    }

    public class Pods
    {
        public string Status { get; set; }
        public List<Pod> Result { get; set; }
    }




    public class AcState
    {
        public bool On { get; set; }
        public int TargetTemperature { get; set; }
        public string TemperatureUnit { get; set; }
        public string Mode { get; set; }
        public string FanLevel { get; set; }
    }

    [Newtonsoft.Json.JsonObject(Title = "AcState")]
    public class JsonAcState
    {
        public SetAcState AcState { get; set; }
    }
    public class SetAcState
    {
        public bool On { get; set; }
        public int TargetTemperature { get; set; }
        public string Mode { get; set; }
        public string FanLevel { get; set; }
    }

    public class Result
    {
        public string status { get; set; }
        public AcState acState { get; set; }
    }

    public class AcStatus
    {
        public string status { get; set; }
        public bool moreResults { get; set; }
        public List<Result> result { get; set; }
    }


    public class Time
    {
        public int secondsAgo { get; set; }
        public string time { get; set; }
    }

    public class MeasurmentValues
    {
        public Time Time { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }

    public class Measurements
    {
        public string Status { get; set; }
        public List<MeasurmentValues> Result { get; set; }
    }




    public class RequestID
    {
        public string id { get; set; }
    }

    public class setResult
    {
        public string status { get; set; }
        public RequestID result { get; set; }
    }

}
