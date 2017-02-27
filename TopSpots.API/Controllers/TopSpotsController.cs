using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TopSpots.API.Models;


namespace TopSpots.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TopSpotsController : ApiController
    {
        // GET: api/TopSpots
        public IEnumerable<TopSpot> Get()
        {
            string json = File.ReadAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json");
            var output = JsonConvert.DeserializeObject<List<TopSpot>>(json);
            return output;
        }


        // GET: api/TopSpots/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TopSpots
        public TopSpot Post(TopSpot spot)
        {
            string json = File.ReadAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json");
            var output = JsonConvert.DeserializeObject<List<TopSpot>>(json);

            output.Add(spot);

            string newSpot = Newtonsoft.Json.JsonConvert.SerializeObject(output);
            File.WriteAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json", newSpot);

            return spot;
        }


        // PUT: api/TopSpots/5
        [HttpPut]
        public HttpResponseMessage Put(int id, TopSpot spot)
        {
            string json = File.ReadAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json");
            var output = JsonConvert.DeserializeObject<List<TopSpot>>(json);

            if(spot.Name != null)
            {
                output[id].Name = spot.Name;
            }

            if(spot.Description != null)
            {
                output[id].Description = spot.Description;
            }

            if (spot.Location != null)
            {
                output[id].Location[0] = spot.Location[0];
                output[id].Location[1] = spot.Location[1];
            }

            string newSpot = Newtonsoft.Json.JsonConvert.SerializeObject(output);
            File.WriteAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json", newSpot);

            return Request.CreateResponse(HttpStatusCode.OK,
            new
            {
                value = spot,
                message = "success!"
            });

        }

        
        // DELETE: api/TopSpots/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            string json = File.ReadAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json");
            var output = JsonConvert.DeserializeObject<List<TopSpot>>(json);

            output.RemoveAt(id);

            string spots = Newtonsoft.Json.JsonConvert.SerializeObject(output);
            File.WriteAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json", spots);

            return Request.CreateResponse(HttpStatusCode.OK,
            new
            {
                message = "success!"
            });

        }
    }
}