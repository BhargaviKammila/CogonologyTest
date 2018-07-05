using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class DataInput
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Pax { get; set; }
    }

    public static class FillDataStore
    {
        public static List<DataInput> AcmeFlights = new List<DataInput>();
        static FillDataStore()
        {
            AcmeFlights.Add(new DataInput { Name = "Flight1", StartDate = "2018-01-01", EndDate="2018-01-05", Pax="20" });
            AcmeFlights.Add(new DataInput { Name = "Flight2", StartDate = "2018-02-01", EndDate = "2018-02-05", Pax = "25" });
            AcmeFlights.Add(new DataInput { Name = "Flight3", StartDate = "2018-03-01", EndDate = "2018-03-05", Pax = "30" });
        }
    }
}