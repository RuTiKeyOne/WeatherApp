using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Threading;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;

namespace Weather.View.JsonApi
{
    class JsonWeatherApi
    {
        public static WeatherResponse Wr;
        //Get Cities
        public static  void CreateJsonRequest(string city)
        {
                DispatcherTimer DispatherTimerObject = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(1000) };
                DispatherTimerObject.Start();

                DispatherTimerObject.Tick += new EventHandler((object e, EventArgs a) =>
                {
                    try
                    {
                        string Url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=82630901bb3f9ed64d98d0a72e3ad275";
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
                        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        string Response;
                        using (StreamReader SR = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            Response = SR.ReadToEnd();
                        }
                        JsonWeatherApi.Wr = JsonConvert.DeserializeObject<WeatherResponse>(Response);
                        DataAboutWeather DataAboutWeatherObject = new DataAboutWeather();
                        Application.Current.Windows[0].Close();
                        DataAboutWeatherObject.Show();

                    }
                    catch(WebException ex)
                    {
                        HttpWebResponse ErrorRespose = ex.Response as HttpWebResponse;
                        if(ErrorRespose.StatusCode == HttpStatusCode.NotFound)
                        {
                            MessageError MessageErrorObject = new MessageError("Not found");
                            MessageErrorObject.Show();

                        }
                    }
                    DispatherTimerObject.Stop();
                });
            }
        }
    }
