using System;

namespace ProductLabelPrinting.Models.Models
{
    public class ProductMasterModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string UniqueCode { get; set; }
        public string CAS { get; set; }
        public string ChemicalFormula { get; set; }
        public string ManufacturerLicence { get; set; }
        public decimal MolecularWeight { get; set; }
        public string MasterLabel { get; set; }
        public string StorageConditon { get; set; }
        public int FinishMonth { get; set; }
        public string FinishMode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}