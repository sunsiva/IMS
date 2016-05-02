using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMS.DataModel.ViewModels
{
    public class CustomerViewModels
    {
        public Guid CUST_ID { get; set; }
        public string CUST_NO { get; set; }
        public string CUST_CODE { get; set; }
        public string CUST_NAME { get; set; }
        public bool ISVENDOR { get; set; }
        public string LEGAL_NAME { get; set; }
        public string DEPARTMENT { get; set; }
        public string COMPANY_RELATIONSHIP { get; set; }
        public Guid STATUS_LKPID { get; set; }
        public Guid? LINEOFBIZ_LKPID { get; set; }
        public Guid? LOB_CATEGORY_LKPID { get; set; }
        public Guid? COMPANY_GROUP_CODE_LKPID { get; set; }
        public Guid? SALESCHNL_REFERENCE_LKPID { get; set; }
        public string SALES_PERSON { get; set; }
        public Guid COMP_SIZE_LKPID { get; set; }
        public Guid CURRENCY_LKPID { get; set; }
        public Guid? SHIPMENTTERM_LKPID { get; set; }
        public Guid? PAYMENTTERM_LKPID { get; set; }
        public Guid? CREDITLIMIT_LKPID { get; set; }
        public Guid? PRICEBAND_LKPID { get; set; }
        public Guid? DISCOUNTBAND_LKPID { get; set; }
        public string AUTO_BANDING { get; set; }
        public Guid TAXCODE1_LKPID { get; set; }
        public Guid? TAXCODE2_LKPID { get; set; }
        public Guid? TAXCODE3_LKPID { get; set; }
        public Guid CUST_BILL_LOC_ID { get; set; }
        public Guid CUST_SHIP_LOC_ID { get; set; }
        public Guid CUST_TYPE_LKPID { get; set; }
        public Guid OWNERSHIP_LKPID { get; set; }
        public string COMPANY_EMAIL { get; set; }
        public string COMPANY_WEBSITE { get; set; }
        public Guid? RATING_ID { get; set; }
        public int YEARS_OF_ESTABLISHMENT { get; set; }
        public int NO_OF_EMPLOYEES_OFFICE { get; set; }
        public int NO_OF_EMPLOYEES_FACTORY { get; set; }
        public double? REVENUE { get; set; }
        public double? TURN_OVER { get; set; }
        public double? SALES { get; set; }
        public string PAYMENT_METHOD { get; set; }
        public string SHIPMENT_METHOD { get; set; }
        public string CALL_PREFERENCES { get; set; }
        public string CREDIT_CHECK { get; set; }
        public string CONTRACT { get; set; }
        public string MSA { get; set; }
        public string SLA { get; set; }
        public string DECLARATION { get; set; }
        public string DESCRIPTION { get; set; }
        public string COMPANY_TYPE { get; set; }
        public string OWNERSHIP { get; set; }
        public string CAPACITY_DAILY { get; set; }
        public string CAPACITY_MONTHLY { get; set; }
        public string CAPACITY_YEARLY { get; set; }
        public string CONTACT_PERSON { get; set; }
        public bool ISACTIVE { get; set; }
        public Guid? MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_ON { get; set; }
        public Guid CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }

        //public virtual RatingMasterViewModels RATING_MASTER { get; set; }
        //public virtual ICollection<QuotationViewModels> QUOTATIONs { get; set; }
        //public virtual ICollection<CustStatusHistViewModels> CUST_STATUS_HISTORY { get; set; }
    }
}
