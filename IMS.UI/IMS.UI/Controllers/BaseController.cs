using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Text;
using IMS.Common.Enums;
using IMS.DataModel.Common;

namespace IMS.UI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : ControllerWithContext
    {

        private string _abProfile;

        /// <summary>
        /// A/B Profile for A/B testing - set by httpmodule <see cref="ABTestingModule" />
        /// </summary>
        public string ABProfile
        {
            get
            {
                if (String.IsNullOrEmpty(_abProfile))
                {
                    _abProfile = ConfigurationManager.AppSettings["DefaultProfile"];
                }
                return _abProfile;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private PageName _pageName;
        public PageName PageName
        {
            get { return _pageName; }
            set
            {
                //Context.HttpContextBase.Items["CurrentPage"] = value;
                _pageName = value;
            }
        }

        //private char _alphaSortLetter;
        //public char AlphaSortLetter
        //{
        //    get
        //    {
        //        return _alphaSortLetter;
        //    }
        //    set
        //    {
        //        _alphaSortLetter = Char.ToUpper(value);
        //        Context.HttpContextBase.Items["CurrentAlphaSortLetter"] = _alphaSortLetter;
        //    }
        //}

        //private TrackingChannel _trackingChannel;
        //public TrackingChannel TrackingChannel
        //{
        //    get { return _trackingChannel; }
        //    set
        //    {
        //        Context.HttpContextBase.Items["CurrentChannel"] = value;
        //        _trackingChannel = value;
        //    }
        //}

        //public JSHelper JSHelper { get; set; }
        
       /// <summary>
       /// Hide System.Web.Mvc.Controller.HttpContext, since we can't set this during our widget partial updates.
       /// </summary>
       //public new HttpContextBase HttpContext
       //{
       //   get
       //   {
       //      return Context.HttpContextBase;
       //   }
       //}

       #region Override Methods

        protected override void InitializeContext(HttpContextBase httpContext)
        {
            base.InitializeContext(httpContext);
            //InitializeJSHelper();
            //ModelRepository = new ModelRepository(Context);
        }

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/system.web.mvc.controller.onactionexecuting(v=vs.118).aspx
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            #region Check Browser Version

            HttpBrowserCapabilitiesBase httpBrowserCapabilities = Request.Browser;
            //IsMobileDevice = httpBrowserCapabilities.IsMobileDevice;
            //BrowserType = httpBrowserCapabilities.Type;

            #endregion

            //var queryString = Context.HttpContextBase.Request.QueryString;

            //IsDebug = queryString["debug"] != null && queryString["debug"] == "1";
            //IsProfiler = queryString["profiler"] != null && queryString["profiler"] == "on";

            //if (IsProfiler)
            //    MiniProfiler.Start();

            AddStyleSheets();
            //AddJavaScripts();
        }

        #endregion


        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public BaseController()
        {

            #region Host Deprecation settings
            //ViewBag.SiteVariables = this.SiteVariables.ToJSON();

            #endregion

        }
        
        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        /// <summary>
        /// Add Common and Page specific CSSs. More than that should not be encouraged.
        /// Please try to load any extra CSS on demand, since it is cached on Move CDN, getting a CSS is pretty fast.
        /// </summary>
        private void AddStyleSheets()
        {
            //string cssURL = "<link rel='stylesheet' type='text/css' href='{0}/{1}.css' />";
            //StringBuilder sb = new StringBuilder();
            //var currentCss = GetCSSName();
            //sb.AppendFormat(cssURL, this.SiteVariables.StaticVersion1, currentCss);
            //ViewBag.CSSUrls = sb.ToString();
        }

        public void AddErrorStyleSheets(string ErrorStylesheetName)
        {
            ViewBag.ErrorPageCSSUrls = "<link rel='stylesheet' type='text/css' href='" + StaticLibraryPath() + ErrorStylesheetName + ".css' />";
        }

        protected string GetCSSName()
        {
            var isDev = ConfigurationManager.AppSettings["Environment"].ToLower() == "dev";
            var cssMode = ConfigurationManager.AppSettings["CSSMode"];
            cssMode = String.IsNullOrWhiteSpace(cssMode) ? "common" : cssMode;
            return String.Format("{0}{1}", cssMode, isDev ? "-dev" : "");
        }

        protected string StaticLibraryPath()
        {            
            return String.Format("http://{0}{1}/lib/rdc-org/{2}/", ConfigurationManager.AppSettings["staticBaseHost1"], "static.move.com", ConfigurationManager.AppSettings["MVCWebApplicationVersion"]);     
        }

        #endregion

        #region Protected Members

        protected void WriteDebug(List<ModelMessage> messages)
        {
            Response.Write("DEBUG BEGINS: <br />" + messages.Select(m => m.Message).ToArray()+("<br />") + "</br>DEBUG ENDS");
        }

        #endregion Protected Members
    }

}
