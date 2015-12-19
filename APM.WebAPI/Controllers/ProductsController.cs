using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProductsController : ApiController
    {
        [EnableQuery]
        // GET: api/Products
        public IQueryable<Product> Get()
        {
            var repositiory = new ProductRepository();
            return repositiory.Retrieve().AsQueryable();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            var repositiory = new ProductRepository();

            if (id > 0)
            {
                return repositiory.Retrieve().FirstOrDefault(x => x.ProductId == id);
            }
            else
            {
                return repositiory.Create();
            } 
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            var repositiory = new ProductRepository();
            repositiory.Save(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody] Product product)
        {
            var repositiory = new ProductRepository();
            repositiory.Save(id, product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
