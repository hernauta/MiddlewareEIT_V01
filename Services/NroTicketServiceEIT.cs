using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Configuration;

namespace MiddlewareEIT.API.Services
{
    public class NroTicketServiceEIT
    {
        public static string GetRequestNroTicketImp(NroTicketDTO customer)
        {
            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ConfirmNroTicketImport");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml");
            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">" + "\n" +
            @"   <soapenv:Header/>" + "\n" +
            @"   <soapenv:Body>" + "\n" +
            @"      <tem:ConfirmNroTicketImport>" + "\n" +
            @"         <tem:nroTicket>" + customer.NumeroTicket + "</tem:nroTicket>" + "\n" +
            @"      </tem:ConfirmNroTicketImport>" + "\n" +
            @"   </soapenv:Body>" + "\n" +
            @"</soapenv:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return (response.Content);

        }
        public static string GetRequestNroTicketExp(NroTicketDTO customer)
        {
            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsExportIfz.asmx?op=ConfirmNroTicketExport");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml");
            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">" + "\n" +
            @"   <soapenv:Header/>" + "\n" +
            @"   <soapenv:Body>" + "\n" +
            @"      <tem:ConfirmNroTicketExport>" + "\n" +
            @"         <tem:nroTicket>" + customer.NumeroTicket + "</tem:nroTicket>" + "\n" +
            @"      </tem:ConfirmNroTicketExport>" + "\n" +
            @"   </soapenv:Body>" + "\n" +
            @"</soapenv:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return (response.Content);
        }
    }
}
