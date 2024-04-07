using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLabelPrinting.Models.Models
{
    public class BatchModel
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string BatchNo { get; set; }
        public decimal BatchSize { get; set; }
        public string ManufactureDate { get; set; }
        public string ManufStatus { get; set; }
        public string ManufDate { get; set; }
        public string ManufacturerLicence { get; set; }
        public string MasterLabel { get; set; }
        public bool NeutralLabel { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public int BatchId { get; set; }
        public decimal NetWeight { get; set; }
        public decimal TareWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public int Container { get; set; }
        public int PackedQuantity { get; set; }

    }
}
