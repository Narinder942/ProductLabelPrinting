using ProductLabelPrinting.Data;
using ProductLabelPrinting.Models.Common;
using ProductLabelPrinting.Models.InputModels;
using ProductLabelPrinting.Models.Models;
using ProductLabelPrinting.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ProductLabelPrinting.Services.Interactions
{
    public class ProductService : IDisposable
    {
        private ProductLabelPrintingDbEntities _dbContext = new ProductLabelPrintingDbEntities();

        private IntPtr nativeResource = Marshal.AllocHGlobal(100);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~ProductService()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                //if (managedResource != null)
                //{
                //    managedResource.Dispose();
                //    managedResource = null;
                //}
            }
            // free native resources if there are any.
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }
        }

        public List<ProductMasterModel> GetProductList()
        {
            var productList = new List<ProductMasterModel>();

            var dbProductList = _dbContext.ProductMasters.ToList();

            if (dbProductList != null)
            {
                foreach (var item in dbProductList)
                {
                    productList.Add(new ProductMasterModel
                    {
                        Id = item.Id,
                        ProductName = item.ProductName,
                        UniqueCode = item.UniqueCode,
                        CAS = item.CAS,
                        ChemicalFormula = item.ChemicalFormula,
                        ManufacturerLicence = item.ManufacturerLicence,
                        MolecularWeight = item.MolecularWeight,
                        MasterLabel = item.MasterLabel,
                        StorageConditon = item.StorageConditon,
                        FinishMonth = (int)item.FinishMonth,
                        FinishMode = item.FinishMode,
                        CreatedBy = item.EmplyoeeMaster.EmployeeName,
                        CreatedOn = Convert.ToDateTime(item.CreatedOn).ToString("dd/MM/yyyy"),
                        UpdatedBy = item.UpdatedBy,
                        UpdatedOn = item.UpdatedOn
                    });
                }
            }
            return productList;
        }

        public ProductMasterModel GetProductDetailsById(int productId)
        {
            var productModel = new ProductMasterModel();

            if (productId > 0)
            {
                var dbProduct = _dbContext.ProductMasters.Where(x => x.Id == productId).FirstOrDefault();

                if (dbProduct != null)
                {
                    productModel = new ProductMasterModel()
                    {
                        Id = dbProduct.Id,
                        ProductName = dbProduct.ProductName,
                        UniqueCode = dbProduct.UniqueCode,
                        CAS = dbProduct.CAS,
                        ChemicalFormula = dbProduct.ChemicalFormula,
                        ManufacturerLicence = dbProduct.ManufacturerLicence,
                        MolecularWeight = dbProduct.MolecularWeight,
                        MasterLabel = dbProduct.MasterLabel,
                        StorageConditon = dbProduct.StorageConditon,
                        FinishMonth = (int)dbProduct.FinishMonth,
                        FinishMode = dbProduct.FinishMode,
                    };
                }
            }

            return productModel;
        }

        public ResponseReturn ProductAddEdit(ProductMasterInputModel productInputModel)
        {
            var result = new ResponseReturn();
            try
            {
                var checkDepartmentDuplicate = _dbContext.ProductMasters.Where(x => x.ProductName.ToLower() == productInputModel.ProductName.ToLower() && x.Id != productInputModel.Id).FirstOrDefault();
                if (checkDepartmentDuplicate != null)
                {
                    result.Status = false;
                    result.Message = "This Product is already exist";
                }
                else
                {
                    var dbProduct = _dbContext.ProductMasters.Where(x => x.Id == productInputModel.Id).FirstOrDefault();

                    if (dbProduct != null)
                    {
                        dbProduct.ProductName = productInputModel.ProductName;
                        dbProduct.UniqueCode = productInputModel.UniqueCode;
                        dbProduct.CAS = productInputModel.CAS;
                        dbProduct.ChemicalFormula = productInputModel.ChemicalFormula;
                        dbProduct.ManufacturerLicence = productInputModel.ManufacturerLicence;
                        dbProduct.MolecularWeight = productInputModel.MolecularWeight;
                        dbProduct.MasterLabel = productInputModel.MasterLabel;
                        dbProduct.StorageConditon = productInputModel.StorageConditon;
                        dbProduct.FinishMode = productInputModel.FinishMode;
                        dbProduct.FinishMonth = productInputModel.FinishMonth;
                        dbProduct.UpdatedBy = productInputModel.UpdatedBy;
                        dbProduct.UpdatedOn = DateTime.Now;
                    }
                    else
                    {
                        var productMaster = new ProductMaster();

                        productMaster.ProductName = productInputModel.ProductName;
                        productMaster.UniqueCode = productInputModel.UniqueCode;
                        productMaster.CAS = productInputModel.CAS;
                        productMaster.ChemicalFormula = productInputModel.ChemicalFormula;
                        productMaster.ManufacturerLicence = productInputModel.ManufacturerLicence;
                        productMaster.MolecularWeight = productInputModel.MolecularWeight;
                        productMaster.MasterLabel = productInputModel.MasterLabel;
                        productMaster.StorageConditon = productInputModel.StorageConditon;
                        productMaster.FinishMode = productInputModel.FinishMode;
                        productMaster.FinishMonth = productInputModel.FinishMonth;
                        productMaster.CreatedBy = productInputModel.CreatedBy;
                        productMaster.CreatedOn = DateTime.Now;

                        _dbContext.ProductMasters.Add(productMaster);
                    }
                    _dbContext.SaveChanges();

                    result.Status = true;
                    result.Message = productInputModel.Id > 0 ? "Product Details is successfully updated." : "Product is successfully submited.";
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
            }

            return result;
        }

        public ResponseReturn BatchAdd(BatchMasterInputModel batchMasterInputModel, string roleName)
        {
            var result = new ResponseReturn();

            try
            {
                
                var checkExistingBatch = _dbContext.BatchMasters.Where(x => x.BatchNo == batchMasterInputModel.BatchNo.Trim() &&  x.ProductId == x.ProductId).FirstOrDefault();

                if (checkExistingBatch == null)
                {
                    var batchMaster = new BatchMaster();

                    batchMaster.ProductId = batchMasterInputModel.ProductId;
                    batchMaster.BatchNo = batchMasterInputModel.BatchNo;
                    batchMaster.BatchSize = batchMasterInputModel.BatchSize;
                    batchMaster.ManufactureDate = batchMasterInputModel.ManufactureDate;
                    batchMaster.ManufStatus = batchMasterInputModel.ManufStatus;
                    batchMaster.ManufDate = batchMasterInputModel.ManufDate;
                    batchMaster.ManufactureLicense = batchMasterInputModel.ManufactureLicense;
                    batchMaster.MasterLabel = batchMasterInputModel.MasterLabel;
                    batchMaster.NeutralLabel = batchMasterInputModel.NeutralLabel;
                    batchMaster.CreatedBy = batchMasterInputModel.CreatedBy;
                    batchMaster.CreatedOn = DateTime.Now;

                    _dbContext.BatchMasters.Add(batchMaster);
                    _dbContext.SaveChanges();

                    result.Status = true;
                    result.Response = batchMaster.Id;
                }
                else
                {
                    if(roleName == "Admin")
                    {
                        var batchMaster = new BatchMaster();

                        batchMaster.ProductId = batchMasterInputModel.ProductId;
                        batchMaster.BatchNo = batchMasterInputModel.BatchNo;
                        batchMaster.BatchSize = batchMasterInputModel.BatchSize;
                        batchMaster.ManufactureDate = batchMasterInputModel.ManufactureDate;
                        batchMaster.ManufStatus = batchMasterInputModel.ManufStatus;
                        batchMaster.ManufDate = batchMasterInputModel.ManufDate;
                        batchMaster.ManufactureLicense = batchMasterInputModel.ManufactureLicense;
                        batchMaster.MasterLabel = batchMasterInputModel.MasterLabel;
                        batchMaster.NeutralLabel = batchMasterInputModel.NeutralLabel;
                        batchMaster.CreatedBy = batchMasterInputModel.CreatedBy;
                        batchMaster.CreatedOn = DateTime.Now;

                        _dbContext.BatchMasters.Add(batchMaster);
                        _dbContext.SaveChanges();

                        result.Status = true;
                        result.Response = batchMaster.Id;

                    }
                    else
                    {
                        result.Status = false;
                        result.Message = "This Batch No is already exist with this product.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
            }
            return result;
        }
        public ResponseReturn BatchContainerAdd(BatchContainerMasterInputModel batchContainerMasterInputModel)
        {
            var result = new ResponseReturn();

            try
            {
                var batchContainerMaster = new BatchContainerMaster();

                batchContainerMaster.BatchId = batchContainerMasterInputModel.BatchId;
                batchContainerMaster.NetWeight = batchContainerMasterInputModel.NetWeight;
                batchContainerMaster.TareWeight = batchContainerMasterInputModel.TareWeight;
                batchContainerMaster.GrossWeight = batchContainerMasterInputModel.GrossWeight;
                batchContainerMaster.Container = batchContainerMasterInputModel.Container;
                batchContainerMaster.PackedQuantity = batchContainerMasterInputModel.PackedQuantity;
                batchContainerMaster.CreatedBy = batchContainerMasterInputModel.CreatedBy;
                batchContainerMaster.CreatedOn = DateTime.Now;

                _dbContext.BatchContainerMasters.Add(batchContainerMaster);
                _dbContext.SaveChanges();
                result.Status = true;
                result.Response = batchContainerMaster.Id;
            }
            catch (Exception ex)
            {
                result.Status = false;
            }
            return result;
        }
        public ResponseReturn BatchContainerItemAdd(List<BatchContainerItemUIModel> batchContainerItems)
        {
            var result = new ResponseReturn();

            try
            {
                foreach (var item in batchContainerItems)
                {
                    var itemContainer = new BatchContainerItem();

                    itemContainer.BatchContainerId = item.BatchContainerId;
                    itemContainer.NetWeight = item.NetWeight;
                    itemContainer.TareWeight = item.TareWeight;
                    itemContainer.GrossWeight = item.GrossWeight;

                    itemContainer.CreatedBy = 1;
                    itemContainer.CreatedOn = DateTime.Now;

                    _dbContext.BatchContainerItems.Add(itemContainer);
                }

                _dbContext.SaveChanges();
                result.Status = true;
            }
            catch (Exception ex)
            {
                result.Status = false;
            }
            return result;
        }
        public List<BatchModel> GetBatchList(int productId)
        {
            var resultList = new List<BatchModel>();

            var clientIdParameter = new SqlParameter("@productId", productId);

            var result = _dbContext.Database
                .SqlQuery<BatchModel>("spGetBatchList @productId", clientIdParameter)
                .ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    resultList.Add(new BatchModel
                    {
                        BatchId = item.BatchId,
                        ProductId = item.ProductId,
                        BatchNo = item.BatchNo,
                        BatchSize = item.BatchSize,
                        ManufactureDate = item.ManufactureDate,
                        ManufStatus = item.ManufStatus,
                        ManufDate = item.ManufDate,
                        ManufacturerLicence = item.ManufacturerLicence,
                        MasterLabel = item.MasterLabel,
                        NeutralLabel = item.NeutralLabel,
                        NetWeight = item.NetWeight,
                        TareWeight = item.TareWeight,
                        GrossWeight = item.GrossWeight,
                        Container = item.Container,
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn
                    });
                }
            }

            return resultList;

        }

    }
}
