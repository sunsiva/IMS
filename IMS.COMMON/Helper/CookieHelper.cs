using IMS.Common.Interfaces;
using System;
using System.Collections.Generic;
//using HttpCookie = System.Web.HttpCookie;

namespace IMS.Common.Helpers
{

   public class CookieHelper : IHasContext
   {
      private const string DEFAULT_COOKIE_DOMAIN = "ZENIMS.com";

      public CookieHelper(IContext context)
      {
         Context = context;
      }

      public static string GetCookieDomain(string Host)
      {
         return Host.EndsWith(DEFAULT_COOKIE_DOMAIN, StringComparison.CurrentCultureIgnoreCase) ? DEFAULT_COOKIE_DOMAIN : Host;
      }
       
      //NOTE:-COMMENTED FOR REFERENCE:
      //public static string CookieRecentSearch = ConfigurationManager.AppSettings["CookieRecentSearch"];
      //public static string CookieRecentViewed = ConfigurationManager.AppSettings["CookieRecentViewed"];
      //private static Int32 CookieRecentSearchLimit = Convert.ToInt32(ConfigurationManager.AppSettings["CookieRecentViewedLimit"]);
      //private static Int32 CookieRecentViewedLimit = Convert.ToInt32(ConfigurationManager.AppSettings["CookieRecentViewedLimit"]); //Not sure why CookieRecentSearchLimit is taking value from RecentViewed Limit!!
      //private static string[] RecentSearchCookieFields = new string[] {
      //          CriteriaNames.Location, 
      //          CriteriaNames.PropertyType, 
      //          CriteriaNames.Price,
      //          CriteriaNames.Beds,
      //          CriteriaNames.Baths,
      //          CriteriaNames.PropertyStatus, 
      //          CriteriaNames.MLSListingID,
      //          CriteriaNames.RentalPropertyTypes,
      //          CriteriaNames.Miles,
      //          CriteriaNames.PetPolicy
      //  };

      /// <summary>
      /// Set Cookie is primary used on the Search Results Page and Listing Detail Page to set
      /// Recent Search and Recent View Cookies.
      /// </summary>
      /// <param name="cookieName">Cookie Name to Set</param>
      /// <param name="cookieLimit">Limit the cookie to 'x' amount</param>
      /// <param name="cookieValue">Cookie Value to Set</param>
      /// <param name="cookieDelimiter"></param>
      /// <param name="persistOldValues"></param>
      //public void SetCookie(String cookieName, int cookieLimit, String cookieValue, char cookieDelimiter, bool persistOldValues = true)
      //{
      //   String orginalCookieValue = String.Empty;
      //   HttpCookie currentCookie = Context.HttpContextBase.Request.Cookies[cookieName];
      //   List<String> listOfCookieValue = new List<string>();
      //   if (persistOldValues)
      //   {
      //      if (currentCookie == null)
      //      {
      //         currentCookie = new HttpCookie(cookieName);
      //      }
      //      else
      //      {
      //         orginalCookieValue = currentCookie.Value.ToString();
      //      }

      //      if (!string.IsNullOrEmpty(orginalCookieValue))
      //      {
      //         foreach (string url in orginalCookieValue.Split(cookieDelimiter))
      //         {
      //            //decoding for search purposes
      //            listOfCookieValue.Add(Context.HttpContextBase.Server.UrlDecode(url));
      //         }
      //      }
      //   }

      //   //Add to the top of the list 
      //   //I don't know any way of doing this without removing and adding back...any clever ideas are welcomed
      //   if (listOfCookieValue.Contains(cookieValue))
      //   {
      //      listOfCookieValue.Remove(cookieValue);
      //      listOfCookieValue.Add(cookieValue);
      //   }
      //   else
      //   {
      //      listOfCookieValue.Add(cookieValue);
      //   }

      //   // Remove the First Object in the queue
      //   if (listOfCookieValue.Count > cookieLimit)
      //   {
      //      listOfCookieValue.RemoveAt(0);
      //   }

      //   String[] arrCookie = new String[listOfCookieValue.Count];


      //   int j = 0;
      //   foreach (string url in listOfCookieValue)
      //   {
      //      arrCookie[j] = Context.HttpContextBase.Server.UrlEncode(url);
      //      j++;
      //   }

      //   // send the new cookie
      //   //arrCookie = listOfCookieValue.ToArray();
      //   string CookieValue = String.Join(Convert.ToString(cookieDelimiter), arrCookie);
      //   if (orginalCookieValue != CookieValue)
      //   {
      //      currentCookie.HttpOnly = false;
      //      currentCookie.Expires = DateTime.Now.AddYears(1);
      //      currentCookie.Domain = GetCookieDomain(Context.HttpContextBase.Request.Url.Host);
      //      currentCookie.Value = String.Join(Convert.ToString(cookieDelimiter), arrCookie);
      //      Context.HttpContextBase.Response.Cookies.Add(currentCookie);
      //   }

      //}

      //public string GetWidgetClicked()
      //{
      //   var result = "";
      //   if (Context.HttpContextBase == null) return result;
      //   if (Context.HttpContextBase.Request.Cookies["widgetClicked"] == null ||
      //       string.IsNullOrEmpty(Context.HttpContextBase.Request.Cookies["widgetClicked"].Value)) return result;

      //   var value = Context.HttpContextBase.Request.Cookies["widgetClicked"].Value.ToLower();
      //   if (value == "fhtop")
      //      result = "FeaturedHome";
      //   else if (value == "fhbottom")
      //      result = "FeaturedHomeBottom";
      //   else if (value == "recommendation")
      //      result = "Recommendation";
      //   else if (value == "recommendationldp")
      //      result = "RecommendationLDP";
      //   else if (value == "nearbyhomesforsale")
      //      result = "NearbyHomesForSale";
      //   else if (value == "recently_added")
      //      result = "RecentlyAdded";
      //   return result;
      //}

      /// <summary>
      /// Clears an existing cookie from the user's brower
      /// </summary>
      /// <param name="name">Name of the cookie</param>
      //public void ClearProfileCookie(string name)
      //{
      //   HttpCookie ck = new HttpCookie(name);
      //   ck.Expires = DateTime.Now.AddDays(-1);
      //   SetCookieDomain("ZENIMS.com", ck);
      //}

      /// <summary>
      /// Sets the cookie's domain
      /// </summary>
      /// <param name="domain">The domain to be set</param>
      /// <param name="ck">The cookie</param>
      /// <remarks>Removes local environment domain when applicable</remarks>
      //public static void SetCookieDomain(string domain, HttpCookie ck)
      //{
      //   if (!string.IsNullOrEmpty(domain))
      //      ck.Domain = domain;
      //   else
      //   {
      //      //string prefix = MV.SharedServices.EnvironmentUtilities.MachineConfig.returnAppSetting("regHost");
      //      //if (!string.IsNullOrEmpty(prefix) && Context.HttpContextBase.Request.Url.Host.StartsWith(prefix))
      //      //    ck.Domain = Context.HttpContextBase.Request.Url.Host.Substring(prefix.Length);
      //   }
      //}

      public IContext Context { get; private set; }
   }
}
