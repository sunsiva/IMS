using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataModel.ViewModels
{
    public class QuotationViewModels
    {
        public System.Guid QUOTE_ID { get; set; }
        public string QUOTE_CODE { get; set; }
        public string QUOTE_NUMBER { get; set; }
        public Nullable<System.Guid> RFQ_ID { get; set; }
        public Nullable<System.Guid> PRODUCT_ID { get; set; }
        public System.Guid CUST_ID { get; set; }
        public string CUSTOMER_CONTACT_PERSON { get; set; }
        public string CUSTOMER_PURCHASING_AGENT { get; set; }
        public string CUSTOMER_MANAGER { get; set; }
        public string ADDRESS_TYPE { get; set; }
        public Nullable<System.DateTime> QUOTE_DATE { get; set; }
        public string QUOTE_VALIDITY { get; set; }
        public string CURRENCY_CODE { get; set; }
        public string SALES_AGENT { get; set; }
        public string SALES_AGENT_LOCATION { get; set; }
        public string SALES_AGENT_CONTACT_DETAILSA { get; set; }
        public string SALES_AGENT_CONTACT_DETAILSB { get; set; }
        public string LEAD_TIME { get; set; }
        public Nullable<System.DateTime> SHIPPING_DATE { get; set; }
        public string SHIPPING_TERMS { get; set; }
        public Nullable<int> NUMBER_OF_RELEASES { get; set; }
        public string PAYMENT_TERMS { get; set; }
        public string SHIPMENT_TERMS { get; set; }
        public string SPECIAL_NOTESA { get; set; }
        public string SPECIAL_NOTESB { get; set; }
        public bool ISACTIVE { get; set; }
        public Nullable<System.Guid> MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
        public System.Guid CREATED_BY { get; set; }
        public System.DateTime CREATED_ON { get; set; }

        public virtual CustomerViewModels CUSTOMER { get; set; }
        //public virtual PRODUCT PRODUCT { get; set; }
        public virtual QuotationViewModels QUOTATION1 { get; set; }
        public virtual QuotationViewModels QUOTATION2 { get; set; }
    }
}
