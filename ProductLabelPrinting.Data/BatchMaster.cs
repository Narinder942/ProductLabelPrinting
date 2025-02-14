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
    
    public partial class BatchMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BatchMaster()
        {
            this.BatchContainerMasters = new HashSet<BatchContainerMaster>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatchContainerMaster> BatchContainerMasters { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual EmplyoeeMaster EmplyoeeMaster { get; set; }
    }
}
