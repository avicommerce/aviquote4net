using AviCommerce.AviQuote.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AviCommerce.AviQuote.WebAPI.Controllers
{
    public class AirplanesController : ApiController
    {
        public AirplaneSummaryVm[] Get()
        {
            var airplanes = new[]
            {
                new AirplaneSummaryVm {Identifier = "T6565-900", Name = "Business Jet", Manufacturer = "Boeing", Year = "2006"},
                new AirplaneSummaryVm {Identifier = "T6564-789", Name = "A320", Manufacturer = "Air Bus", Year = "1998"},
                new AirplaneSummaryVm {Identifier = "T6578-817", Name = "A319", Manufacturer = "Air Bus", Year = "2001"}
            };
            return airplanes;
        }

        public AirplaneVm Get(string id)
        {
            return new AirplaneVm
                {
                    Identifier = "T6564-789",
                    Name = "A320",
                    Manufacturer = "Air Bus",
                    Year = "2011"
                };
        }

        public HttpResponseMessage Post(HttpRequestMessage request, AirplaneVm airplane)
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
