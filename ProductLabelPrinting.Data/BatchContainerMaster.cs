//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductLabelPrinting.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BatchContainerMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BatchContainerMaster()
        {
            this.BatchContainerItems = new HashSet<BatchContainerItem>();
        }
    
        public int Id { get; set; }
        public int BatchId { get; set; }
        public decimal NetWeight { get; set; }
        public decimal TareWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public int Container { get; set; }
        public int PackedQuantity { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatchContainerItem> BatchContainerItems { get; set; }
        public virtual BatchMaster BatchMaster { get; set; }
    }
}
