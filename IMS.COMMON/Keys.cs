using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Common
{
    /// <summary>
    /// Enum - Cache keys for maintaining data,
    /// </summary>
    public enum CacheKey
    {
        Uid,
        RoleName,
        UserName,
        VendorId,
        CANSearchHome
    };

    public enum Lookup
    {
        CallPreference=0,
        Channel=1,
        CompanyStatus=2,
        CompanyType=3,
        CreditLimit=4,
        CurrencyCode=5,
        CustomerType=6,
        DiscountBand=7,
        LineOfBusiness=8,
        Ownership=9,
        PaymentTerm=10,
        PriceBand=11,
        ShipmentTerm=12,
        TaxCode=13,
        TaxCode1=14,
        TaxCode2=15,
        TaxCode3=16,
    };
}
