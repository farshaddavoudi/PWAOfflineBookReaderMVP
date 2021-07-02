using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DnetIndexedDb;
using DnetIndexedDb.Fluent;
using DnetIndexedDb.Models;
using TestOfflineBookReader.Client.IndexedDB;
using TestOfflineBookReader.Shared;

namespace TestOfflineBookReader.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddIndexedDbDatabase<ForecastDataIndexedDb>(options =>
            {
                var model = new IndexedDbDatabaseModel()
                    .WithName("OfflineBookReaderDb")
                    .WithVersion(1)
                    .WithModelId(0);

                model.AddStore(nameof(WeatherForecast))
                    .WithAutoIncrementingKey(nameof(WeatherForecast.Id))
                    //.AddUniqueIndex("tableFieldId")
                    .AddIndex(nameof(WeatherForecast.TemperatureC));

                options.UseDatabase(model);
            });
            
            builder.Services.AddIndexedDbDatabase<BookDataIndexedDb>(options =>
            {
                var model = new IndexedDbDatabaseModel()
                    .WithName("BooksDb")
                    .WithVersion(1)
                    .WithModelId(1);

                model.AddStore(nameof(Book))
                    .WithKey(nameof(Book.Id))
                    //.WithKey(nameof(Book.Id))
                    //.AddUniqueIndex("tableFieldId")
                    .AddIndex(nameof(Book.Name));

                model.AddStore(nameof(BookFile))
                .WithKey(nameof(BookFile.Id))
                .AddUniqueIndex(nameof(BookFile.BookId));

                options.UseDatabase(model);
            });

            await builder.Build().RunAsync();
        }
    }
}
