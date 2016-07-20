using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataModel.ViewModels
{
    public class LocationViewModels
    {
        public Guid LOC_ID { get; set; }
        public string LOC_CODE { get; set; }
        public string ADDRESS_TYPE { get; set; }
        public string LOCATION_SHORT_NAME { get; set; }
        public string LOC_ADDRESS { get; set; }
        public string LOC_CITY { get; set; }
        public string LOC_STATE { get; set; }
        public string LOC_COUNTRY { get; set; }
        public string LOC_ZIPCODE { get; set; }
        public string TIME_ZONE { get; set; }
        public string GEO_LOC_LATITUDE { get; set; }
        public string GEO_LOC_LONGITUDE { get; set; }
        public bool ISACTIVE { get; set; }
        public Guid? MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_ON { get; set; }
        public Guid CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
    }
}
