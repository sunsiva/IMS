using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IMS.Common.Interfaces
{
    public interface IContext
    {
       //IWebRequester WebRequester { get; }
      /// <summary>
      /// Retrieves the HttpContextBase. Use this instead of HttpContext whenever you can.
      /// </summary>
      //HttpContextBase HttpContextBase { get; } 
      //HttpContext HttpContext { get; }
    }
}
