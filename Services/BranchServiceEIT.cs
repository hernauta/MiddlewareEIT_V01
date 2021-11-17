using Microsoft.Extensions.Configuration;
using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Configuration;

namespace MiddlewareEIT.API.Services
{
    public class BranchServiceEIT
    {

        public static string GetRequestBranch(BranchDTO branch)
        {


            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportBranch");
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
                @"      <tem:ImportBranch>" + "\n" +
                @"         <tem:branchIfzFun>" + "\n" +
                @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                @"            <tem:ListBranchIfz>" + "\n" +
                @"               <tem:BranchIfz>" + "\n" +
                @"                  <tem:CustomerCode>" + branch.CustomerCode + "</tem:CustomerCode>" + "\n" +
                @"                  <tem:OwnCode>" + branch.OwnCode + "</tem:OwnCode>" + "\n" +
                @"                  <tem:Code>" + branch.BranchCode + "</tem:Code>" + "\n" +
                @"                  <tem:Name>" + branch.BranchName + "</tem:Name>" + "\n" +
                @"                  <tem:BranchAddress>" + branch.BranchAddress + "</tem:BranchAddress>" + "\n" +
                @"                  <tem:CountryName>" + branch.CountryName + "</tem:CountryName>" + "\n" +
                @"                  <tem:StateName>" + branch.StateName + "</tem:StateName>" + "\n" +
                @"                  <tem:CityName>" + branch.CityName + "</tem:CityName>" + "\n" +
                @"                  <tem:Distance>" + branch.Distance + "</tem:Distance>" + "\n" +
                @"                  <tem:Phone>" + branch.Phone + "</tem:Phone>" + "\n" +
                @"                  <tem:SpecialField1>" + branch.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                @"                  <tem:SpecialField2>" + branch.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                @"                  <tem:SpecialField3>" + branch.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                @"                  <tem:SpecialField4>" + branch.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                @"                  <tem:StateInterface>" + branch.StateInterface + "</tem:StateInterface>" + "\n" +
                @"                  <tem:DateCreatedERP>" + branch.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                @"                  <tem:DateReadWMS>" + branch.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                @"               </tem:BranchIfz>" + "\n" +
                @"            </tem:ListBranchIfz>" + "\n" +
                @"         </tem:branchIfzFun>" + "\n" +
                @"      </tem:ImportBranch>" + "\n" +
                @"   </soapenv:Body>" + "\n" +
                @"</soapenv:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return (response.Content);
        }
    }
}
