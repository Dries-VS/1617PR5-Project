using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PR5_Project_API.Models
{
    public class ProductRepository
    {

        private List<Product> Producten;

        private static ProductRepository instance;

        public static ProductRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductRepository();
            }

            return instance;
        }

        public ProductRepository()
        {
            Producten = new List<Product>();
        }

        public List<Product> GetProducten()
        {
            return Producten;
        }

        public Product GetProductById(int id)
        {
            //get products from db
            return Producten.Where(o => o.Id == id).FirstOrDefault();
        }

        public Product GetProductByNaam(string naam)
        {
            return Producten.Where(o => o.Naam.ToLower().Equals(naam.ToLower())).FirstOrDefault();
        }

        public List<Product> GetProductByCategorie(string s)
        {
            return Producten.Where(o => o.Categorie.ToLower().Equals(s.ToLower())).ToList();
        }

        public void SaveProduct(Product t)
        {
            if (t.Id == 0 && Producten.Count > 0)
            {
                t.Id = Producten.Max(o => o.Id) + 1;
            }
            Producten.Add(t);
        }

        public void EditProduct(int id, Product t)
        {
            Producten.Remove(Producten.Where(o => o.Id == id).FirstOrDefault());
            Producten.Add(t);
        }

        public void DeactivateProduct(int id)
        {
            Producten.Where(o => o.Id == id).SingleOrDefault().Active = false;
        }

        public void ActivateProduct(int id)
        {
            Producten.Where(o => o.Id == id).SingleOrDefault().Active = true;
        }

    }
}