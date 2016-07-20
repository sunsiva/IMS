namespace IMS.Common
{
    public static class IMSConst
    {
        public static string API_SERVICE_BASE_ADRS = "http://ims.service";
        public static string WEB_APP_BASE_ADRS = "http://ims";

        public static string USER_NEW_ENDPNT = "api/Account/Register";
        public static string ROLE_GET_ENDPNT = "api/AspNetRoles";

        public static string CUST_NEW_ENDPNT = "api/Customer/PostCustomer";
        public static string CUST_GET_ENDPNT = "api/Customer/GetCustomers";
        public static string CUST_GET_BYID_ENDPNT = "api/Customer/GetCustomer";
        public static string CUST_UPD_ENDPNT = "api/Customer/PutCustomer";
        public static string CUST_DEL_ENDPNT = "api/Customer/DeleteCustomer";

        public static string QUOT_NEW_ENDPNT = "api/Quotation/PostQUOTATION";
        public static string QUOT_GET_ENDPNT = "api/Quotation/GetQUOTATIONs";
        public static string QUOT_UPD_ENDPNT = "api/Quotation/PutQUOTATION";
        public static string QUOT_DEL_ENDPNT = "api/Quotation/DeleteQUOTATION";

        public static string RFQ_NEW_ENDPNT = "api/Quotation/PostRFQ";
        public static string RFQ_GET_ENDPNT = "api/Quotation/GetRFQs";
        public static string RFQ_GET_BYID_ENDPNT = "api/Quotation/GetRFQById";
        public static string RFQ_UPD_ENDPNT = "api/Quotation/PutRFQ";
        public static string RFQ_DEL_ENDPNT = "api/Quotation/DeleteRFQ";

        public static string LOC_NEW_ENDPNT = "api/Master/PostLocation";
        public static string LOC_GET_ENDPNT = "api/Master/GetLocations";

        public static string LOOKUP_GET_ENDPNT = "api/Master/GetAllLookup";

    }

    public static class Common
    {
        public static string API_SERVICE_BASE_ADRS = "http://ims.service";
        public static string WEB_APP_BASE_ADRS = "http://ims";

        public static string USER_NEW_ENDPNT = "api/Account/Register";
        public static string ROLE_GET_ENDPNT = "api/AspNetRoles";
    }
}
