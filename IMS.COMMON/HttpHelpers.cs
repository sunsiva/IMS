using System;
using System.Linq;
using System.Net.Http;

namespace Serializer
{
 public class HttpHelpers
 {
  public void HttpInvoke(HttpMethods httpMethod, string url)
  {
   using (var httpClass = new HttpClass(httpMethod, url))
   {
    httpClass.Invoke();
   }
  }
  public void HttpInvoke(HttpMethods httpMethod, string url, string content)
  {

   using (var httpClass = new HttpClass(httpMethod, url, content))
   {
    httpClass.Invoke();
   }
  }
  public HttpResponseMessage GetHttpResponseMessage(HttpMethods httpMethod, string url, string content)
  {

   HttpResponseMessage _response;

   using (var httpClass = new HttpClass(httpMethod, url, content))
   {
    httpClass.Invoke();
    _response = httpClass.GetHttpResponseMessage();
   }

   return _response;
  }
  public HttpResponseMessage GetHttpResponseMessage(HttpMethods httpMethod, string url)
  {

   HttpResponseMessage _response;

   using (var httpClass = new HttpClass(httpMethod, url))
   {
    httpClass.Invoke();
    _response = httpClass.GetHttpResponseMessage();
   }

   return _response;
  }
  public string GetHttpContent(string url) {

   string content;
   using (var httpClass = new HttpClass(HttpMethods.GET, url))
   {
    httpClass.Invoke();
    content = httpClass.GetResponseContent();
   }
   return content;
  }
 }
}
