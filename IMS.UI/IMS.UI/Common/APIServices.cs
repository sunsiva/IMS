using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IMS.UI.Common
{
    public class APIServices
    {
        Uri _hostBaseAdress;
        Uri _webAppBaseAdress;

        public APIServices()
        {
            _hostBaseAdress = new Uri(Constants.serviceBaseAddress);
            _webAppBaseAdress = new Uri(Constants.webAppBaseAddress);
        }

        public HttpClient GetMyClient()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _hostBaseAdress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }
        }
    }
}