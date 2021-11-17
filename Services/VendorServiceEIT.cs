using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Configuration;
using MiddlewareEIT.BL.Models.XMLs;

namespace MiddlewareEIT.API.Services
{
    public class VendorServiceEIT
    {
        public static string GetRequestVendor(VendorDTO vendor)
        {
            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportVendor");
            client.Timeout = -1;
            var XmlCargaAudit = new XmlCargaAudit();
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml");
            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">" + "\n" +
            @"   <soapenv:Header>" + "\n" +
            @"      <tem:AuthWS>" + "\n" +
            @"         <tem:userName>" + ConfigurationManager.AppSettings["USERNAME_EIT"] + "</tem:userName>" + "\n" +
            @"         <tem:password>" + ConfigurationManager.AppSettings["PASSWORD_EIT"] + "</tem:password>" + "\n" +
            @"      </tem:AuthWS>" + "\n" +
            @"   </soapenv:Header>" + "\n" +
            @"   <soapenv:Body>" + "\n" +
            @"      <tem:ImportVendor>" + "\n" +
            @"         <tem:vendorIfzFun>" + "\n" +
            @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
            @"            <tem:ListVendorIfz>" + "\n" +
            @"               <tem:VendorIfz>" + "\n" +
            @"                  <tem:OwnCode>" + vendor.OwnCode + "</tem:OwnCode>" + "\n" +
            @"                  <tem:Code>" + vendor.VendorCode + "</tem:Code>" + "\n" +
            @"                  <tem:Name>" + vendor.VendorName + "</tem:Name>" + "\n" +
            @"                  <tem:Address1>" + vendor.Address1 + "</tem:Address1>" + "\n" +
            @"                  <tem:Address2>" + vendor.Address2 + "</tem:Address2>" + "\n" +
            @"                  <tem:CountryName>" + vendor.CountryName + "</tem:CountryName>" + "\n" +
            @"                  <tem:StateName>" + vendor.StateName + "</tem:StateName>" + "\n" +
            @"                  <tem:CityName>" + vendor.CityName + "</tem:CityName>" + "\n" +
            @"                  <tem:Phone>" + vendor.Phone + "</tem:Phone>" + "\n" +
            @"                  <tem:Fax>" + vendor.Fax + "</tem:Fax>" + "\n" +
            @"                  <tem:Email>" + vendor.Email + "</tem:Email>" + "\n" +
            @"                  <tem:HasInspection>" + vendor.HasInspection + "</tem:HasInspection>" + "\n" +
            @"                  <tem:SpecialField1>" + vendor.SpecialField1 + "</tem:SpecialField1>" + "\n" +
            @"                  <tem:SpecialField2>" + vendor.SpecialField2 + "</tem:SpecialField2>" + "\n" +
            @"                  <tem:SpecialField3>" + vendor.SpecialField3 + "</tem:SpecialField3>" + "\n" +
            @"                  <tem:SpecialField4>" + vendor.SpecialField4 + "</tem:SpecialField4>" + "\n" +
            @"                  <tem:StateInterface>" + vendor.StateInterface + "</tem:StateInterface>" + "\n" +
            @"                  <tem:DateCreatedERP>" + vendor.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
            @"                  <tem:DateReadWMS>" + vendor.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
            @"               </tem:VendorIfz>" + "\n" +
            @"            </tem:ListVendorIfz>" + "\n" +
            @"         </tem:vendorIfzFun>" + "\n" +
            @"      </tem:ImportVendor>" + "\n" +
            @"   </soapenv:Body>" + "\n" +
            @"</soapenv:Envelope>";
            request.AddParameter("application/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            XmlCargaAudit.xmlaudit = body.ToString();

            try
            {

                Console.WriteLine(response.Content);
                return (response.Content);

            }
            catch (Exception ex)
            {

                var resultf = response.ToString();
                return (resultf);
            }
        }
    }
}
