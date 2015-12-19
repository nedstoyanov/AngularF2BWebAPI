using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;
using Microsoft.Ajax.Utilities;

namespace APM.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProductsController : ApiController
    {
        [EnableQuery]
        [ResponseType(typeof(Product))]
        // GET: api/Products
        public  IHttpActionResult Get()
        {
            try
            {
                var repositiory = new ProductRepository();
                return Ok(repositiory.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ResponseType(typeof(Product))]
        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var repositiory = new ProductRepository();

                Product product = null;

                if (id > 0)
                {
                    product = repositiory.Retrieve().FirstOrDefault(x => x.ProductId == id);

                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = repositiory.Create();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }           
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {            
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var repositiory = new ProductRepository();
                var newProduct = repositiory.Save(product);

                if (newProduct == null)
                {
                    return Conflict();
                }

                return Created(Request.RequestUri + newProduct.ProductId.ToString(), newProduct);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var repositiory = new ProductRepository();
                var updateProduct = repositiory.Save(id, product);

                if (updateProduct == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }            
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
