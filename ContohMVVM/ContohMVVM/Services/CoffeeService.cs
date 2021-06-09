using ContohMVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ContohMVVM.Services
{
    public static class CoffeeService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Coffee>();
        }

        public static async Task AddCoffee(string name,string roaster)
        {
            await Init();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            var newCoffee = new Coffee
            {
                Name = name,
                Roaster = roaster,
                Image = image
            };

            var id = await db.InsertAsync(newCoffee);
        }

        public static async Task RemoveCoffee(int id)
        {
            await Init();
            await db.DeleteAsync<Coffee>(id);
        }

        public static async Task UpdateCoffee(Coffee coffee)
        {
            await Init();
            await db.UpdateAsync(coffee);
        }

        public static async Task<IEnumerable<Coffee>> GetCoffee()
        {
            await Init();
            var results = await db.Table<Coffee>().ToListAsync();
            return results;
        }

        public static async Task<Coffee> GetCoffeeById(int id)
        {
            await Init();
            var result = await db.Table<Coffee>().Where(c => c.Id == id).FirstOrDefaultAsync();
            return result;
        }
    }
}
