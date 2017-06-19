using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PR5_Project_API.Models
{
    public class TuinRepository
    {
        private List<Tuin> Tuinen;

        private static TuinRepository instance;

        public static TuinRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new TuinRepository();
            }
            return instance;
        }

        public TuinRepository()
        {
            Tuinen = new List<Tuin>();
        }

        public List<Tuin> GetTuinen()
        {
            return Tuinen;
        }

        public Tuin GetTuinById(int id)
        {
            //get tuinen from db
            return Tuinen.Where(o => o.Id == id).FirstOrDefault();
        }

        public Tuin GetTuinByAdres(string s, string n)
        {
            return Tuinen.Where(o => o.Nummer.Equals(n) || o.Straat.Equals(s)).FirstOrDefault();
        }

        public List<Tuin> GetTuinenByStraat(string s)
        {
            return Tuinen.Where(o => o.Straat.Equals(s)).ToList();
        }

        public List<Tuin> GetTuinenByStad(string s)
        {
            return Tuinen.Where(o => o.Stad.Equals(s)).ToList();
        }

        public void SaveTuin(Tuin t)
        {
            if (t.Id == 0 && Tuinen.Count > 0)
            {
                t.Id = Tuinen.Max(o => o.Id) + 1;
            }
            Tuinen.Add(t);
        }

        public void EditTuin(int id, Tuin t)
        {
            Tuinen.Remove(Tuinen.Where(o => o.Id == id).FirstOrDefault());
            Tuinen.Add(t);
        }

        public void DeactivateTuin(int id)
        {
            Tuinen.Where(o => o.Id == id).SingleOrDefault().Active = false;
        }

        public void ActivateTuin(int id)
        {
            Tuinen.Where(o => o.Id == id).SingleOrDefault().Active = true;
        }

    }
}