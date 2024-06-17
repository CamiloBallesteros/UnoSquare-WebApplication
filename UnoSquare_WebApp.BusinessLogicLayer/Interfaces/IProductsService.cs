using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoSquare.Models.ResponseModels;
using UnoSquare.Models.ViewModels;

namespace UnoSquare.BusinessLogicLayer.Interfaces
{
    public interface IProductsService
    {
        public List<ProductView> GetProductsListFiltered(string? name = null, string? description = null, (decimal, decimal)? priceRank = null);
        public ProductView? GetProduct(int id);
        public Add_DeleteResponse AddNewProduct(ProductView newProduct);
        public UpdateResponse UpdateProduct(ProductView productUpdated);
        public Add_DeleteResponse DeleteProduct(int idDelete);
    }
}
