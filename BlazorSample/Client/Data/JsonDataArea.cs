
namespace BlazorSample.Client.Data
{

    public class JsonDataArea
    {
        public Centers centers { get; set; } = new Centers();
        public Offices offices { get; set; } = new Offices();
        public Class10s class10s { get; set; } = new Class10s();
        public Class15s class15s { get; set; } = new Class15s();
        public Class20s class20s { get; set; } = new Class20s();
    }

    public class Centers
    {
        public Dictionary<string, CenterAreaData> areas { get; set; } = new Dictionary<string, CenterAreaData> { };
    }

    public class Offices
    {
        public Dictionary<string, OfficeAreaData> areas { get; set; } = new Dictionary<string, OfficeAreaData> { };
    }

    public class Class10s
    {
        public Dictionary<string, AreaData> areas { get; set; } = new Dictionary<string, AreaData> { };
    }

    public class Class15s
    {
        public Dictionary<string, AreaData> areas { get; set; } = new Dictionary<string, AreaData> { };
    }

    public class Class20s
    {
        public Dictionary<string, AreaData2> areas { get; set; } = new Dictionary<string, AreaData2> { };
    }

    public class CenterAreaData
    {
        public string name { get; set; }
        public string enName { get; set; }
        public string officeName { get; set; }
        public string[] children { get; set; }
    }

    public class OfficeAreaData
    {
        public string name { get; set; }
        public string enName { get; set; }
        public string officeName { get; set; }
        public string parent { get; set; }
        public string[] children { get; set; }
    }

    public class AreaData
    {
        public string name { get; set; }
        public string enName { get; set; }
        public string parent { get; set; }
        public string[] children { get; set; }
    }

    public class AreaData2
    {
        public string name { get; set; }
        public string enName { get; set; }
        public string kana { get; set; }
        public string parent { get; set; }
    }

}
