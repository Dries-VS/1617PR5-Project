using PR5_Project_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PR5_Project_API.Controllers
{

    [EnableCors(origins: "http://127.0.0.1:57346", headers: "*", methods: "*")]
    public class TuinController : ApiController
    {
        TuinRepository repo;

        public TuinController()
        {
            repo = TuinRepository.GetInstance();
        }

        // GET api/tuin
        public IEnumerable<Tuin> Get()
        {
            return repo.GetTuinen().Where(x => x.Active == true).ToList();
        }

        // GET api/tuin/5
        public Tuin Get(int id)
        {
            return repo.GetTuinById(id);
        }

        public Tuin Get(string adres, string nummer)
        {
            return repo.GetTuinByAdres(adres, nummer);
        }

        // POST api/tuin
        public void Post([FromBody]Tuin value)
        {
            repo.SaveTuin(value);
        }

        // PUT api/tuin/5
        public void Put(int id, [FromBody]Tuin value)
        {
            repo.EditTuin(id, value);
        }

        // DELETE api/tuin/5
        public void Delete(int id)
        {
            repo.DeactivateTuin(id);

            //Tuin t = repo.GetTuinById(id);
            //t.Active = false;
            //Put(id, t);
        }
    }
}
