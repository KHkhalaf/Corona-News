using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CoronaNews.Model;
using CoronaNews.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace CoronaNews.CustomControl
{
    public class Api
    {
        private static HttpClient HttpClient = new HttpClient(App.Instance.HttpMessageHandler);

        public static string URL = "https://corona.lmao.ninja/";
        // all world url https://corona.lmao.ninja/


        private static async Task<JObject> ApiQuery(String Property, string json)
        {
            try
            {
                if (!App.Instance.CheckInternet())
                {
                    //App.Current.MainPage = new Message(MessageType.Error, AppResources.App_StopMessage, AppResources.App_StopButton);
                    return null;
                }

                Uri uri = new Uri(URL + Property);

                StringContent httpContent = null;

                if (!string.IsNullOrWhiteSpace(json))
                    httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                if (httpContent == null) return null;



                HttpClient = new HttpClient(App.Instance.HttpMessageHandler)
                {
                    Timeout = TimeSpan.FromSeconds(10),
                };

                HttpResponseMessage response = await HttpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<CountryModel> o;

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    {

                        JObject result = null;

                        result = JObject.Parse(streamReader.ReadToEnd());


                        return result;
                    }
                }
                else
                {
                }
            }
            catch (Exception e)
            {
              //ig
            }

            return null;
        }


        public static async Task<List<CountryModel>> GetCountryData()
        {
            try
            {
                if (!App.Instance.CheckInternet())
                {
                    //App.Current.MainPage = new Message(MessageType.Error, AppResources.App_StopMessage, AppResources.App_StopButton);
                    return null;
                }

                Uri uri = new Uri(URL + "v2/countries");

                StringContent httpContent = null;

                var stringJSON = await Task.Run(() => JsonConvert.SerializeObject(null));

                if (!string.IsNullOrWhiteSpace(stringJSON))
                    httpContent = new StringContent(stringJSON, Encoding.UTF8, "application/json");

                if (httpContent == null) return null;


                HttpClient = new HttpClient(App.Instance.HttpMessageHandler)
                {
                    Timeout = TimeSpan.FromSeconds(10),
                };

                HttpResponseMessage response = await HttpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializer serializer = new JsonSerializer();

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (JsonReader reader = new JsonTextReader(streamReader))
                    {
                     
                        while (!streamReader.EndOfStream)
                        {
                            return serializer.Deserialize<List<CountryModel>>(reader);
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception e)
            {
                //ig
            }

            return null;
        }


        public static async Task<GetAllData> AllData()
        {
            GetAllData model = new GetAllData();

            try
            {
                var stringJSON = await Task.Run(() => JsonConvert.SerializeObject(null));


                JObject jsonData = await ApiQuery("v2/all", stringJSON);

                if (jsonData != null) 
                {
                    model.cases = jsonData["cases"].Value<double>();
                    model.todayCases = jsonData["todayCases"].Value<double>();
                    model.deaths = jsonData["deaths"].Value<double>();
                    model.todayDeaths = jsonData["todayDeaths"].Value<double>();
                    model.recovered = jsonData["recovered"].Value<double>();
                    model.active = jsonData["active"].Value<double>();
                    model.critical = jsonData["critical"].Value<double>();
                    model.casesPerOneMillion = jsonData["casesPerOneMillion"].Value<double>();
                    model.deathsPerOneMillion = jsonData["deathsPerOneMillion"].Value<double>();
                    model.tests = jsonData["tests"].Value<double>();
                    model.testsPerOneMillion = jsonData["testsPerOneMillion"].Value<double>();
                    model.affectedCountries = jsonData["affectedCountries"].Value<double>();
                }
            }
            catch (Exception ex)
            {
            }

            return model;
        }

    }
}
