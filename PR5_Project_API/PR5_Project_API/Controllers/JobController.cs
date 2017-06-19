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
    public class JobController : ApiController
    {
        JobRepository repo;

        public JobController()
        {
            repo = JobRepository.GetInstance();
        }

        // GET api/<controller
        public IEnumerable<Job> Get()
        {
            return repo.GetJobs().ToList();
        }

        // GET api/values/5
        //public Job Get(int id)
        //{
        //    return repo.GetJobById(id);
        //}

        public List<Job> Get(int id)
        {
            return repo.GetJobsByTuinId(id);
        }

        // POST api/values
        public void Post([FromBody]Job value)
        {
            repo.SaveJob(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Job value)
        {
            repo.EditJob(id, value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            repo.DeactivateJob(id);
        }
    }
}
