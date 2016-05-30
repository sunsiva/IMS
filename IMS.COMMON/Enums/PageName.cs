using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Common.Enums
{
    
    /// <summary>
    /// 
    /// </summary>
    public enum PageName
    {
        Undefined = 0,
        HomePage = 1,
        SearchResultsPage = 2,
        ForSaleLandingPage = 3,
        RentalSearchResultPage = 4,
        NFSLandingPage = 5,
        SoldLandingPage = 6,
        IncompatibleBrowser = 7,
        NewHomesConstructionSrp = 8,
        RentalLandingPage = 9,
        //PromotionalPage = 10,
        FAHStatePage = 11,
        RentalStatePage = 12,
        ForeclosureSrp = 13,
        ForeclosuresLandingPage = 14,
        RentalApartments = 15,
        RentalHousesCondos = 16,        
        PropertyDetail = 17,
        PrintablePropertyDetail = 18,
        CondoBuildingDetail = 19,
        sitemap = 20,
        EstimatePaymentModel = 21,
        NewHomesLandingPage=22,
        NewHomesSearchResultPage=23,
        NewHomesPlanMoveInPage=24,
        PlanDetail=25,
        CommunityDetail=26,
        NFSSearchResultsPage = 27,
        RecSoldSearchResultsPage = 28,        
        StateLandingPage=29,
        AlphaSortPage=30,
        NewConstructionStatePage,
        NewHomesCommunitiesStatePage,
        ForeclosuresStatePage,
        ForRentStatePage,
        ApartmentsStatePage,
        RecentlySoldStatePage,
        RecentlySoldStreetPage,
        NotForSaleStatePage,
        NotForSaleStreetPage,
        MobileLandingPage,
        UserCaptcha,
        LDPError,
        //added for RDCWEB-2458
        FraudAlert,
        RealEstateStatisticsPage,
        ErrorPage,
        SellLandingPage
    }

    public enum PageNameByGEOType
    {
        Undefined = 0,
        ForSaleByCity = 1,
        ForSaleByZip = 2,
        ForSaleByNeighborhood = 3,
        ForSaleByAddress = 4,
        ForSaleByPropertyType = 5, //May be not need this
        RecentlySoldByCity = 6,
        RecentlySoldByZip = 7,
        NewConstructionByCity = 8,
        NewConstructionByZip = 9,
        ForRentByCity = 10,
        ForRentByZip = 11,
        RentalsByApartmentsByCity = 12,
        RentalsByApartmentsByZip = 13,
        RentalsByHCTByZip = 14,
        RentalsByHCTByCity = 15,
        OpenhouseByCity = 16,
        NewestListingsByCity = 17,
        PriceReducedByCity = 18,
        NewHomeCommunitiesByCity = 19,
        NewHomeCommunitiesByZip = 20,
        NotForSaleByCity = 21,
        NotForSaleByZip = 22,
        NotForSaleByNeighborhood = 23,
        NotForSaleByPropertyType = 24,
        NotForSaleByBeds = 25,
        RecentlySoldByBeds = 26,
        RecentlySoldByNeighborhood = 27,
        ForeclosuresByCity = 28,
        ForeclosuresByZip = 29
    }

    public static class PageNameHelper
    {
        public static PageName GetPageNameByPropertyStatus(string criteriaPropertyStatus)
        {   
            PageName pageName;

            switch (criteriaPropertyStatus)
            {
                case "1":
                    pageName = PageName.SearchResultsPage; 
                    break;
                case "2":
                    pageName = PageName.NewHomesConstructionSrp;
                    break;
                case "4":
                    pageName = PageName.NFSSearchResultsPage;
                    break;
                case "8":
                    pageName = PageName.NFSSearchResultsPage;
                    break;
                case "60":
                case "10":
                    pageName = PageName.RentalSearchResultPage;
                    break;
                case "20":
                    pageName = PageName.ForeclosureSrp;
                    break;
                case "40":
                    pageName = PageName.NewHomesSearchResultPage;
                    break;
                default:
                    pageName = PageName.SearchResultsPage;
                    break;
            }

            return pageName;
        }

        //TODO: Mainly for Dart ads. Not all search pages has been implemented. Some require a unique name for sepcific Dart settings
        //Some can share.
        public static PageName MapPathToSearchPageName(string urlPath)
        {
            if (urlPath.Contains("newhomesconstruction"))
            {
                return PageName.NewHomesConstructionSrp;
            }

            if (urlPath.Contains("foreclosure"))
            {
                return PageName.ForeclosureSrp;
            }
            if (urlPath.Contains("newhomecommunities"))
            {
                return PageName.NewHomesSearchResultPage;
            }
            if (urlPath.Contains("soldhomeprices"))
            {
                return PageName.RecSoldSearchResultsPage;
            }
            if (urlPath.Contains("propertyrecord-search"))
            {
                return PageName.NFSSearchResultsPage;
            }

            return PageName.SearchResultsPage;
        }
    }
}

