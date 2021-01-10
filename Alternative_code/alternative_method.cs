using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
//using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Customers(string country)
        {
            string uri;

            if (string.IsNullOrEmpty(country))
            {
                ViewData["Title"] = "All Customers Worldwide";
                uri = "api/customers/";
            }
            else
            {
                ViewData["Title"] = $"Customers in {country}";
                uri = $"api/customers/?country={country}";
            }

            List<Customer> model = db.Customers
            .AsEnumerable() // switch to client-side
            .Where(p => p.Country == country).ToList();
            if (model.Count() == 0)
            {
                return NotFound($"No Customers in {country}.");
            }
            //var client = clientFactory.CreateClient(name: "NorthwindService");

            //var request = new HttpRequestMessage(
            //  method: HttpMethod.Get, requestUri: uri);

            //HttpResponseMessage response = await client.SendAsync(request);

            //string jsonString = await response.Content.ReadAsStringAsync();

            //IEnumerable<Customer> model = JsonConvert
            //  .DeserializeObject<IEnumerable<Customer>>(jsonString);

            return View(model);
        }
    }
}