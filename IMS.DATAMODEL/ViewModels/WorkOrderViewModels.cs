using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataModel.ViewModels
{
    public class WorkOrderViewModels
    {
            public System.Guid WO_ID { get; set; }
            public System.Guid PRODUCT_ID { get; set; }
            public string WO_CODE { get; set; }
            public string WO_NUMBER { get; set; }
            public string STATUS { get; set; }
            public System.Guid CUST_PO_ID { get; set; }
            public string CUSTOMER_NAME { get; set; }
            public string JOB_NAME { get; set; }
            public Nullable<bool> ISREPEATORDER { get; set; }
            public string REPEATREASON { get; set; }
            public System.DateTime WORK_ORDER_DATE { get; set; }
            public System.DateTime DUE_DATE { get; set; }
            public Nullable<System.DateTime> REQUIRED_DELIVERY_START_DATE { get; set; }
            public Nullable<System.DateTime> REQUIRED_DELIVERY_END_DATE { get; set; }
            public int NO_OF_RELEASES { get; set; }
            public string DRAWING { get; set; }
            public bool ISACTIVE { get; set; }
            public Nullable<System.Guid> MODIFIED_BY { get; set; }
            public Nullable<System.DateTime> MODIFIED_ON { get; set; }
            public System.Guid CREATED_BY { get; set; }
            public System.DateTime CREATED_ON { get; set; }

           // public virtual PRODUCT PRODUCT { get; set; }
    }
}
