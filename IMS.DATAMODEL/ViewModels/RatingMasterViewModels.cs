using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataModel.ViewModels
{
    public class RatingMasterViewModels
    {
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

        public virtual ICollection<CustomerViewModels> CUSTOMERs { get; set; }
    }
}
