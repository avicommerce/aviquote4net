using AviCommerce.AviQuote.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AviCommerce.AviQuote.WebAPI.Controllers
{
    public class DestinationsController : ApiController
    {
        public DestinationSummaryVm[] Get()
        {
            var destinations = new[]
            {
                new DestinationSummaryVm
                    {
                        City = "Dubai", 
                        Country = "United Arab Emirates", 
                        Longitude = 55.9878, 
                        Latitude = 23.8765, 
                        Airports = 2,
                        Hospitals = 13,
                        Restaurants = 45
                    },
                new DestinationSummaryVm
                    {
                        City = "Abou Dhabi", 
                        Country = "United Arab Emirates", 
                        Longitude = 55.9878, 
                        Latitude = 23.8765, 
                        Airports = 2,
                        Hospitals = 9,
                        Restaurants = 23
                    },
                new DestinationSummaryVm
                    {
                        City = "Doha", 
                        Country = "Qatar", 
                        Longitude = 55.9878, 
                        Latitude = 23.8765, 
                        Airports = 1,
                        Hospitals = 7,
                        Restaurants = 12
                    },
                new DestinationSummaryVm
                    {
                        City = "Amman", 
                        Country = "Jordan", 
                        Longitude = 55.9878, 
                        Latitude = 23.8765, 
                        Airports = 1,
                        Hospitals = 9,
                        Restaurants = 23
                    },
                new DestinationSummaryVm
                    {
                        City = "Cairo", 
                        Country = "Egypt", 
                        Longitude = 55.9878, 
                        Latitude = 23.8765, 
                        Airports = 2,
                        Hospitals = 7,
                        Restaurants = 7
                    }
            };

            return destinations;
        }

        public DestinationVm Get(string id)
        {
            var destination = new DestinationVm
            {
                City = "Dubai",
                Country = "United Arab Emirates",
                Longitude = 55.9878,
                Latitude = 23.8765,
                VisaRequirement = "Blab Blah",
                Climate = "November to March is beautiful!! Otherwise it is hot and humid.",

                Airports = new List<AirportVm>()
                    {
                        new AirportVm
                            {
                                IataSymbol = "DXB",
                                IcoaSymbol = "DXB1",
                                Name = "Dubai International",
                                Longitude = 55.9878,
                                Latitude = 23.8765,
                                FuelSuppliers = new List<FuelSupplierVm>()
                                    {
                                        new FuelSupplierVm
                                            {
                                                Name = "Jetex",
                                                YearEstablished =  "2001",
                                                AveragePrice = 4.32,
                                                LatestPrice = 4.10
                                            },
                                        new FuelSupplierVm
                                            {
                                                Name = "Hadeed",
                                                YearEstablished =  "1979",
                                                AveragePrice = 4.34,                                                
                                                LatestPrice = 4.09
                                            }
                                    },
                                Handlers = new List<AircraftHandlerVm>()
                                    {
                                        new AircraftHandlerVm
                                            {
                                                Name = "Dnata",
                                                Year =  "1967"
                                            },
                                        new AircraftHandlerVm
                                            {
                                                Name = "Someone else",
                                                Year =  "2001"
                                            }
                                    },
                                Fees = new List<AirportFeeVm>()
                                    {
                                        new AirportFeeVm
                                            {
                                                Name = "Parking",
                                                Terms = "Blah blah",
                                                Fee =  100
                                            },
                                        new AirportFeeVm
                                            {
                                                Name = "Lighting",
                                                Terms = "Blah blah",
                                                Fee =  88
                                            }
                                    }
                            },
                        new AirportVm
                            {
                                IataSymbol = "WCD",
                                IcoaSymbol = "WCD1",
                                Name = "Dubai World Central",
                                Longitude = 55.9878,
                                Latitude = 23.8765,
                            }
                    },
                Hospitals = new List<HospitalVm>()
                    {
                        new HospitalVm
                            {
                                Name = "Well Care Hospital",
                                Address = "1990 Airport Rd, Dubai",
                                City = "Dubai",
                                Phone = "04.455.8989",
                                Email = "info@wellcare.com",
                                Specialties = "All"
                            },
                        new HospitalVm
                            {
                                Name = "Zahra Hospital",
                                Address = "1990 Zahra Rd",
                                City = "Dubai",
                                Phone = "04.515.7000",
                                Email = "info@zahra-hospital.com",
                                Specialties = "All"
                            }
                    },
                Restaurants = new List<RestaurantVm>()
                    {
                        new RestaurantVm
                            {
                                Name = "Hallab",
                                Description = "Blah Blah",
                                Address = "565 Rue de something",
                                Cuisine = "Lebanese",
                                Attire = "Casual",
                                OperatingHours = "11:00 AM - 1:00 AM Daily",
                                AverageMealCost = "40 DHS"
                            },
                        new RestaurantVm
                            {
                                Name = "Safadi",
                                Description = "Blah Blah",
                                Address = "700 Rue de something",
                                Cuisine = "Lebanese",
                                Attire = "Casual",
                                OperatingHours = "11:00 AM - 1:00 AM Daily",
                                AverageMealCost = "35 DHS"
                            }
                    },
                WeatherPreviousDays = new List<WeatherForecast>
                    {
                        new WeatherForecast
                            {
                                Day = "Monday",
                                Date = "17 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            },
                        new WeatherForecast
                            {
                                Day = "Tuesday",
                                Date = "18 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            },
                        new WeatherForecast
                            {
                                Day = "Wednesday",
                                Date = "19 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            },
                        new WeatherForecast
                            {
                                Day = "Thursday",
                                Date = "20 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            },
                        new WeatherForecast
                            {
                                Day = "Friday",
                                Date = "21 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            }
                    },
                WeatherForwardDays = new List<WeatherForecast>
                    {
                        new WeatherForecast
                            {
                                Day = "Saturday",
                                Date = "22 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            },
                        new WeatherForecast
                            {
                                Day = "Sunday",
                                Date = "23 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            },
                        new WeatherForecast
                            {
                                Day = "Monday",
                                Date = "24 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            },
                        new WeatherForecast
                            {
                                Day = "Tuesday",
                                Date = "25 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            },
                        new WeatherForecast
                            {
                                Day = "Wednesday",
                                Date = "26 Feb 2014",
                                High = 23,
                                Low = 12,
                                Wind = 4,
                                Rain = 3
                            }
                    }
            };

            return destination;
        }
    }
}
