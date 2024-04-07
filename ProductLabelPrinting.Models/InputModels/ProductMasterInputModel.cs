using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLabelPrinting.Models.InputModels
{
    public class ProductMasterInputModel
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
        public string FinishMode { get; set; }
        public int FinishMonth { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}