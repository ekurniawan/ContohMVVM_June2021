using ContohMVVM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContohMVVM.Services
{
    public interface ICoffee
    {
        Task AddCoffee(string name, string roaster);
        Task<IEnumerable<Coffee>> GetCoffee();
        Task<Coffee> GetCoffee(int id);
        Task RemoveCoffee(int id);
        Task EditCoffee(int Id, Coffee coffee);
    }
}
