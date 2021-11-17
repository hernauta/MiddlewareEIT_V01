using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareEIT.API.Services
{
    public class DispatchServiceEIT
    {
        public static string GetRequestDispatch(ExportDispatchDTO QtyDispatchToRet)
        {

            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsExportIfz.asmx?op=ExportDispatch");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml");
            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">            " + "\n" +
            @"   <soapenv:Header>" + "\n" +
            @"      <tem:AuthWS>" + "\n" +
            @"         <tem:userName>" + ConfigurationManager.AppSettings["USERNAME_EIT"] + "</tem:userName>" + "\n" +
            @"         <tem:password>" + ConfigurationManager.AppSettings["PASSWORD_EIT"] + "</tem:password>" + "\n" +
            @"      </tem:AuthWS>" + "\n" +
            @"   </soapenv:Header>" + "\n" +
            @"   <soapenv:Body>" + "\n" +
            @"      <tem:ExportDispatch>" + "\n" +
            @"         <tem:QtyDispatchToRet>" + QtyDispatchToRet.QtyDispatchToRet + "</tem:QtyDispatchToRet>" + "\n" +
            @"      </tem:ExportDispatch>" + "\n" +
            @"   </soapenv:Body>" + "\n" +
            @"</soapenv:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return (response.Content);
        }
    }
}
