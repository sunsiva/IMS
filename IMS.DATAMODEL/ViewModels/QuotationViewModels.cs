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
        public Guid QUOTE_ID { get; set; }
        [Required(ErrorMessage = "Please enter Quotation Code")]
        public string QUOTE_CODE { get; set; }

        [Required(ErrorMessage = "Please enter a Quote Number")]
        public string QUOTE_NUMBER { get; set; }
        [Required(ErrorMessage = "Please select a RFQ")]
        public Guid? RFQ_ID { get; set; }
        [Required(ErrorMessage = "Please select a Product")]
        public Guid? PRODUCT_ID { get; set; }
        [Required(ErrorMessage = "Please select a Customer")]
        public Guid CUST_ID { get; set; }
        [Required(ErrorMessage = "Please enter a Customer Contact Person")]
        public string CUSTOMER_CONTACT_PERSON { get; set; }
        public string CUSTOMER_PURCHASING_AGENT { get; set; }
        public string CUSTOMER_MANAGER { get; set; }
        public string ADDRESS_TYPE { get; set; }
        [Required(ErrorMessage = "Please select a Quotation Date")]
        public DateTime? QUOTE_DATE { get; set; }
        [Required(ErrorMessage = "Please enter a Quotation Validity")]
        public string QUOTE_VALIDITY { get; set; }
        [Required(ErrorMessage = "Please select a Currency Code")]
        public string CURRENCY_CODE { get; set; }
        public string SALES_AGENT { get; set; }
        public string SALES_AGENT_LOCATION { get; set; }
        public string SALES_AGENT_CONTACT_DETAILSA { get; set; }
        public string SALES_AGENT_CONTACT_DETAILSB { get; set; }
        public string LEAD_TIME { get; set; }
        public DateTime? SHIPPING_DATE { get; set; }
        public string SHIPPING_TERMS { get; set; }
        public int? NUMBER_OF_RELEASES { get; set; }
        public string PAYMENT_TERMS { get; set; }
        public string SHIPMENT_TERMS { get; set; }
        public string SPECIAL_NOTESA { get; set; }
        public string SPECIAL_NOTESB { get; set; }
        public bool ISACTIVE { get; set; }
        public Guid? MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_ON { get; set; }
        public Guid CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }

        public virtual CustomerViewModels CUSTOMER { get; set; }
        //public virtual PRODUCT PRODUCT { get; set; }
        public virtual QuotationViewModels QUOTATION { get; set; }
    }
}
