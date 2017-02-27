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
            
        }

        // PUT: api/TopSpots/5
        public void Put(int id, TopSpot spot)
        {
           


        }

        // DELETE: api/TopSpots/5
        public void Delete(int id, TopSpot spot)
        {
            



        }
    }
}