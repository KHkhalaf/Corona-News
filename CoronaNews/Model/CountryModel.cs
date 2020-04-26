using System;
using System.Collections.Generic;
using System.Text;
using CoronaNews.Resources;

namespace CoronaNews.Model
{
    public class CountryModel
    {
        public string country { get; set; }
        public countryInfo countryInfo { get; set; }
        public double cases { get; set; }
        public double todayCases { get; set; }
        public double deaths { get; set; }
        public double todayDeaths { get; set; }
        public double recovered { get; set; }
        public double active { get; set; }
        public double critical { get; set; }
        public double tests { get; set; }
        public double casesPerOneMillion { get; set; }
        public double deathsPerOneMillion { get; set; }
        public double testsPerOneMillion { get; set; }

        public string casesString { get; set; }
        public string todayCasesString { get; set; }
        public string deathsString { get; set; }
        public string todayDeathsString { get; set; }
        public string recoveredString { get; set; }
        public string activeString { get; set; }
        public string criticalString { get; set; }
        public string testsString { get; set; }
        public string casesPerOneMillionString { get; set; }
        public string deathsPerOneMillionString { get; set; }
        public string testsPerOneMillionString { get; set; }
        public void InitStrings(CountryModel countryModel)
        {
            casesString = $"{AppResources.Cases} : {cases:n0}";
            todayCasesString = $"{AppResources.TodayCases} : {todayCases:n0}";
            deathsString = $"{AppResources.Death} : {deaths:n0}";
            todayDeathsString = $"{AppResources.TodayDeath} : {todayDeaths:n0}";
            recoveredString = $"{AppResources.Recovered} : {recovered:n0}";
            activeString = $"{AppResources.ActiveCases} : {active:n0}";
            criticalString = $"{AppResources.Critical} : {critical:n0}";
            testsString = $"{AppResources.Test} : {tests:n0}";
            casesPerOneMillionString = $"{AppResources.casesPerOneMillion} : {casesPerOneMillion:n0}";
            deathsPerOneMillionString = $"{AppResources.deathsPerOneMillion} : {deathsPerOneMillion:n0}";
            testsPerOneMillionString = $"{AppResources.testsPerOneMillion} : {testsPerOneMillion:n0}";
        }
    }
}
