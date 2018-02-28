using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WillClinic.Components
{
    public class LocalMap : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Task<string> task = GetMapAsync();

            task.Wait();

            string jsonresult = task.Result;

            return View(jsonresult);
        }

        public async Task<string> GetMapAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://maps.googleapis.com/maps");

                var response = await client.GetAsync($"/api/js?key=AIzaSyAkgGykt4WkdZWuG_3DWf-0Rwq0I0D5a1w&callback=initMap");

                response.EnsureSuccessStatusCode();

                string stringResult = await response.Content.ReadAsStringAsync();

                return stringResult;
            }
        }
    }
}
