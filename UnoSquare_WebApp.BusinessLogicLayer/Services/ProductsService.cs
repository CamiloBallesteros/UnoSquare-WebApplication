using Microsoft.Data.SqlClient;
using UnoSquare.BusinessLogicLayer.Helpers;
using UnoSquare.BusinessLogicLayer.Interfaces;
using UnoSquare.DataLayer.Data;
using UnoSquare.DataLayer.Tables;
using UnoSquare.Models.ResponseModels;
using UnoSquare.Models.ViewModels;

namespace UnoSquare.BusinessLogicLayer.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;
        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Add_DeleteResponse AddNewProduct(ProductView newProduct)
        {
            var result = new Add_DeleteResponse();
            Product addedNewProduct = new Product().Map(newProduct);
            try
            {
                _context.Products.Add(addedNewProduct);
                _context.SaveChanges();
                result.IdChanged = addedNewProduct.Id;
                result.SuccessMessage = "Product Successfully created!";
            }
            catch (SqlException ex)
            {
                result.ErrorFlag = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Add_DeleteResponse DeleteProduct(int idDelete)
        {
            var result = new Add_DeleteResponse();
            try
            {
                _context.Remove(_context.Products.Single(x => x.Id == idDelete));
                var res = _context.SaveChanges();
                result.IdChanged = idDelete;
                result.SuccessMessage = "Product Successfully deleted!";
            }
            catch (SqlException ex)
            {
                result.ErrorFlag = true;
                if (ex.Message.Contains("PRIMARY KEY constraint 'PK_Products'."))
                    result.ErrorMessage = "The Product entered does not exist in the Database.";
                else
                    result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public ProductView? GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            ProductView response = new();
            return product != null ? response.Map(product) : null ;
        }

        public List<ProductView> GetProductsListFiltered(string? name = null, string? description = null, (decimal, decimal)? priceRank = null)
        {
            var productList = new List<ProductView>();
            IQueryable<Product> products = _context.Products.AsQueryable();
            if (name != null)
            {
                products = products.Where(p => p.Name.StartsWith(name));
            }

            if (description != null)
            {
                products = products.Where(p => p.Description.StartsWith(description));
            }

            if (priceRank != null)
            {
                products = products.Where(p => p.Price >= priceRank.Value.Item1 && p.Price <= priceRank.Value.Item2);
            }

            productList = products.Select(p => new ProductView().Map(p)).ToList();
            return productList;
        }

        public UpdateResponse UpdateProduct(ProductView productUpdated)
        {
            var result = new UpdateResponse();
            Product updatedProductEntity = new Product().Map(productUpdated);
            try
            {
                _context.Products.Update(updatedProductEntity);
                _context.ChangeTracker.DetectChanges();
                var changes = _context.ChangeTracker.DebugView.ShortView;
                if (_context.ChangeTracker.HasChanges())
                {
                    var res = _context.SaveChanges();
                    result.SuccessMessage = "Product Successfully updated!";
                }
                else
                    result.SuccessMessage = "There is no changes on the Product";
            }
            catch (SqlException ex)
            {
                result.ErrorFlag = true;
                if (ex.Message.Contains("PRIMARY KEY constraint 'PK_Products'."))
                    result.ErrorMessage = "The Product entered does not exist in the Database.";
                else
                    result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
