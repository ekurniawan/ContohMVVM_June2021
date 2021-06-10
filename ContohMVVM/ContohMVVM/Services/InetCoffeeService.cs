using ContohMVVM.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContohMVVM.Services
{
    public class InetCoffeeService : ICoffee
    {
        string baseUrl = "https://coffeebackendservices.azurewebsites.net";
        private HttpClient _client;

        public InetCoffeeService()
        {
            _client = new HttpClient();
        }

        public async Task AddCoffee(string name, string roaster)
        {
            Random rnd = new Random();
            var uri = new Uri($"{baseUrl}/api/Coffee");
            try
            {
                var newCoffee = new Coffee
                {
                    Id = rnd.Next(0,10000),
                    Name = name,
                    Roaster = roaster,
                    Image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png"
                };
                var json = JsonConvert.SerializeObject(newCoffee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal menambahkan data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
        }

        public Task EditCoffee(int Id, Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Coffee>> GetCoffee()
        {
            List<Coffee> lstCoffee = new List<Coffee>();
            var uri = new Uri($"{baseUrl}/api/Coffee");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lstCoffee = JsonConvert.DeserializeObject<List<Coffee>>(content);
                }
                return lstCoffee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public Task<Coffee> GetCoffee(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCoffee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
