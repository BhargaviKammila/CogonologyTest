using AttributeRouting;
using AttributeRouting.Web.Mvc;
using BusinessContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{    
    [RoutePrefix("api/AcmeFlight")]
    public class AcmeFlightController : ApiController
    {
        [HttpPost]
        [Route("CheckAvailability")]
        public DataOutput CheckAvailability(DataInput data)
        {
            try
            {
                if (string.IsNullOrEmpty(data.StartDate))
                {
                    return new DataOutput
                    {
                        Error = "Start Date cannot be empty!"
                    };
                }
                if (string.IsNullOrEmpty(data.EndDate))
                {
                    return new DataOutput
                    {
                        Error = "End Date cannot be empty!"
                    };
                }
                if (string.IsNullOrEmpty(data.Pax))
                {
                    return new DataOutput
                    {
                        Error = "No.of passengers cannot be empty!"
                    };
                }

                DataInput res = FillDataStore.AcmeFlights.Find(d => (d.EndDate == data.EndDate && d.StartDate == data.StartDate && d.Pax == data.Pax));
                if(res != null)
                {
                    return new DataOutput
                    {
                        Output = res.Name
                    };
                }


                return new DataOutput{
                    Error = "Provided details are not valid or no flights available with the requested dates and No.of Pax"
                };                
            }
            catch (Exception ex)
            {
                return new DataOutput
                {
                    Error = string.Format("Some error occurred while checking the availability", ex.Message)
                };
            }            
        }
    }
}
