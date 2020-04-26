using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaNews.Model
{
    public class GetAllData
    {
        //public DateTime updated { get; set; }
        public double cases { get; set; }
        public double todayCases { get; set; }
        public double deaths { get; set; }
        public double todayDeaths { get; set; }
        public double recovered { get; set; }
        public double active { get; set; }
        public double critical { get; set; }
        public double casesPerOneMillion { get; set; }
        public double deathsPerOneMillion { get; set; }
        public double tests { get; set; }
        public double testsPerOneMillion { get; set; }
        public double affectedCountries { get; set; }
    }
}
