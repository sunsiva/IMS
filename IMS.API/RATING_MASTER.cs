//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMS.API
{
    using System;
    using System.Collections.Generic;
    
    public partial class RATING_MASTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RATING_MASTER()
        {
            this.CUSTOMERs = new HashSet<CUSTOMER>();
        }
    
        public System.Guid RATING_ID { get; set; }
        public string RATING { get; set; }
        public string RELATIONSHIP { get; set; }
        public string BUSINESS_PERFORMANCE { get; set; }
        public string PIPELINE { get; set; }
        public string PAYMENT_REGULARITY { get; set; }
        public string DISCOUNTS { get; set; }
        public string RESPONSIVENESS { get; set; }
        public string DESCRIPTION { get; set; }
        public bool ISACTIVE { get; set; }
        public Nullable<System.Guid> MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
        public System.Guid CREATED_BY { get; set; }
        public System.DateTime CREATED_ON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER> CUSTOMERs { get; set; }
    }
}
