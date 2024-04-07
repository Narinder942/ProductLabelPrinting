using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLabelPrinting.Models.InputModels
{
    public class BatchMasterInputModel
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string BatchNo { get; set; }
        public decimal BatchSize { get; set; }
        public string ManufactureDate { get; set; }
        public string ManufStatus { get; set; }
        public string ManufDate { get; set; }
        public string ManufactureLicense { get; set; }
        public string MasterLabel { get; set; }
        public Nullable<bool> NeutralLabel { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
