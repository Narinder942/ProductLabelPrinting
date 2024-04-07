using ProductLabelPrinting.Models.Common;
using ProductLabelPrinting.Models.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductLabelPrinting.Models.UIModels
{
    public class ProductMasterUIModel
    {
        public ProductMasterUIModel()
        {
            productUIModel = new ProductUIModel();
            productMasterList = new List<ProductMasterModel>();
            ResponseReturn = new ResponseReturn();
        }
        public ProductUIModel productUIModel { get; set; }
        public ResponseReturn ResponseReturn { get; set; }
        public bool SubmitStatus { get; set; }
        
        public List<ProductMasterModel> productMasterList { get; set; }

    }

    public class ProductUIModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Unique Code")]
        public string UniqueCode { get; set; }

        [Required]
        [DisplayName("CAS")]
        public string CAS { get; set; }

        [Required]
        [DisplayName("Chemical Formula")]
        public string ChemicalFormula { get; set; }

        [Required]
        [DisplayName("Manufacture Licence")]
        public string ManufacturerLicence { get; set; }

        [Required]
        [DisplayName("Molecular Weight")]
        public decimal MolecularWeight { get; set; }

        [Required]
        [DisplayName("Master Label")]
        public string MasterLabel { get; set; }

        [Required]
        //[DisplayName("Master Label")]
        public string FinishMode { get; set; }

        [Required]
        //[DisplayName("Master Label")]
        public int FinishMonth { get; set; }

        [Required]
        [DisplayName("Storage Condition")]
        public string StorageConditon { get; set; }
    }
}