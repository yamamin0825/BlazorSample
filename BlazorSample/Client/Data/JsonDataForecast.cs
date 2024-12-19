using System.Diagnostics.Contracts;

namespace BlazorSample.Client.Data
{
    public class JsonDataForecast
    {
        public List<Rootobject> rootobjects { get; set;} = new List<Rootobject>();
    }

    public class Rootobject
    {
        public string publishingOffice { get; set; }
        public DateTime reportDatetime { get; set; }
        public Timesery[] timeSeries { get; set; }
        public Average tempAverage { get; set; }
        public Average precipAverage { get; set; }
    }

    public class Timesery
    {
        public DateTime[] timeDefines { get; set; }
        public Areas[] areas { get; set; }
    }
    
    public class Average
    {
        public Areas[] areas { get; set; }
    }

    public class Areas
    {
        public Area area { get; set; }
        public string[] weatherCodes { get; set; }
        public string[] weathers { get; set; }
        public string[] winds { get; set; }
        public string[] waves { get; set; }
        public string[] pops { get; set; }
        public string[] temps { get; set; }
        public string[] tempsMin { get; set; }
        public string[] tempsMinUpper { get; set; }
        public string[] tempsMinLower { get; set; }
        public string[] tempsMax { get; set; }
        public string[] tempsMaxUpper { get; set; }
        public string[] tempsMaxLower { get; set; }
        public string[] reliabilities { get; set; }
        public string min { get; set;  }
        public string max { get; set; }
    }

    public class Area
    {
        public string name { get; set; }
        public string code { get; set; }
    }

}
