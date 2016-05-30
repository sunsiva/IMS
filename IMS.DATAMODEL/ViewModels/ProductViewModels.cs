using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataModel.ViewModels
{
    public class ProductViewModels
    {
        public ProductViewModels()
        {
            
        }

        public Guid? PRODUCT_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_CATEGORY { get; set; }
        public string PRODUCT_VARIANT { get; set; }
        public string PRODUCT_DESCRIPTION { get; set; }
        public string PRODUCT_TYPE { get; set; }
        public int? PRODUCT_DIMENSIONS_LENGTH { get; set; }
        public int? PRODUCT_DIMENSIONS_BREADTH { get; set; }
        public int? PRODUCT_DIMENSIONS_WIDTH { get; set; }
        public int? PRODUCT_DIMENSIONSA { get; set; }
        public int? PRODUCT_DIMENSIONSB { get; set; }
        public int? QUANTITY { get; set; }
        public bool? ISREPEAT_ORDER { get; set; }
        public double? UNIT_PRICE { get; set; }
        public int? UNIT { get; set; }
        public double? DISCOUNT { get; set; }
        public double? LINE_TOTAL { get; set; }
        public double? TOTAL { get; set; }
        public double? GRAND_TOTAL { get; set; }
        public string SPECIAL_REQUESTSA { get; set; }
        public string SPECIAL_REQUESTSB { get; set; }
        public string SPECIAL_REQUESTSC { get; set; }
        public string SPECIAL_REQUESTSD { get; set; }
        public string SPECIAL_REQUESTSE { get; set; }
        public Guid? PREPARED_BY { get; set; }
        public Guid? APPROVED_BY { get; set; }
        public string TYPEOF_ORIGINAL { get; set; }
        public DateTime? DATE_RECEIVED { get; set; }
        public bool ISACTIVE { get; set; }
        public Guid? MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_ON { get; set; }
        public Guid CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }

        public virtual ICollection<QuotationViewModels> QUOTATIONs { get; set; }
        public virtual ICollection<WorkOrderViewModels> WORKORDERs { get; set; }
    }
}
