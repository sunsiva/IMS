using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataModel.ViewModels
{
    public class CustStatusHistViewModels
    {
        [Key]
        public System.Guid STATUSHIST_ID { get; set; }
        public System.Guid CUST_ID { get; set; }
        public string COMMENTS { get; set; }
        public Nullable<bool> ISACTIVE { get; set; }
        public System.DateTime ACTIVATED_ON { get; set; }
        public System.DateTime DEACTIVATED_ON { get; set; }
        public System.Guid MODIFIED_BY { get; set; }
        public System.DateTime MODIFIED_ON { get; set; }

        public virtual CustomerViewModels CUSTOMER { get; set; }
    }
}
