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
    
    public partial class PURCHASE_ORDER
    {
        public System.Guid PO_ID { get; set; }
        public string PO_NO { get; set; }
        public string PO_NAME { get; set; }
        public string PO_DESC { get; set; }
        public string PO_TYPE { get; set; }
        public Nullable<System.Guid> REFERENCE_PO_ID { get; set; }
        public string MODEOFRECEIPT { get; set; }
        public string ORIGINATE_COMPANY { get; set; }
        public string ORIGINATE_CONTACT_PERSON { get; set; }
        public string ORIGINATE_COMP_PURCHAE_MNGR { get; set; }
        public string ORIGINATE_COMP_MNGR { get; set; }
        public string BID_TYPE { get; set; }
        public System.DateTime PO_DATE { get; set; }
        public System.DateTime DUE_DATE { get; set; }
        public System.DateTime CLOSING_DATE { get; set; }
        public System.DateTime REQUIRED_DELIVERY_START_DATE { get; set; }
        public System.DateTime REQUIRED_DELIVERY_END_DATE { get; set; }
        public Nullable<int> DURATION { get; set; }
        public string DURATION_TIMELINE { get; set; }
        public int NO_OF_RELEASES { get; set; }
        public System.Guid LOC_ID { get; set; }
        public System.Guid JOB_ID { get; set; }
        public string JOB_NAME { get; set; }
        public string JOB_CLIENT_NAME { get; set; }
        public string JOB_LOCATION1 { get; set; }
        public string JOB_LOCATION2 { get; set; }
        public string JOB_LOCATION3 { get; set; }
        public Nullable<bool> ISCUSTOMER_SUPPLIEDDRAWING { get; set; }
        public string DRAWING_SOURCE { get; set; }
        public bool ISACTIVE { get; set; }
        public Nullable<System.Guid> MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
        public System.Guid CREATED_BY { get; set; }
        public System.DateTime CREATED_ON { get; set; }
    
        public virtual LOCATION_MASTER LOCATION_MASTER { get; set; }
    }
}
