using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataModel.ViewModels
{
    public class MasterViewModels
    {
        
    }

    public class LookupCategoryViewModels
    {
        public Guid LOOKUPCATEGORYID { get; set; }
        public string LOOKUPCATEGORYCODE { get; set; }
        public string LOOKUPCATEGORYDESC { get; set; }
        public bool? ISAPPSPECIFIC { get; set; }
        public bool? ISORGSPECIFIC { get; set; }
        public List<LookupDataViewModels> LOOKUP_DATA { get; set; }
    }

    public class LookupDataViewModels
    {
        public Guid LOOKUPID { get; set; }
        public Guid? LOOKUPCATEGORYID { get; set; }
        public string LOOKUPCODE { get; set; }
        public string LOOKUPDESC { get; set; }
        public bool ISACTIVE { get; set; }
        public DateTime? CREATEDON { get; set; }
        public string CREATEDBY { get; set; }
    }

}
