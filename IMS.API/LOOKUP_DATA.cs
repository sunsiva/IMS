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
    
    public partial class LOOKUP_DATA
    {
        public System.Guid LOOKUPID { get; set; }
        public Nullable<System.Guid> LOOKUPCATEGORYID { get; set; }
        public string LOOKUPCODE { get; set; }
        public string LOOKUPDESC { get; set; }
        public bool ISACTIVE { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public string CREATEDBY { get; set; }
    
        public virtual LOOKUP_CATEGORIES LOOKUP_CATEGORIES { get; set; }
    }
}
