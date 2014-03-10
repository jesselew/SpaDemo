using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpaDemo.Models;
using SpaDemo.Filters;
using System.Web.Http.OData;

namespace SpaDemo.Controllers
{
    public class EventsController : ApiController
    {
        static readonly EventRepository repository = new EventRepository();

        public IEnumerable<Event> Get()
        {
            return repository.GetAll().OrderBy(a => a.Id);
        }

        public Event Get(int id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Event> Get(string category)
        {
            IEnumerable<Event> results = new List<Event>();
            switch (category.ToLower())
            {
                case "":
                case "all":
                    results = repository.GetAll();
                    break;
                case "opening":
                    results = repository.GetAll().Where(e => e.Status == EventStatus.Openning);
                    break;
                case "closed":
                    results = repository.GetAll().Where(e => e.Status == EventStatus.Closed);
                    break;
            }
            results = results.OrderBy(e => e.Id);
            return results;
        }


        [ValidateModel]
        public HttpResponseMessage Post(Event item)
        {
            item.Status = EventStatus.Openning;
            item = repository.Add(item);

            var uri = Url.Link("DefaultApi", new { id = item.Id });
            var response = Request.CreateResponse<Event>(HttpStatusCode.Created, item);
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [HttpPut]
        [ValidateModel]
        public void Put(Event item)
        {
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

       [AcceptVerbs("Patch")]
        public void Patch(int id, Delta<Event> newEvent)
        {
            var oldEvent = repository.Get(id);
            newEvent.Patch(oldEvent);
            repository.Update(oldEvent);
        }

        [Route("api/events/{id}/close")]
        public void Put(int id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            item.Status = EventStatus.Closed;
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}