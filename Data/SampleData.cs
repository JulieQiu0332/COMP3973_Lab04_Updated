using Lab04.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Data
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Look for any teams.
                if (context.Provinces.Any())
                {
                    return;   // DB has already been seeded
                }

                var provinces = GetProvinces().ToArray();
                context.Provinces.AddRange(provinces);
                context.SaveChanges();

                var cities = GetCities(context).ToArray();
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }
        }

        public static List<Province> GetProvinces()
        {
            List<Province> provinces = new List<Province>() {
            new Province() {
                ProvinceCode ="BC",
                ProvinceName ="British Columbia",
                
            },
             new Province() {
                ProvinceCode ="AB",
                ProvinceName ="Alberta",

            },
             new Province() {
                ProvinceCode ="MB",
                ProvinceName ="Manitoba",

            },
     
           
            new Province() {
                ProvinceCode ="NB",
                ProvinceName ="New Brunswick",
            },
        };

            return provinces;
        }

        public static List<City> GetCities(ApplicationDbContext context)
        {
            List<City> cities = new List<City>() {
            new City {
 
                CityName = "Victoria",
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                Population = 385999
            },
            
            new City {

                CityName = "Burnaby",
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                Population = 256276
            },
            new City {

                CityName = "Yellowknifw",
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
                Population = 20234
            },
            
        };

            return cities;
        }

    }
}
