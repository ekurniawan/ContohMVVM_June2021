using ContohMVVM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContohMVVM.Services
{
    public class InetCoffeeService : ICoffee
    {
        string baseUrl = "https://coffeebackendservices.azurewebsites.net/";
        private HttpClient _client;

        public InetCoffeeService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public Task AddCoffee(string name, string roaster)
        {
            throw new NotImplementedException();
        }

        public Task EditCoffee(int Id, Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Coffee>> GetCoffee()
        {
            throw new NotImplementedException();
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
