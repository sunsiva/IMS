using IMS.Common.Helpers;
using IMS.Common.Interfaces;
using System.Web;
using System.Web.Mvc;

namespace IMS.UI.Controllers
{
    public class ControllerWithContext : Controller, IHasContext
    {
        public IContext Context { get; protected set; }

        protected virtual void InitializeContext(HttpContextBase httpContext)
        {
           // Context = new Common.Context(httpContext);

        }

        public void OnPartialUpdate(ActionExecutingContext filterContext)
        {
            InitializeContext(filterContext.HttpContext);
        }

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/system.web.mvc.controller.onactionexecuting(v=vs.118).aspx
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            InitializeContext(filterContext.HttpContext);
        }

        private CookieHelper _cookieHelper;

        protected CookieHelper CookieHelper
        {
           get
           {  // this allows us to defer creation of a CookieHelper until we have an IContext

              if (null == Context)
                 return _cookieHelper;

              return _cookieHelper ?? (_cookieHelper = new CookieHelper(Context));
           }
        }

    }
}