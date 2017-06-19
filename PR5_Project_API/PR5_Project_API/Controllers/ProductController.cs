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
    public class ProductController : ApiController
    {
        ProductRepository repo;

        public ProductController()
        {
            repo = ProductRepository.GetInstance();
        }

        // GET api/product
        public IEnumerable<Product> Get()
        {
            return repo.GetProducten().Where(o => o.Active==true).ToList();
        }

        // GET api/product/5
        public Product Get(int id)
        {
            return repo.GetProductById(id);
        }

        //public List<Product> Get(string categorie)
        //{
        //    return repo.GetProductByCategorie(categorie);
        //}

        public List<Product> Get(string naam)
        {
            return repo.GetProductByCategorie(naam);
        }

        // POST api/product
        public void Post([FromBody]Product value)
        {
            repo.SaveProduct(value);
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]Product value)
        {
            repo.EditProduct(id, value);
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
            repo.DeactivateProduct(id);

            //Product p = repo.GetProductById(id);
            //p.Active = false;
            //Put(id, p);
        }
    }
}
