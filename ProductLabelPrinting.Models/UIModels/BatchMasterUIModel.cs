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
    public class BatchMasterUIModel
    {
        public BatchMasterUIModel()
        {
            batchModelList = new List<BatchModel>();
        }

        public bool SubmitMessage { get; set; }
        public bool SubmitStatus { get; set; }
        public List<BatchModel> batchModelList { get; set; }
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }

        [Required]
        [DisplayName("Batch No")]
        public string BatchNo { get; set; }

        [Required]
        [DisplayName("Batch Size")]
        public decimal BatchSize { get; set; }

        [Required]
        [DisplayName("Manufacture Date")]
        public string ManufactureDate { get; set; }

        [Required]
        [DisplayName("Status")]
        public string ManufStatus { get; set; }

        [Required]
        [DisplayName("Status Date")]
        public string ManufDate { get; set; }

        [Required]
        [DisplayName("Manufacture License")]
        public string ManufactureLicense { get; set; }

        [Required]
        [DisplayName("Master Label")]
        public string MasterLabel { get; set; }
        public bool NeutralLabel { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }


}
