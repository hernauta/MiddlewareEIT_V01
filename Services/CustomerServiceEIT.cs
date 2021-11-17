using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareEIT.API.Services
{
    public class CustomerServiceEIT
    {
        public static string GetRequestCustomer2(CustomerDTO customer)
        {
            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportCustomer");
            client.Timeout = -1;
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
                @"      <tem:ImportCustomer>" + "\n" +
                @"         <tem:customerIfzFun>" + "\n" +
                @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                @"            <tem:ListCustomerIfz>" + "\n" +
                @"               <tem:CustomerIfz>" + "\n" +
                @"                  <tem:OwnCode>" + customer.OwnCode + "</tem:OwnCode>" + "\n" +
                @"                  <tem:Code>" + customer.CustomerCode + "</tem:Code>" + "\n" +
                @"                  <tem:Name>" + customer.CustomerName + "</tem:Name>" + "\n" +
                @"                  <tem:Address1Fact>" + customer.Address1Fact + "</tem:Address1Fact>" + "\n" +
                @"                  <tem:Address2Fact>" + customer.Address2Fact + "</tem:Address2Fact>" + "\n" +
                @"                  <tem:CountryNameFact>" + customer.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                @"                  <tem:StateNameFact>" + customer.StateNameFact + "</tem:StateNameFact>" + "\n" +
                @"                  <tem:CityNameFact>" + customer.CityNameFact + "</tem:CityNameFact>" + "\n" +
                @"                  <tem:PhoneFact>" + customer.PhoneFact + "</tem:PhoneFact>" + "\n" +
                @"                  <tem:FaxFact>" + customer.FaxFact + "</tem:FaxFact>" + "\n" +
                @"                  <tem:Address1Delv>" + customer.Address1Delv + "</tem:Address1Delv>" + "\n" +
                @"                  <tem:Address2Delv>" + customer.Address2Delv + "</tem:Address2Delv>" + "\n" +
                @"                  <tem:CountryNameDelv>" + customer.CountryNameDelv + "</tem:CountryNameDelv>" + "\n" +
                @"                  <tem:StateNameDelv>" + customer.StateNameDelv + "</tem:StateNameDelv>" + "\n" +
                @"                  <tem:CityNameDelv>" + customer.CityNameDelv + "</tem:CityNameDelv>" + "\n" +
                @"                  <tem:PhoneDelv>" + customer.PhoneDelv + "</tem:PhoneDelv>" + "\n" +
                @"                  <tem:FaxDelv>" + customer.FaxDelv + "</tem:FaxDelv>" + "\n" +
                @"                  <tem:Email>" + customer.Email + "</tem:Email>" + "\n" +
                @"                  <tem:Priority>" + customer.Priority + "</tem:Priority>" + "\n" +
                @"                  <tem:TimeExpected>" + customer.TimeExpected + "</tem:TimeExpected>" + "\n" +
                @"                  <tem:ExpirationDays>" + customer.ExpirationDays + "</tem:ExpirationDays>" + "\n" +
                @"                  <tem:SpecialField1>" + customer.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                @"                  <tem:SpecialField2>" + customer.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                @"                  <tem:SpecialField3>" + customer.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                @"                  <tem:SpecialField4>" + customer.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                @"                  <tem:StateInterface>" + customer.StateInterface + "</tem:StateInterface>" + "\n" +
                @"                  <tem:DateCreatedERP>" + customer.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                @"                  <tem:DateReadWMS>" + customer.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                @"               </tem:CustomerIfz>" + "\n" +
                @"            </tem:ListCustomerIfz>" + "\n" +
                @"         </tem:customerIfzFun>" + "\n" +
                @"      </tem:ImportCustomer>" + "\n" +
                @"   </soapenv:Body>" + "\n" +
                @"</soapenv:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return (response.Content);
        }
    }
}
