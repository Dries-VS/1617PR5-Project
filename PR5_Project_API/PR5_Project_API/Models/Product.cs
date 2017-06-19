using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PR5_Project_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public string Omschrijving { get; set; }
        public string Categorie { get; set; }
        public bool Active { get; set; }
    }
}