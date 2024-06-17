using Microsoft.AspNetCore.Mvc;
using UnoSquare.Models.ViewModels;
using UnoSquare.BusinessLogicLayer.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnoSquare_WebApp.Server.Controllers
{
    [SwaggerTag("Products Endpoint")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET: api/<ProductsController>
        /// <summary>
        ///     Get List of Products Filtered
        /// </summary>
        /// <remarks>
        ///     Method to retreive the List of Products filtered by sepecific fields
        /// </remarks>
        /// <response code="200">Json Data with the result of the query and the product list that meets the filters entered</response>
        [HttpGet]
        public ActionResult Get()
        {
            var productList = _productsService.GetProductsListFiltered();
            return new JsonResult(new { ok = true, data = productList });
        }

        // GET api/<ProductsController>/5
        /// <summary>
        ///     Get Product By ID
        /// </summary>
        /// <remarks>
        ///     Method to search for a specific product using his ID
        /// </remarks>
        /// <param name="id">The ID of the product to retrieve</param>
        /// <response code="200">Json Data with the result of the query and the product found itself</response>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _productsService.GetProduct(id);
            return new JsonResult(new { ok = result != null, data = result });
        }

        // POST api/<ProductsController>
        /// <summary>
        ///     Add new Product
        /// </summary>
        /// <remarks>
        ///     Method to Add a product to the Database
        /// </remarks>
        /// <param name="newProduct">The product object to be added</param>
        /// <response code="200">Json Data with the results of the "Add Product" function</response>
        [HttpPost]
        public ActionResult Post([FromBody] ProductView newProduct)
        {
            var result = _productsService.AddNewProduct(newProduct);
            return new JsonResult(new { ok = !result.ErrorFlag, data = result });
        }

        // PUT api/<ProductsController>/5
        /// <summary>
        ///     Update Product
        /// </summary>
        /// <remarks>
        ///     Method to Update an Existing product of the Database
        /// </remarks>
        /// <param name="updProduct">The product object to be updated</param>
        /// <response code="200">Json Data with the results of the "Update Product" function</response>
        [HttpPut()]
        public ActionResult Put([FromBody] ProductView updProduct)
        {
            var result = _productsService.UpdateProduct(updProduct);
            return new JsonResult(new { ok = !result.ErrorFlag, data = result });
        }

        // DELETE api/<ProductsController>/5
        /// <summary>
        ///     Delete Product
        /// </summary>
        /// <remarks>
        ///     Method to Delete a product of the Database
        /// </remarks>
        /// <param name="id">The Product ID to be Deleted</param>
        /// <response code="200">Json Data with the results of the "Delete Product" function</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _productsService.DeleteProduct(id);
            return new JsonResult(new { ok = !result.ErrorFlag, data = result });
        }
    }
}
