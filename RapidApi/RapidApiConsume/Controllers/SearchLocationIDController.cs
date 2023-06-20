using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                {
                    List<BookingApiLSViewModel>? model = new List<BookingApiLSViewModel>();

                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                        Headers =
    {
        { "X-RapidAPI-Key", "3cf6f6de6fmsh94c211c79cac3a0p10a668jsn4381219aa2d1" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                    };
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();

                        model = JsonConvert.DeserializeObject<List<BookingApiLSViewModel>>(body);
                        return View(model.Take(1).ToList());
                    }
                }




            }
            else
            {
                {
                    List<BookingApiLSViewModel>? model = new List<BookingApiLSViewModel>();

                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=en-gb"),
                        Headers =
    {
        { "X-RapidAPI-Key", "3cf6f6de6fmsh94c211c79cac3a0p10a668jsn4381219aa2d1" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                    };
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();

                        model = JsonConvert.DeserializeObject<List<BookingApiLSViewModel>>(body);
                        return View(model.Take(1).ToList());
                    }
                }




            }
        }

        
    }
}
