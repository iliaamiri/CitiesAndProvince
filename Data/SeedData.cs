using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitiesAndProvince.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesAndProvince.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                GetProvinces()
            );
            modelBuilder.Entity<City>().HasData(
                GetCities()  
            );
        }

        public static List<City> GetCities()
        {
            List<City> cities = new List<City> {
                new City {
                    CityId = 1,
                    CityName = "Vancouver",
                    ProvinceCode = "BC",
                },
                new City {
                    CityId = 2,
                    CityName = "Richmond",
                    ProvinceCode = "BC",
                },
                new City {
                    CityId = 3,
                    CityName = "Toronto",
                    ProvinceCode = "ON",
                },
                new City {
                    CityId = 4,
                    CityName = "Calgary",
                    ProvinceCode = "AB",
                }
            };

            return cities;
        }

        public static List<Province> GetProvinces()
        {
            List<Province> provinces = new List<Province>() {
                new Province {
                    ProvinceCode = "BC",
                    ProvinceName = "British Columbia",
                },
                new Province {
                    ProvinceCode = "ON",
                    ProvinceName = "Ontario",
                },
                new Province {
                    ProvinceCode = "AB",
                    ProvinceName = "Alberta",
                }
            };

            return provinces;
        }
    }
}