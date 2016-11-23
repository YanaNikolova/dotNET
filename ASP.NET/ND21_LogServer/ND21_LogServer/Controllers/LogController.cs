using ND21_LogServer.Models.Events;
using ND21_LogServer.Models.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ND21_LogServer.Controllers
{
    public class LogController : ApiController
    {
        ILogServices logServices;

        public LogController(ILogServices logServices)
        {
            this.logServices = logServices;
        }
        /// GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok("Ok");
        }

        // POST api/<controller>
        public IHttpActionResult Post(EventWrapper eventWrapper)
        {
            List<Event> eventsList = new List<Event>();
            foreach (var ev in eventWrapper.Events)
            {
                eventsList.Add(new Event
                {
                    Id = ev.Id,
                    Date = ev.Date,
                    Type = ev.Type,
                    Message = ev.Message,
                    ApiKey = eventWrapper.APIKey
                });
            }
            return logServices.AppendEvent(eventsList) ? (IHttpActionResult)Ok() : (IHttpActionResult)BadRequest();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}