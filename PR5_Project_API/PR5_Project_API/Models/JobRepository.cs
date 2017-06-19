using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PR5_Project_API.Models
{
    public class JobRepository
    {
        private List<Job> Jobs;

        private static JobRepository instance;

        public static JobRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new JobRepository();
            }
            return instance;
        }

        public JobRepository()
        {
            Jobs = new List<Job>();
        }

        public List<Job> GetJobs()
        {
            return Jobs;
        }

        public Job GetJobById(int id)
        {
            //get tuinen from db
            return Jobs.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Job> GetJobsByTuinId(int id)
        {
            return Jobs.Where(o => o.Tuin.Id == id).ToList();
        }

        public void SaveJob(Job t)
        {
            Jobs.Add(t);
        }

        public void EditJob(int id, Job t)
        {
            Jobs.Remove(Jobs.Where(o => o.Id == id).FirstOrDefault());
            Jobs.Add(t);
        }

        public void DeactivateJob(int id)
        {
            Jobs.Where(o => o.Id == id).SingleOrDefault().Active = false;
        }

        public void ActivateJob(int id)
        {
            Jobs.Where(o => o.Id == id).SingleOrDefault().Active = true;
        }

    }
}