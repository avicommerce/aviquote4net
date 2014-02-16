using AviCommerce.AviQuote.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AviCommerce.AviQuote.WebAPI.Controllers
{
    public class TripsController : ApiController
    {
        public TripSummaryVm[] Get()
        {
            var trips = new[]
            {
                new TripSummaryVm
                    {
                        Identifier = "111-999", 
                        Name = "Dubai-London",
                        Airplane = "111-9890 - JBJ",
                        CreateDate = DateTime.Now, 
                        From = "Dubai International", 
                        EstimatedTakeOff = DateTime.Now.AddDays(2),
                        To = "London Heathrow",
                        IsEditable = true,
                        CompletedDate = DateTime.Now,
                        EstimatedLanding = DateTime.Now.AddDays(6),
                        EstimatedFuelCost = 56000,
                        EstimatedHandlingCost = 4000,
                        EstimatedNavigationFeesCost = 10000,
                        EstimatedAirportFeesCost = 5000,
                        Stops = 1,
                        Legs = 2
                    },
                new TripSummaryVm
                    {
                        Identifier = "111-200", 
                        Name = "Cairo-Beirut",
                        Airplane = "111-2000 - A319",
                        CreateDate = DateTime.Now, 
                        From = "Cairo International", 
                        EstimatedTakeOff = DateTime.Now.AddDays(1),
                        To = "Beirut Rafik Alhareeri",
                        IsEditable = false,
                        CompletedDate = DateTime.Now.AddDays(-2),
                        EstimatedLanding = DateTime.Now.AddDays(1),
                        EstimatedFuelCost = 8000,
                        EstimatedHandlingCost = 1000,
                        EstimatedNavigationFeesCost = 2000,
                        EstimatedAirportFeesCost = 500,
                        Stops = 0,
                        Legs = 1
                    }
            };

            return trips;
        }

        public TripVm Get(string id)
        {
            var trip = new TripVm
            {
                Identifier = "111-999",
                Name = "Dubai-London",
                Airplane = "111-9890 - JBJ",
                CreateDate = DateTime.Now,
                From = "Dubai International",
                EstimatedTakeOff = DateTime.Now.AddDays(2),
                To = "London Heathrow",
                
                IsEditable = true,
                CompletedDate = DateTime.Now,

                EstimatedLanding = DateTime.Now.AddDays(4),
                EstimatedFuelCost = 56000,
                EstimatedHandlingCost = 4000,
                EstimatedNavigationFeesCost = 10000,
                EstimatedAirportFeesCost = 5000,

                Legs = new List<TripLegVm>()
                    {
                        new TripLegVm
                            {
                                Identifier = "5556-1000",
                                TripIdentifier = "111-999",
                                From = "Dubai International",
                                EstimatedTakeOff = DateTime.Now.AddDays(2),
                                To = "Istanbul Intenational",
                                EstimatedLanding = DateTime.Now.AddDays(2),
                                EstimatedFuelCost = 30000,
                                EstimatedHandlingCost = 10000,
                                EstimatedNavigationFeesCost = 5000,
                                NavigationFees = new List<NavigationFee>()
                                    {
                                        new NavigationFee
                                            {
                                                Type = "Air Point",
                                                Country =  "Saudi Arabia",
                                                Fee = 2200
                                            },
                                        new NavigationFee
                                            {
                                                Type = "Air Point",
                                                Country =  "Cypress",
                                                Fee = 2200
                                            }
                                    }
                            },
                        new TripLegVm
                            {
                                Identifier = "5556-1001",
                                TripIdentifier = "111-999",
                                From = "Istanbul Intenational",
                                EstimatedTakeOff = DateTime.Now.AddDays(6),
                                To = "London Heathrow",
                                EstimatedLanding = DateTime.Now.AddDays(6),
                                EstimatedFuelCost = 30000,
                                EstimatedHandlingCost = 10000,
                                EstimatedNavigationFeesCost = 5000,
                                NavigationFees = new List<NavigationFee>()
                                    {
                                        new NavigationFee
                                            {
                                                Type = "Air Point",
                                                Country =  "Poland",
                                                Fee = 2200
                                            },
                                        new NavigationFee
                                            {
                                                Type = "Air Point",
                                                Country =  "France",
                                                Fee = 2200
                                            }
                                    }
                            }                    
                    },
                Stops = new List<TripStopVm>()
                    {
                        new TripStopVm
                            {
                                Identifier = "5556-1000",
                                TripIdentifier = "111-999",
                                Destination = "Dubai",
                                Stop = "Dubai International",
                                EstimatedTakeOff = DateTime.Now.AddDays(2),
                                EstimatedLanding = DateTime.Now,
                                IsOrigin = true,
                                IsDestination = false,
                                IsTechnical = false,
                                Order = 1,
                                EstimatedFuelCost = 30000,
                                EstimatedHandlingCost = 10000,
                                EstimatedAirportFeesCost = 5000,
                                FuelGallons = 500,
                                FuelPricePerGallon = 3.66,
                                FuelSupplier = "Jetex",
                                IsFuelOrdered = true,
                                FuelOrderedDate = DateTime.Now.AddDays(-2),
                                Handler = "Danata",
                                IsHandlingOrdered = false,
                                HandlingOrderedDate = DateTime.Now,
                                AirportFees = new List<AirportFee>()
                                    {
                                        new AirportFee
                                            {
                                                Type = "Parking",
                                                Fee = 2200
                                            },
                                        new AirportFee
                                            {
                                                Type = "Tax",
                                                Fee = 2200
                                            }
                                    }
                            },
                        new TripStopVm
                            {
                                Identifier = "5556-1001",
                                TripIdentifier = "111-999",
                                Destination = "Istanbul",
                                Stop = "Istanbul International",
                                EstimatedTakeOff = DateTime.Now.AddDays(4),
                                EstimatedLanding = DateTime.Now.AddDays(2),
                                IsOrigin = true,
                                IsDestination = true,
                                IsTechnical = true,
                                Order = 2,
                                EstimatedFuelCost = 30000,
                                EstimatedHandlingCost = 10000,
                                EstimatedAirportFeesCost = 5000,
                                FuelGallons = 500,
                                FuelPricePerGallon = 3.66,
                                FuelSupplier = "Jetex",
                                IsFuelOrdered = true,
                                FuelOrderedDate = DateTime.Now.AddDays(-2),
                                Handler = "Zua",
                                IsHandlingOrdered = false,
                                HandlingOrderedDate = DateTime.Now,
                                AirportFees = new List<AirportFee>()
                                    {
                                        new AirportFee
                                            {
                                                Type = "Parking",
                                                Fee = 2200
                                            },
                                        new AirportFee
                                            {
                                                Type = "Tax",
                                                Fee = 2200
                                            }
                                    }
                            },                    
                       new TripStopVm
                            {
                                Identifier = "5556-1002",
                                TripIdentifier = "111-999",
                                Destination = "London",
                                Stop = "London Heathrow",
                                EstimatedTakeOff = DateTime.Now,
                                EstimatedLanding = DateTime.Now.AddDays(6),
                                IsOrigin = false,
                                IsDestination = true,
                                IsTechnical = false,
                                Order = 3,
                                EstimatedFuelCost = 30000,
                                EstimatedHandlingCost = 10000,
                                EstimatedAirportFeesCost = 5000,
                                FuelGallons = 500,
                                FuelPricePerGallon = 3.66,
                                FuelSupplier = "Jetex",
                                IsFuelOrdered = false,
                                FuelOrderedDate = DateTime.Now,
                                Handler = "British Something",
                                IsHandlingOrdered = false,
                                HandlingOrderedDate = DateTime.Now,
                                AirportFees = new List<AirportFee>()
                                    {
                                        new AirportFee
                                            {
                                                Type = "Parking",
                                                Fee = 2200
                                            },
                                        new AirportFee
                                            {
                                                Type = "Tax",
                                                Fee = 2200
                                            }
                                    }
                            }                    
                     }
            };

            return trip;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, TripSummaryVm trip)
        {
            if (ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        //**** PRIVATE METHODS ****//
        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
        }
    }
}
