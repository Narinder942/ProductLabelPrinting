using ProductLabelPrinting.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLabelPrinting.Models.UIModels
{
    public class ProductBatchPrintUIModel
    {
        public ProductBatchPrintUIModel()
        {
            AddBatchStaus = true;
            batchMasterUIModel = new BatchMasterUIModel();
            batchContainerMasterUIModel = new BatchContainerMasterUIModel();
            batchContainerItemUIModel = new List<BatchContainerItemUIModel>();
        }
        public int selectedProductList { get; set; }

        public string MasterLabel { get; set; }
        public string ManufacturerLicence { get; set; }
        public string ReturnMessage { get; set; }
        public bool ReturnResponse { get; set; }
        public int TotalPackedQuantity{ get; set; }
        public int TotalContainer{ get; set; }
        public List<ProductMasterModel> productList { get; set; }

        public bool ShowSaveMessage { get; set; }
        public bool ShowPackedQuantityMessage { get; set; }
        public bool AddBatchStaus { get; set; }
        public bool ShowBatchAddButton { get; set; }
        public int BatchId { get; set; }
        public int BatchContainerId { get; set; }

        public int Id { get; set; }
        public BatchMasterUIModel batchMasterUIModel { get; set; }
        public BatchContainerMasterUIModel batchContainerMasterUIModel { get; set; }
        public List<BatchContainerItemUIModel> batchContainerItemUIModel { get; set; }
    }

   
    public class BatchContainerMasterUIModel
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public decimal NetWeight { get; set; }
        public decimal TareWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public int Container { get; set; }
        public decimal PackedQuantity { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedBy { get; set; }
    }
    public class BatchContainerItemUIModel
    {
        public int Id { get; set; }
        public int BatchContainerId { get; set; }
        public decimal NetWeight { get; set; }
        public decimal TareWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedBy { get; set; }
    }





}
