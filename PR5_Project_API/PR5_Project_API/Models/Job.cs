using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PR5_Project_API.Models
{
    public class Job
    {

        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double Prijs { get; set; }
        public Tuin Tuin { get; set; }
        public List<Product> Producten { get; set; }
        public bool Active { get; set; }

    }
}