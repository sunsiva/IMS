using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.DataModel.ViewModels
{
    public class RFQViewModels
    {
        public Guid RFQ_ID { get; set; }
        [Required]
        public string RFQ_NO { get; set; }
        [Required]
        public string RFQ_NAME { get; set; }
        public string RFQ_DESC { get; set; }
        public string MODEOFRECEIPT { get; set; }
        [Required]
        public string ORIGINATING_COMPANY { get; set; }
        public string ORIGINATING_CONTACTPERSON { get; set; }
        public string ORIGINATING_COMP_PURCHASING_MANAGER { get; set; }
        public string ORIGINATING_COMP_MANAGER { get; set; }
        public string BID_TYPE { get; set; }
        [Required]
        public DateTime RFQ_DATE { get; set; }
        public DateTime? DUE_DATE { get; set; }
        public DateTime? CLOSING_DATE { get; set; }
        public string DURATION { get; set; }
        public string DURATION_TIMELINE { get; set; }
        public int NUMBEROFRELEASES { get; set; }
        [Required(ErrorMessage = "Plese enter a location")]
        public Guid LOC_ID { get; set; }
        public Guid? JOB_ID { get; set; }
        public string JOB_NAME { get; set; }
        public string JOB_CLIENT_NAME { get; set; }
        public string JOB_LOCATIONA { get; set; }
        public string JOB_LOCATIONB { get; set; }
        public string JOB_LOCATIONC { get; set; }
        public bool? ISCUSTOMER_SUPPLIEDDRAWING { get; set; }
        public string DRAWING_SOURCE { get; set; }
        [Required(ErrorMessage ="Please select a Product")]
        public Guid?PRODUCT_ID { get; set; }
        [Required]
        public string QUANTITY { get; set; }
        public bool? ISREPEAT_ORDER { get; set; }
        [Required]
        public double? UNIT_PRICE { get; set; }
        public string PRICING_INDICATORSA { get; set; }
        public string PRICING_INDICATORSB { get; set; }
        public string PRICING_INDICATORSC { get; set; }
        public string SPECIAL_REQUESTSA { get; set; }
        public string SPECIAL_REQUESTSB { get; set; }
        public string SPECIAL_REQUESTSC { get; set; }
        public string PREPARED_BY { get; set; }
        public string APPROVED_BY { get; set; }
        public string TYPEOF_ORIGINAL_RFQ { get; set; }
        public string BARCODE { get; set; }
        public DateTime? DATE_RECEIVED { get; set; }
        public bool ISACTIVE { get; set; }
        public Guid? MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_ON { get; set; }
        public Guid CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
    }
}
