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
    [EnableCors("http://localhost:8080", "*", "*")]
    
    public class TopSpotsController : ApiController
    {
        // GET: api/TopSpots
        [HttpGet]
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
        [HttpPost]
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
        public HttpResponseMessage Put(int id, [FromBody] TopSpot spot)
        {
            string json = File.ReadAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json");
            var update = JsonConvert.DeserializeObject<List<TopSpot>>(json);

            if(spot.Name != null)
            {
                update[id].Name = spot.Name;
            }

            if(spot.Description != null)
            {
                update[id].Description = spot.Description;
            }

            if (spot.Location != null)
            {
                update[id].Location[0] = spot.Location[0];
                update[id].Location[1] = spot.Location[1];
            }

            string updatedSpot = Newtonsoft.Json.JsonConvert.SerializeObject(update);
            File.WriteAllText("C:/Users/cherr/dev/TopSpots/TopSpots.API/TopSpots.API/topspots.json", updatedSpot);

            return Request.CreateResponse(HttpStatusCode.OK,
            new
            {
                value = spot,
                message = "Success! You've updated a spot!"
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
                message = "Success! You've deleted a spot!"
            });

        }
    }
}