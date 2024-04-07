using ProductLabelPrinting.Models.Common;
using ProductLabelPrinting.Models.InputModels;
using ProductLabelPrinting.Models.Models;
using ProductLabelPrinting.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLabelPrinting.Repository.Abstract
{
    public interface IProductRepository
    {
        List<ProductMasterModel> GetProductList();
        ProductMasterModel GetProductDetailsById(int productId);
        ResponseReturn ProductAddEdit(ProductMasterInputModel productInputModel);
        //List<BatchModel> GetBatchList();
        ResponseReturn BatchAdd(BatchMasterInputModel batchMasterInputModel, string roleName);
        ResponseReturn BatchContainerAdd(BatchContainerMasterInputModel batchContainerMasterInputModel);
        ResponseReturn BatchContainerItemAdd(List<BatchContainerItemUIModel> batchContainerItems);
        List<BatchModel> GetBatchList(int productId);
    }
}
