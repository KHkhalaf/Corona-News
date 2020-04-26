using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaNews.Model
{
    public class countryInfo
    {
        public int? _id {get;set;}
        public String iso2 { get; set; }
        public String  iso3 { get; set; }
        public double lat { get; set; }
        public double longs { get; set; }
        public string flag { get; set; }
    }
}
