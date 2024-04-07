using ProductLabelPrinting.Models.Common;
using ProductLabelPrinting.Models.InputModels;
using ProductLabelPrinting.Models.Models;
using ProductLabelPrinting.Models.UIModels;
using ProductLabelPrinting.Repository.Abstract;
using ProductLabelPrinting.Services.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLabelPrinting.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductMasterModel> GetProductList()
        {
            using (ProductService productService = new ProductService())
            {
                return productService.GetProductList();
            }
        }
        public ProductMasterModel GetProductDetailsById(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return productService.GetProductDetailsById(productId);
            }
        }
        public ResponseReturn ProductAddEdit(ProductMasterInputModel productInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return productService.ProductAddEdit(productInputModel);
            }
        }
        //public List<BatchModel> GetBatchList()
        //{
        //    using (ProductService productService = new ProductService())
        //    {
        //        return productService.GetBatchList();
        //    }
        //}
       
        public ResponseReturn BatchAdd(BatchMasterInputModel batchMasterInputModel, string roleName)
        {
            using (ProductService productService = new ProductService())
            {
                return productService.BatchAdd(batchMasterInputModel, roleName);
            }
        }

        public ResponseReturn BatchContainerAdd(BatchContainerMasterInputModel batchContainerMasterInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return productService.BatchContainerAdd(batchContainerMasterInputModel);
            }
        }
        public ResponseReturn BatchContainerItemAdd(List<BatchContainerItemUIModel> batchContainerItems)
        {
            using (ProductService productService = new ProductService())
            {
                return productService.BatchContainerItemAdd(batchContainerItems);
            }
        }

        public List<BatchModel> GetBatchList(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return productService.GetBatchList(productId);
            }
        }


    }
}




