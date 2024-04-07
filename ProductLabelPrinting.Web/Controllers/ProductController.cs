using ProductLabelPrinting.Models.Common;
using ProductLabelPrinting.Models.InputModels;
using ProductLabelPrinting.Models.Models;
using ProductLabelPrinting.Models.UIModels;
using ProductLabelPrinting.Repository.Abstract;
using ProductLabelPrinting.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProductLabelPrinting.Web.Controllers
{
    [CustomAuthenticationFilter]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository { get; set; }

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: Product
        public ActionResult Products()
        {
            var myOjectProductUIModel = new ProductMasterUIModel();

            myOjectProductUIModel.productMasterList = _productRepository.GetProductList();

            return View(myOjectProductUIModel);
        }


        [HttpPost]
        public ActionResult ProductAddEit(ProductMasterUIModel productMasterUIModel)
        {
            var responseReturn = new ResponseReturn();

            if (ModelState.IsValid)
            {
                var ProductInputModel = new ProductMasterInputModel();

                ProductInputModel.Id = productMasterUIModel.productUIModel.Id;
                ProductInputModel.ProductName = productMasterUIModel.productUIModel.ProductName;
                ProductInputModel.UniqueCode = productMasterUIModel.productUIModel.UniqueCode;
                ProductInputModel.CAS = productMasterUIModel.productUIModel.CAS;
                ProductInputModel.ChemicalFormula = productMasterUIModel.productUIModel.ChemicalFormula;
                ProductInputModel.ManufacturerLicence = productMasterUIModel.productUIModel.ManufacturerLicence;
                ProductInputModel.MolecularWeight = productMasterUIModel.productUIModel.MolecularWeight;
                ProductInputModel.MasterLabel = productMasterUIModel.productUIModel.MasterLabel;
                ProductInputModel.StorageConditon = productMasterUIModel.productUIModel.StorageConditon;
                ProductInputModel.FinishMode = productMasterUIModel.productUIModel.FinishMode;
                ProductInputModel.FinishMonth = productMasterUIModel.productUIModel.FinishMonth;

                if (productMasterUIModel.productUIModel.Id > 0)
                {
                    ProductInputModel.UpdatedBy = SessionHelper.GetUserId();
                }
                else
                {
                    ProductInputModel.CreatedBy = SessionHelper.GetUserId();
                }

                productMasterUIModel.ResponseReturn = _productRepository.ProductAddEdit(ProductInputModel);

                productMasterUIModel.SubmitStatus = true;

                //productMasterUIModel.SubmitStatus = responseReturn.Status;
                //productMasterUIModel.SubmitMessage = responseReturn.Message;
                //return Json(responseReturn, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            }

            ///ModelState.Clear();

            return PartialView("Partials/_AddProduct", productMasterUIModel);
        }


        [HttpGet]
        public ActionResult ProductBatchPrint()
        {
            var myObject = new ProductBatchPrintUIModel();

            myObject.productList = _productRepository.GetProductList();
            myObject.ShowBatchAddButton = true;

            TempData["BatchContainerItems"] = null;


            return View(myObject);
        }

        [HttpGet]
        public ActionResult GetProductDetailById(int productId)
        {
            var returnResult = new ResponseReturn();
            if (productId > 0)
            {
                returnResult.Response = _productRepository.GetProductDetailsById(productId);
                returnResult.Status = true;
            }

            return Json(returnResult, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult ProductBatchPrint(ProductBatchPrintUIModel productBatchPrintUIModel)
        {

            var myObject = new ProductBatchPrintUIModel();


            if (TempData["BatchContainerItems"] != null)
            {
                myObject.batchContainerItemUIModel = TempData["BatchContainerItems"] as List<BatchContainerItemUIModel>;
            }

            myObject.productList = _productRepository.GetProductList();
            myObject.selectedProductList = productBatchPrintUIModel.Id;
            myObject.BatchId = productBatchPrintUIModel.BatchId;

            myObject.batchMasterUIModel.Id = productBatchPrintUIModel.Id;
            myObject.batchMasterUIModel.ProductId = productBatchPrintUIModel.Id;
            myObject.batchMasterUIModel.BatchNo = productBatchPrintUIModel.batchMasterUIModel.BatchNo;
            myObject.batchMasterUIModel.BatchSize = productBatchPrintUIModel.batchMasterUIModel.BatchSize;
            myObject.batchMasterUIModel.ManufactureDate = productBatchPrintUIModel.batchMasterUIModel.ManufactureDate;
            myObject.batchMasterUIModel.ManufStatus = productBatchPrintUIModel.batchMasterUIModel.ManufStatus;
            myObject.batchMasterUIModel.ManufDate = productBatchPrintUIModel.batchMasterUIModel.ManufDate;
            myObject.batchMasterUIModel.ManufactureLicense = productBatchPrintUIModel.batchMasterUIModel.ManufactureLicense;
            myObject.batchMasterUIModel.MasterLabel = productBatchPrintUIModel.batchMasterUIModel.MasterLabel;
            myObject.batchMasterUIModel.NeutralLabel = productBatchPrintUIModel.batchMasterUIModel.NeutralLabel;

            //myObject.batchContainerMasterUIModel.NetWeight = productBatchPrintUIModel.batchContainerMasterUIModel.NetWeight;
            //myObject.batchContainerMasterUIModel.TareWeight = productBatchPrintUIModel.batchContainerMasterUIModel.TareWeight;
            //myObject.batchContainerMasterUIModel.GrossWeight = productBatchPrintUIModel.batchContainerMasterUIModel.GrossWeight;
            //myObject.batchContainerMasterUIModel.Container = productBatchPrintUIModel.batchContainerMasterUIModel.Container;

            myObject.batchContainerMasterUIModel.PackedQuantity = productBatchPrintUIModel.batchContainerMasterUIModel.PackedQuantity;


            if (Request.Params["btnAddBatch"] != null || Request.Params["btnAddMore"] != null)
            {
                if (Request.Params["btnAddBatch"] != null)
                {
                    var batchInputModel = new BatchMasterInputModel();

                    batchInputModel.ProductId = productBatchPrintUIModel.Id;
                    batchInputModel.BatchNo = productBatchPrintUIModel.batchMasterUIModel.BatchNo;
                    batchInputModel.BatchSize = productBatchPrintUIModel.batchMasterUIModel.BatchSize;
                    batchInputModel.ManufactureDate = productBatchPrintUIModel.batchMasterUIModel.ManufactureDate;
                    batchInputModel.ManufStatus = productBatchPrintUIModel.batchMasterUIModel.ManufStatus;
                    batchInputModel.ManufDate = productBatchPrintUIModel.batchMasterUIModel.ManufDate;
                    batchInputModel.ManufactureLicense = productBatchPrintUIModel.batchMasterUIModel.ManufactureLicense;
                    batchInputModel.MasterLabel = productBatchPrintUIModel.batchMasterUIModel.MasterLabel;
                    batchInputModel.NeutralLabel = productBatchPrintUIModel.batchMasterUIModel.NeutralLabel;

                    batchInputModel.CreatedBy = SessionHelper.GetUserId();

                    var batchMasterReturn = _productRepository.BatchAdd(batchInputModel,SessionHelper.GetUserRoleName());

                    if (batchMasterReturn.Status)
                    {
                        myObject.BatchId = Convert.ToInt16(batchMasterReturn.Response);

                        myObject.ShowBatchAddButton = false;
                    }
                    else
                    {
                        myObject.ShowBatchAddButton = true;
                        myObject.ReturnResponse = true;
                        myObject.ReturnMessage = batchMasterReturn.Message;

                        ModelState.Clear();

                        return PartialView("Partials/_ProductBatchPrint", myObject);
                    }
                }

                var packedQuantity = productBatchPrintUIModel.batchContainerMasterUIModel.PackedQuantity + productBatchPrintUIModel.batchContainerMasterUIModel.NetWeight * Convert.ToInt32(productBatchPrintUIModel.batchContainerMasterUIModel.Container);

                if (packedQuantity > productBatchPrintUIModel.batchMasterUIModel.BatchSize)
                {
                    myObject.TotalContainer = productBatchPrintUIModel.TotalContainer;
                    myObject.ReturnResponse = true;
                    myObject.ReturnMessage = "Packed quantity should not be greater than batch size";
                    TempData["BatchContainerItems"] = myObject.batchContainerItemUIModel;
                    ModelState.Clear();

                    return PartialView("Partials/_ProductBatchPrint", myObject);
                }
                else
                {
                    myObject.batchContainerMasterUIModel.PackedQuantity = packedQuantity;
                    myObject.TotalContainer = productBatchPrintUIModel.batchContainerMasterUIModel.Container + productBatchPrintUIModel.TotalContainer;

                    var batchcontiner = new BatchContainerMasterInputModel();

                    batchcontiner.BatchId = myObject.BatchId;
                    batchcontiner.NetWeight = productBatchPrintUIModel.batchContainerMasterUIModel.NetWeight;
                    batchcontiner.TareWeight = productBatchPrintUIModel.batchContainerMasterUIModel.TareWeight;
                    batchcontiner.GrossWeight = productBatchPrintUIModel.batchContainerMasterUIModel.GrossWeight;
                    batchcontiner.Container = productBatchPrintUIModel.batchContainerMasterUIModel.Container;
                    batchcontiner.PackedQuantity = Convert.ToInt32(productBatchPrintUIModel.batchContainerMasterUIModel.NetWeight) * Convert.ToInt32(productBatchPrintUIModel.batchContainerMasterUIModel.Container);
                    batchcontiner.CreatedBy = SessionHelper.GetUserId();
                    batchcontiner.CreatedOn = DateTime.Now;


                    var BatchContainerReturn = _productRepository.BatchContainerAdd(batchcontiner);

                    for (int i = 1; i <= productBatchPrintUIModel.batchContainerMasterUIModel.Container; i++)
                    {
                        myObject.batchContainerItemUIModel.Add(new BatchContainerItemUIModel
                        {
                            BatchContainerId = Convert.ToInt16(BatchContainerReturn.Response),
                            NetWeight = productBatchPrintUIModel.batchContainerMasterUIModel.NetWeight,
                            TareWeight = productBatchPrintUIModel.batchContainerMasterUIModel.TareWeight,
                            GrossWeight = productBatchPrintUIModel.batchContainerMasterUIModel.GrossWeight
                        });
                    }
                }
            }
            else if (Request.Params["batchMasterUIModelManufactureDate_Change"] != null)
            {
                var kk = _productRepository.GetProductDetailsById(productBatchPrintUIModel.Id);

                myObject.batchMasterUIModel.ManufDate = Convert.ToDateTime(myObject.batchMasterUIModel.ManufactureDate).AddMonths(kk.FinishMonth).ToString("MMMM yyyy");
                myObject.batchMasterUIModel.ManufStatus = kk.FinishMode;
                myObject.ShowBatchAddButton  = true;

            }

            else if (Request.Params["btnSubmit"] != null)
            {
                if(productBatchPrintUIModel.batchContainerMasterUIModel.PackedQuantity == productBatchPrintUIModel.batchMasterUIModel.BatchSize)
                {
                    var kk = _productRepository.BatchContainerItemAdd(myObject.batchContainerItemUIModel);

                    myObject.ShowSaveMessage = kk.Status == true ? true : false;

                    TempData["BatchContainerItems"] = null;

                    myObject.selectedProductList = productBatchPrintUIModel.Id;
                    myObject.BatchId = productBatchPrintUIModel.BatchId;
                    myObject.TotalContainer = productBatchPrintUIModel.TotalContainer;
                    myObject.productList = _productRepository.GetProductList();

                    ModelState.Clear();
                    return PartialView("Partials/_ProductBatchPrint", myObject);
                }
                else
                {
                    myObject.ReturnResponse = true;
                    myObject.ReturnMessage = "Packed quantity and Batch Size Should be Same.";
                    TempData["BatchContainerItems"] = myObject.batchContainerItemUIModel;
                    ModelState.Clear();

                    return PartialView("Partials/_ProductBatchPrint", myObject);
                }
            }

            else if (Request.Params["btnPrint"] != null)
            {

                return JavaScript("window.location.href = '/Report/Index?productId=" + productBatchPrintUIModel.selectedProductList + "&batchId=" + productBatchPrintUIModel.BatchId + "'");
            }


            TempData["BatchContainerItems"] = myObject.batchContainerItemUIModel;


            ModelState.Clear();
            return PartialView("Partials/_ProductBatchPrint", myObject);
        }

        [HttpGet]
        public ActionResult ProductBatchDetail()
        {
            var myOjectProductUIModel = new ProductMasterUIModel();

            myOjectProductUIModel.productMasterList = _productRepository.GetProductList();

            return View(myOjectProductUIModel);
        }


        public ActionResult GetProductBatchDetailList(int productId)
        {
            var responseReturn = new ResponseReturn();
            try
            {

                responseReturn.Response = _productRepository.GetBatchList(productId);
                responseReturn.Status = true;
            }

            catch (Exception ex)
            {
                responseReturn.Status = false;
            }
            return Json(responseReturn, JsonRequestBehavior.AllowGet);
        }

    }
}