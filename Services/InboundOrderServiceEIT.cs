using RestSharp;
using System;
using System.Configuration;
using RmiLibReversoEIT.Services;
using MiddlewareEIT.BL.DTOs;

namespace MiddlewareEIT.API.Services
{
    public class InboundOrderServiceEIT
    {
        public static string GetRequestInboundOrder(InboundOrderDTO inboundOrder, string libreria)
        {
            if (libreria == "RmiLibFalabellaEIT")
            {
                if (inboundOrder.ListInboundOrderDetailDTO.Count > 0)
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportInboundOrder");
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
                        @"      <tem:ImportInboundOrder>" + "\n" +
                        @"         <tem:inboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListInboundOrderIfz>" + "\n" +
                        @"               <tem:InboundOrderIfz>" + "\n" +
                        @"                  <tem:HasIssues>1</tem:HasIssues>" + "\n" +
                        @"                  <tem:WhsCode>" + inboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + inboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + inboundOrder.InboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:InboundTypeCode>" + inboundOrder.InboundTypeCode + "</tem:InboundTypeCode>" + "\n" +
                        @"                  <tem:OrderComment>" + inboundOrder.OrderComment + "</tem:OrderComment>" + "\n" +
                        @"                  <tem:VendorCode>" + inboundOrder.VendorCode + "</tem:VendorCode>" + "\n" +
                        @"                  <tem:DateExpected>" + inboundOrder.DateExpected + "</tem:DateExpected>" + "\n" +
                        @"                  <tem:EmissionDate>" + inboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + inboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:Status>" + inboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:OutboundNumberSource>" + inboundOrder.OutboundNumberSource + "</tem:OutboundNumberSource>" + "\n" +
                        @"                  <tem:IsAsn>" + inboundOrder.PercentLpnInspection + "</tem:IsAsn>" + "\n" +
                        @"                  <tem:PercentLpnInspection>" + inboundOrder.PercentLpnInspection + "</tem:PercentLpnInspection>" + "\n" +
                        @"                  <tem:PercentQA>" + inboundOrder.PercentQa + "</tem:PercentQA>" + "\n" +
                        @"                  <tem:ShiftNumber>" + inboundOrder.ShiftNumber + "</tem:ShiftNumber>" + "\n" +
                        @"                  <tem:SpecialField1>1</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>1</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>1</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>1</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + inboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + inboundOrder.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + inboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                  <tem:InboundDetailsIfz>" + "\n" +
                        @"                     <tem:InboundDetailIfz>" + "\n" +
                        @"                        <tem:InboundOrderIfz/>" + "\n" +
                        @"                        <tem:LineNumber>" + inboundOrder.ListInboundOrderDetailDTO[0].LineNumber + "</tem:LineNumber>" + "\n" +
                        @"                        <tem:LineCode>" + inboundOrder.ListInboundOrderDetailDTO[0].LineCode + "</tem:LineCode>" + "\n" +
                        @"                        <tem:ItemCode>" + inboundOrder.ListInboundOrderDetailDTO[0].ItemCode + "</tem:ItemCode>" + "\n" +
                        @"                        <tem:CtgCode>" + inboundOrder.ListInboundOrderDetailDTO[0].CtgCode + "</tem:CtgCode>" + "\n" +
                        @"                        <tem:ItemQty>" + inboundOrder.ListInboundOrderDetailDTO[0].ItemQty + "</tem:ItemQty>" + "\n" +
                        @"                        <tem:Status>" + inboundOrder.ListInboundOrderDetailDTO[0].Status + "</tem:Status>" + "\n" +
                        @"                        <tem:LineComment>" + inboundOrder.ListInboundOrderDetailDTO[0].LineComment + "</tem:LineComment>" + "\n" +
                        @"                        <tem:FifoDate>" + inboundOrder.ListInboundOrderDetailDTO[0].FifoDate + "</tem:FifoDate>" + "\n" +
                        @"                        <tem:ExpirationDate>" + inboundOrder.ListInboundOrderDetailDTO[0].ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                        <tem:FabricationDate>" + inboundOrder.ListInboundOrderDetailDTO[0].FabricationDate + "</tem:FabricationDate>" + "\n" +
                        @"                        <tem:LotNumber>" + inboundOrder.ListInboundOrderDetailDTO[0].LotNumber + "</tem:LotNumber>" + "\n" +
                        @"                        <tem:LpnCode>" + inboundOrder.ListInboundOrderDetailDTO[0].LpnCode + "</tem:LpnCode>" + "\n" +
                        @"                        <tem:Price>" + inboundOrder.ListInboundOrderDetailDTO[0].Price + "</tem:Price>" + "\n" +
                        @"                        <tem:StateInterface>" + inboundOrder.ListInboundOrderDetailDTO[0].StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                        <tem:DateCreatedERP>" + inboundOrder.ListInboundOrderDetailDTO[0].DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                        <tem:DateReadWMS>" + inboundOrder.ListInboundOrderDetailDTO[0].DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                     </tem:InboundDetailIfz>" + "\n" +
                        @"                  </tem:InboundDetailsIfz>" + "\n" +
                        @"               </tem:InboundOrderIfz>" + "\n" +
                        @"            </tem:ListInboundOrderIfz>" + "\n" +
                        @"         </tem:inboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportInboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
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
                else
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportInboundOrder");
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
                        @"      <tem:ImportInboundOrder>" + "\n" +
                        @"         <tem:inboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListInboundOrderIfz>" + "\n" +
                        @"               <tem:InboundOrderIfz>" + "\n" +
                        @"                  <tem:HasIssues>1</tem:HasIssues>" + "\n" +
                        @"                  <tem:WhsCode>" + inboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + inboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + inboundOrder.InboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:InboundTypeCode>" + inboundOrder.InboundTypeCode + "</tem:InboundTypeCode>" + "\n" +
                        @"                  <tem:OrderComment>" + inboundOrder.OrderComment + "</tem:OrderComment>" + "\n" +
                        @"                  <tem:VendorCode>" + inboundOrder.VendorCode + "</tem:VendorCode>" + "\n" +
                        @"                  <tem:DateExpected>" + inboundOrder.DateExpected.ToString() + "</tem:DateExpected>" + "\n" +
                        @"                  <tem:EmissionDate>" + inboundOrder.EmissionDate.ToString() + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + inboundOrder.ExpirationDate.ToString() + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:Status>" + inboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:OutboundNumberSource>" + inboundOrder.OutboundNumberSource + "</tem:OutboundNumberSource>" + "\n" +
                        @"                  <tem:IsAsn>" + inboundOrder.IsAsn + "</tem:IsAsn>" + "\n" +
                        @"                  <tem:PercentLpnInspection>" + inboundOrder.PercentLpnInspection + "</tem:PercentLpnInspection>" + "\n" +
                        @"                  <tem:PercentQA>" + inboundOrder.PercentQa + "</tem:PercentQA>" + "\n" +
                        @"                  <tem:ShiftNumber>" + inboundOrder.ShiftNumber + "</tem:ShiftNumber>" + "\n" +
                        @"                  <tem:SpecialField1>" + inboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>" + inboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>" + inboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>" + inboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + inboundOrder.StateInterface.ToString() + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + inboundOrder.DateCreatedERP.ToString() + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + inboundOrder.DateReadWMS.ToString() + "</tem:DateReadWMS>" + "\n" +
                        @"               </tem:InboundOrderIfz>" + "\n" +
                        @"            </tem:ListInboundOrderIfz>" + "\n" +
                        @"         </tem:inboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportInboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
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
            else if (libreria == "RmiLibReversoEIT")
            {
                if (inboundOrder.ListInboundOrderDetailDTO.Count > 0)
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportInboundOrder");
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
                        @"      <tem:ImportInboundOrder>" + "\n" +
                        @"         <tem:inboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListInboundOrderIfz>" + "\n" +
                        @"               <tem:InboundOrderIfz>" + "\n" +
                        @"                  <tem:HasIssues>1</tem:HasIssues>" + "\n" +
                        @"                  <tem:WhsCode>" + inboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + inboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + inboundOrder.InboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:InboundTypeCode>" + inboundOrder.InboundTypeCode + "</tem:InboundTypeCode>" + "\n" +
                        @"                  <tem:OrderComment>" + inboundOrder.OrderComment + "</tem:OrderComment>" + "\n" +
                        @"                  <tem:VendorCode>" + inboundOrder.VendorCode + "</tem:VendorCode>" + "\n" +
                        @"                  <tem:DateExpected>" + inboundOrder.DateExpected + "</tem:DateExpected>" + "\n" +
                        @"                  <tem:EmissionDate>" + inboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + inboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:Status>" + inboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:OutboundNumberSource>" + inboundOrder.OutboundNumberSource + "</tem:OutboundNumberSource>" + "\n" +
                        @"                  <tem:IsAsn>" + inboundOrder.PercentLpnInspection + "</tem:IsAsn>" + "\n" +
                        @"                  <tem:PercentLpnInspection>" + inboundOrder.PercentLpnInspection + "</tem:PercentLpnInspection>" + "\n" +
                        @"                  <tem:PercentQA>" + inboundOrder.PercentQa + "</tem:PercentQA>" + "\n" +
                        @"                  <tem:ShiftNumber>" + inboundOrder.ShiftNumber + "</tem:ShiftNumber>" + "\n" +
                        @"                  <tem:SpecialField1>1</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>1</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>1</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>1</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + inboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + inboundOrder.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + inboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                  <tem:InboundDetailsIfz>" + "\n" +
                        @"                     <tem:InboundDetailIfz>" + "\n" +
                        @"                        <tem:InboundOrderIfz/>" + "\n" +
                        @"                        <tem:LineNumber>" + inboundOrder.ListInboundOrderDetailDTO[0].LineNumber + "</tem:LineNumber>" + "\n" +
                        @"                        <tem:LineCode>" + inboundOrder.ListInboundOrderDetailDTO[0].LineCode + "</tem:LineCode>" + "\n" +
                        @"                        <tem:ItemCode>" + inboundOrder.ListInboundOrderDetailDTO[0].ItemCode + "</tem:ItemCode>" + "\n" +
                        @"                        <tem:CtgCode>" + inboundOrder.ListInboundOrderDetailDTO[0].CtgCode + "</tem:CtgCode>" + "\n" +
                        @"                        <tem:ItemQty>" + inboundOrder.ListInboundOrderDetailDTO[0].ItemQty + "</tem:ItemQty>" + "\n" +
                        @"                        <tem:Status>" + inboundOrder.ListInboundOrderDetailDTO[0].Status + "</tem:Status>" + "\n" +
                        @"                        <tem:LineComment>" + inboundOrder.ListInboundOrderDetailDTO[0].LineComment + "</tem:LineComment>" + "\n" +
                        @"                        <tem:FifoDate>" + inboundOrder.ListInboundOrderDetailDTO[0].FifoDate + "</tem:FifoDate>" + "\n" +
                        @"                        <tem:ExpirationDate>" + inboundOrder.ListInboundOrderDetailDTO[0].ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                        <tem:FabricationDate>" + inboundOrder.ListInboundOrderDetailDTO[0].FabricationDate + "</tem:FabricationDate>" + "\n" +
                        @"                        <tem:LotNumber>" + inboundOrder.ListInboundOrderDetailDTO[0].LotNumber + "</tem:LotNumber>" + "\n" +
                        @"                        <tem:LpnCode>" + inboundOrder.ListInboundOrderDetailDTO[0].LpnCode + "</tem:LpnCode>" + "\n" +
                        @"                        <tem:Price>" + inboundOrder.ListInboundOrderDetailDTO[0].Price + "</tem:Price>" + "\n" +
                        @"                        <tem:StateInterface>" + inboundOrder.ListInboundOrderDetailDTO[0].StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                        <tem:DateCreatedERP>" + inboundOrder.ListInboundOrderDetailDTO[0].DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                        <tem:DateReadWMS>" + inboundOrder.ListInboundOrderDetailDTO[0].DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                     </tem:InboundDetailIfz>" + "\n" +
                        @"                  </tem:InboundDetailsIfz>" + "\n" +
                        @"               </tem:InboundOrderIfz>" + "\n" +
                        @"            </tem:ListInboundOrderIfz>" + "\n" +
                        @"         </tem:inboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportInboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
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
                else
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportInboundOrder");
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
                        @"      <tem:ImportInboundOrder>" + "\n" +
                        @"         <tem:inboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListInboundOrderIfz>" + "\n" +
                        @"               <tem:InboundOrderIfz>" + "\n" +
                        @"                  <tem:HasIssues>1</tem:HasIssues>" + "\n" +
                        @"                  <tem:WhsCode>" + inboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + inboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + inboundOrder.InboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:InboundTypeCode>" + inboundOrder.InboundTypeCode + "</tem:InboundTypeCode>" + "\n" +
                        @"                  <tem:OrderComment>" + inboundOrder.OrderComment + "</tem:OrderComment>" + "\n" +
                        @"                  <tem:VendorCode>" + inboundOrder.VendorCode + "</tem:VendorCode>" + "\n" +
                        @"                  <tem:DateExpected>" + inboundOrder.DateExpected + "</tem:DateExpected>" + "\n" +
                        @"                  <tem:EmissionDate>" + inboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + inboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:Status>" + inboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:OutboundNumberSource>" + inboundOrder.OutboundNumberSource + "</tem:OutboundNumberSource>" + "\n" +
                        @"                  <tem:IsAsn>" + inboundOrder.PercentLpnInspection + "</tem:IsAsn>" + "\n" +
                        @"                  <tem:PercentLpnInspection>" + inboundOrder.PercentLpnInspection + "</tem:PercentLpnInspection>" + "\n" +
                        @"                  <tem:PercentQA>" + inboundOrder.PercentQa + "</tem:PercentQA>" + "\n" +
                        @"                  <tem:ShiftNumber>" + inboundOrder.ShiftNumber + "</tem:ShiftNumber>" + "\n" +
                        @"                  <tem:SpecialField1>1</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>1</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>1</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>1</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + inboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + inboundOrder.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + inboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"               </tem:InboundOrderIfz>" + "\n" +
                        @"            </tem:ListInboundOrderIfz>" + "\n" +
                        @"         </tem:inboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportInboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
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
            else
            {
                if (inboundOrder.ListInboundOrderDetailDTO.Count > 0)
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportInboundOrder");
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
                        @"      <tem:ImportInboundOrder>" + "\n" +
                        @"         <tem:inboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListInboundOrderIfz>" + "\n" +
                        @"               <tem:InboundOrderIfz>" + "\n" +
                        @"                  <tem:HasIssues>1</tem:HasIssues>" + "\n" +
                        @"                  <tem:WhsCode>" + inboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + inboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + inboundOrder.InboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:InboundTypeCode>" + inboundOrder.InboundTypeCode + "</tem:InboundTypeCode>" + "\n" +
                        @"                  <tem:OrderComment>" + inboundOrder.OrderComment + "</tem:OrderComment>" + "\n" +
                        @"                  <tem:VendorCode>" + inboundOrder.VendorCode + "</tem:VendorCode>" + "\n" +
                        @"                  <tem:DateExpected>" + inboundOrder.DateExpected + "</tem:DateExpected>" + "\n" +
                        @"                  <tem:EmissionDate>" + inboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + inboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:Status>" + inboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:OutboundNumberSource>" + inboundOrder.OutboundNumberSource + "</tem:OutboundNumberSource>" + "\n" +
                        @"                  <tem:IsAsn>" + inboundOrder.PercentLpnInspection + "</tem:IsAsn>" + "\n" +
                        @"                  <tem:PercentLpnInspection>" + inboundOrder.PercentLpnInspection + "</tem:PercentLpnInspection>" + "\n" +
                        @"                  <tem:PercentQA>" + inboundOrder.PercentQa + "</tem:PercentQA>" + "\n" +
                        @"                  <tem:ShiftNumber>" + inboundOrder.ShiftNumber + "</tem:ShiftNumber>" + "\n" +
                        @"                  <tem:SpecialField1>1</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>1</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>1</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>1</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + inboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + inboundOrder.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + inboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                  <tem:InboundDetailsIfz>" + "\n" +
                        @"                     <tem:InboundDetailIfz>" + "\n" +
                        @"                        <tem:InboundOrderIfz/>" + "\n" +
                        @"                        <tem:LineNumber>" + inboundOrder.ListInboundOrderDetailDTO[0].LineNumber + "</tem:LineNumber>" + "\n" +
                        @"                        <tem:LineCode>" + inboundOrder.ListInboundOrderDetailDTO[0].LineCode + "</tem:LineCode>" + "\n" +
                        @"                        <tem:ItemCode>" + inboundOrder.ListInboundOrderDetailDTO[0].ItemCode + "</tem:ItemCode>" + "\n" +
                        @"                        <tem:CtgCode>" + inboundOrder.ListInboundOrderDetailDTO[0].CtgCode + "</tem:CtgCode>" + "\n" +
                        @"                        <tem:ItemQty>" + inboundOrder.ListInboundOrderDetailDTO[0].ItemQty + "</tem:ItemQty>" + "\n" +
                        @"                        <tem:Status>" + inboundOrder.ListInboundOrderDetailDTO[0].Status + "</tem:Status>" + "\n" +
                        @"                        <tem:LineComment>" + inboundOrder.ListInboundOrderDetailDTO[0].LineComment + "</tem:LineComment>" + "\n" +
                        @"                        <tem:FifoDate>" + inboundOrder.ListInboundOrderDetailDTO[0].FifoDate + "</tem:FifoDate>" + "\n" +
                        @"                        <tem:ExpirationDate>" + inboundOrder.ListInboundOrderDetailDTO[0].ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                        <tem:FabricationDate>" + inboundOrder.ListInboundOrderDetailDTO[0].FabricationDate + "</tem:FabricationDate>" + "\n" +
                        @"                        <tem:LotNumber>" + inboundOrder.ListInboundOrderDetailDTO[0].LotNumber + "</tem:LotNumber>" + "\n" +
                        @"                        <tem:LpnCode>" + inboundOrder.ListInboundOrderDetailDTO[0].LpnCode + "</tem:LpnCode>" + "\n" +
                        @"                        <tem:Price>" + inboundOrder.ListInboundOrderDetailDTO[0].Price + "</tem:Price>" + "\n" +
                        @"                        <tem:StateInterface>" + inboundOrder.ListInboundOrderDetailDTO[0].StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                        <tem:DateCreatedERP>" + inboundOrder.ListInboundOrderDetailDTO[0].DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                        <tem:DateReadWMS>" + inboundOrder.ListInboundOrderDetailDTO[0].DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                     </tem:InboundDetailIfz>" + "\n" +
                        @"                  </tem:InboundDetailsIfz>" + "\n" +
                        @"               </tem:InboundOrderIfz>" + "\n" +
                        @"            </tem:ListInboundOrderIfz>" + "\n" +
                        @"         </tem:inboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportInboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
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
                else
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportInboundOrder");
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
                        @"      <tem:ImportInboundOrder>" + "\n" +
                        @"         <tem:inboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListInboundOrderIfz>" + "\n" +
                        @"               <tem:InboundOrderIfz>" + "\n" +
                        @"                  <tem:HasIssues>1</tem:HasIssues>" + "\n" +
                        @"                  <tem:WhsCode>" + inboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + inboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + inboundOrder.InboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:InboundTypeCode>" + inboundOrder.InboundTypeCode + "</tem:InboundTypeCode>" + "\n" +
                        @"                  <tem:OrderComment>" + inboundOrder.OrderComment + "</tem:OrderComment>" + "\n" +
                        @"                  <tem:VendorCode>" + inboundOrder.VendorCode + "</tem:VendorCode>" + "\n" +
                        @"                  <tem:DateExpected>" + inboundOrder.DateExpected + "</tem:DateExpected>" + "\n" +
                        @"                  <tem:EmissionDate>" + inboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + inboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:Status>" + inboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:OutboundNumberSource>" + inboundOrder.OutboundNumberSource + "</tem:OutboundNumberSource>" + "\n" +
                        @"                  <tem:IsAsn>" + inboundOrder.PercentLpnInspection + "</tem:IsAsn>" + "\n" +
                        @"                  <tem:PercentLpnInspection>" + inboundOrder.PercentLpnInspection + "</tem:PercentLpnInspection>" + "\n" +
                        @"                  <tem:PercentQA>" + inboundOrder.PercentQa + "</tem:PercentQA>" + "\n" +
                        @"                  <tem:ShiftNumber>" + inboundOrder.ShiftNumber + "</tem:ShiftNumber>" + "\n" +
                        @"                  <tem:SpecialField1>1</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>1</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>1</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>1</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + inboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + inboundOrder.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + inboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"               </tem:InboundOrderIfz>" + "\n" +
                        @"            </tem:ListInboundOrderIfz>" + "\n" +
                        @"         </tem:inboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportInboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
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
    }
}
