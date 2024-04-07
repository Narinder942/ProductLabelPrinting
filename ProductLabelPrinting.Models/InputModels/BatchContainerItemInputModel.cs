using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLabelPrinting.Models.InputModels
{
    public class BatchContainerItemInputModel
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
