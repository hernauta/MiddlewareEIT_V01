using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Configuration;

namespace MiddlewareEIT.API.Services
{
    public class ExportMovementAdjustServiceEIT
    {
        public static string GetRequestExportMovementAdjust(ExportMovementAdjustDTO exportMovementAdjust)
        {

            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsExportIfz.asmx?op=ExportMovementAdjust");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml");
            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">" + "\n" +
            @"   <soapenv:Header>" + "\n" +
            @"      <tem:AuthWS>" + "\n" +
            @"         <!--Optional:-->" + "\n" +
            @"         <tem:userName>" + ConfigurationManager.AppSettings["USERNAME_EIT"] + "</tem:userName>" + "\n" +
            @"         <tem:password>" + ConfigurationManager.AppSettings["PASSWORD_EIT"] + "</tem:password>" + "\n" +
            @"      </tem:AuthWS>" + "\n" +
            @"   </soapenv:Header>" + "\n" +
            @"   <soapenv:Body>" + "\n" +
            @"      <tem:ExportMovementAdjust>" + "\n" +
            @"         <tem:QtyMovementAdjustToRet>" + exportMovementAdjust.QtyMovementAdjustToRet + "</tem:QtyMovementAdjustToRet>" + "\n" +
            @"      </tem:ExportMovementAdjust>" + "\n" +
            @"   </soapenv:Body>" + "\n" +
            @"</soapenv:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return (response.Content);
        }
    }
}
