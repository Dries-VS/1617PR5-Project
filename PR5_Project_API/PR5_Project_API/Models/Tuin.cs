using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PR5_Project_API.Models
{
    public class Tuin
    {

        public int Id { get; set; }
        public string Straat { get; set; }
        public string Nummer { get; set; }
        public string Naam { get; set; }
        public string Stad { get; set; }
        public bool Active { get; set; }

        public bool Equals(Tuin t)
        {
            if (Id == t.Id && Straat.Equals(t.Straat) && Nummer.Equals(t.Nummer) && Naam.Equals(t.Naam) && Stad.Equals(t.Stad))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}