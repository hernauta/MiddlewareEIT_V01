using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Configuration;
using MiddlewareEIT.BL.Models.XMLs;
using MiddlewareEIT.BL.Models;

namespace MiddlewareEIT.API.Services
{
    public class OutboundOrderServiceEIT
    {
        public static string GetRequestOutboundOrder(OutboundOrderDTO outboundOrder, string libreria)
        {
            if (libreria == "RmiLibFalabellaEIT")
            {
                if (outboundOrder.ListOutboundOrderDetailDTO.Count > 0)
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportOutboundOrder");
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
                        @"      <tem:ImportOutboundOrder>" + "\n" +
                        @"         <tem:outboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListOutboundOrderIfz>" + "\n" +
                        @"               <tem:OutboundOrderIfz>" + "\n" +
                        @"                  <tem:Comment>" + outboundOrder.Comment + "</tem:Comment>" + "\n" +
                        @"                  <tem:WhsCode>" + outboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + outboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + outboundOrder.OutboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:OutboundTypeCode>" + outboundOrder.OutboundTypeCode + "</tem:OutboundTypeCode>" + "\n" +
                        @"                  <tem:Status>" + outboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:ReferenceNumber>" + outboundOrder.ReferenceNumber + "</tem:ReferenceNumber>" + "\n" +
                        @"                  <tem:LoadCode>" + outboundOrder.LoadCode + "</tem:LoadCode>" + "\n" +
                        @"                  <tem:LoadSeq>" + outboundOrder.LoadSeq + "</tem:LoadSeq>" + "\n" +
                        @"                  <tem:Priority>" + outboundOrder.Priority + "</tem:Priority>" + "\n" +
                        @"                  <tem:InmediateProcess>" + outboundOrder.InmediateProcess + "</tem:InmediateProcess>" + "\n" +
                        @"                  <tem:EmissionDate>" + outboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpectedDate>" + outboundOrder.ExpectedDate + "</tem:ExpectedDate>" + "\n" +
                        @"                  <tem:ShipmentDate>" + outboundOrder.ShipmentDate + "</tem:ShipmentDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + outboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:CancelDate>" + outboundOrder.CancelDate + "</tem:CancelDate>" + "\n" +
                        @"                  <tem:CancelUser>" + outboundOrder.CancelUser + "</tem:CancelUser>" + "\n" +
                        @"                  <tem:CustomerCode>" + outboundOrder.CustomerCode + "</tem:CustomerCode>" + "\n" +
                        @"                  <tem:CustomerName>" + outboundOrder.CustomerName + "</tem:CustomerName>" + "\n" +
                        @"                  <tem:DeliveryAddress1>" + outboundOrder.DeliveryAddress1 + "</tem:DeliveryAddress1>" + "\n" +
                        @"                  <tem:DeliveryAddress2>" + outboundOrder.DeliveryAddress2 + "</tem:DeliveryAddress2>" + "\n" +
                        @"                  <tem:CountryNameDelivery>" + outboundOrder.CountryNameDelivery + "</tem:CountryNameDelivery>" + "\n" +
                        @"                  <tem:StateNameDelivery>" + outboundOrder.StateNameDelivery + "</tem:StateNameDelivery>" + "\n" +
                        @"                  <tem:CityNameDelivery>" + outboundOrder.CityNameDelivery + "</tem:CityNameDelivery>" + "\n" +
                        @"                  <tem:DeliveryPhone>" + outboundOrder.DeliveryPhone + "</tem:DeliveryPhone>" + "\n" +
                        @"                  <tem:DeliveryEmail>" + outboundOrder.DeliveryEmail + "</tem:DeliveryEmail>" + "\n" +
                        @"                  <tem:WhsCodeTarget>" + outboundOrder.WhsCodeTarget + "</tem:WhsCodeTarget>" + "\n" +
                        @"                  <tem:FullShipment>" + outboundOrder.FullShipment + "</tem:FullShipment>" + "\n" +
                        @"                  <tem:CarrierCode>" + outboundOrder.CarrierCode + "</tem:CarrierCode>" + "\n" +
                        @"                  <tem:RouteCode>" + outboundOrder.RouteCode + "</tem:RouteCode>" + "\n" +
                        @"                  <tem:Plate>" + outboundOrder.Plate + "</tem:Plate>" + "\n" +
                        @"                  <tem:Invoice>" + outboundOrder.Invoice + "</tem:Invoice>" + "\n" +
                        @"                  <tem:FactAddress1>" + outboundOrder.FactAddress1 + "</tem:FactAddress1>" + "\n" +
                        @"                  <tem:FactAddress2>" + outboundOrder.FactAddress2 + "</tem:FactAddress2>" + "\n" +
                        @"                  <tem:CountryNameFact>" + outboundOrder.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                        @"                  <tem:StateNameFact>" + outboundOrder.StateNameFact + "</tem:StateNameFact>" + "\n" +
                        @"                  <tem:CityNameFact>" + outboundOrder.CityNameFact + "</tem:CityNameFact>" + "\n" +
                        @"                  <tem:FactPhone>" + outboundOrder.FactPhone + "</tem:FactPhone>" + "\n" +
                        @"                  <tem:FactEmail>" + outboundOrder.FactEmail + "</tem:FactEmail>" + "\n" +
                        @"                  <tem:AllowCrossDock>" + outboundOrder.AllowCrossDock + "</tem:AllowCrossDock>" + "\n" +
                        @"                  <tem:AllowBackOrder>" + outboundOrder.AllowBackOrder + "</tem:AllowBackOrder>" + "\n" +
                        @"                  <tem:BranchCode>" + outboundOrder.BranchCode + "</tem:BranchCode>" + "\n" +
                        @"                  <tem:SpecialField1>" + outboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>" + outboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>" + outboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>" + outboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + outboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + outboundOrder.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + outboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                  <tem:OutboundDetailsIfz>" + "\n" +
                        @"                     <tem:OutboundDetailIfz>" + "\n" +
                        @"                        <tem:OutboundOrderIfz/>" + "\n" +
                        @"                        <tem:LineNumber>" + outboundOrder.ListOutboundOrderDetailDTO[0].LineNumber + "</tem:LineNumber>" + "\n" +
                        @"                        <tem:LineCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].LineCode + "</tem:LineCode>" + "\n" +
                        @"                        <tem:ItemCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].ItemCode + "</tem:ItemCode>" + "\n" +
                        @"                        <tem:CtgCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].CtgCode + "</tem:CtgCode>" + "\n" +
                        @"                        <tem:ItemQty>" + outboundOrder.ListOutboundOrderDetailDTO[0].ItemQty + "</tem:ItemQty>" + "\n" +
                        @"                        <tem:Status>" + outboundOrder.ListOutboundOrderDetailDTO[0].Status + "</tem:Status>" + "\n" +
                        @"                        <tem:LotNumber>" + outboundOrder.ListOutboundOrderDetailDTO[0].LotNumber + "</tem:LotNumber>" + "\n" +
                        @"                        <tem:FifoDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].FifoDate + "</tem:FifoDate>" + "\n" +
                        @"                        <tem:ExpirationDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                        <tem:FabricationDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].FabricationDate + "</tem:FabricationDate>" + "\n" +
                        @"                        <tem:GrpClass1>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass1 + "</tem:GrpClass1>" + "\n" +
                        @"                        <tem:GrpClass2>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass2 + "</tem:GrpClass2>" + "\n" +
                        @"                        <tem:GrpClass3>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass3 + "</tem:GrpClass3>" + "\n" +
                        @"                        <tem:GrpClass4>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass4 + "</tem:GrpClass4>" + "\n" +
                        @"                        <tem:GrpClass5>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass5 + "</tem:GrpClass5>" + "\n" +
                        @"                        <tem:GrpClass6>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass6 + "</tem:GrpClass6>" + "\n" +
                        @"                        <tem:GrpClass7>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass7 + "</tem:GrpClass7>" + "\n" +
                        @"                        <tem:GrpClass8>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass8 + "</tem:GrpClass8>" + "\n" +
                        @"                        <tem:SpecialField1>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                        <tem:SpecialField2>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                        <tem:SpecialField3>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                        <tem:SpecialField4>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                        <tem:StateInterface>" + outboundOrder.ListOutboundOrderDetailDTO[0].StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                        <tem:DateCreatedERP>" + outboundOrder.ListOutboundOrderDetailDTO[0].DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                        <tem:DateReadWMS>" + outboundOrder.ListOutboundOrderDetailDTO[0].DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                     </tem:OutboundDetailIfz>" + "\n" +
                        @"                  </tem:OutboundDetailsIfz>" + "\n" +
                        @"               </tem:OutboundOrderIfz>" + "\n" +
                        @"            </tem:ListOutboundOrderIfz>" + "\n" +
                        @"         </tem:outboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportOutboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
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
                else
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportOutboundOrder");
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
                        @"      <tem:ImportOutboundOrder>" + "\n" +
                        @"         <tem:outboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListOutboundOrderIfz>" + "\n" +
                        @"               <tem:OutboundOrderIfz>" + "\n" +
                        @"                  <tem:Comment>" + outboundOrder.Comment + "</tem:Comment>" + "\n" +
                        @"                  <tem:WhsCode>" + outboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + outboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + outboundOrder.OutboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:OutboundTypeCode>" + outboundOrder.OutboundTypeCode + "</tem:OutboundTypeCode>" + "\n" +
                        @"                  <tem:Status>" + outboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:ReferenceNumber>" + outboundOrder.ReferenceNumber + "</tem:ReferenceNumber>" + "\n" +
                        @"                  <tem:LoadCode>" + outboundOrder.LoadCode + "</tem:LoadCode>" + "\n" +
                        @"                  <tem:LoadSeq>" + outboundOrder.LoadSeq + "</tem:LoadSeq>" + "\n" +
                        @"                  <tem:Priority>" + outboundOrder.Priority + "</tem:Priority>" + "\n" +
                        @"                  <tem:InmediateProcess>" + outboundOrder.InmediateProcess + "</tem:InmediateProcess>" + "\n" +
                        @"                  <tem:EmissionDate>" + outboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpectedDate>" + outboundOrder.ExpectedDate + "</tem:ExpectedDate>" + "\n" +
                        @"                  <tem:ShipmentDate>" + outboundOrder.ShipmentDate + "</tem:ShipmentDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + outboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:CancelDate>" + outboundOrder.CancelDate + "</tem:CancelDate>" + "\n" +
                        @"                  <tem:CancelUser>" + outboundOrder.CancelUser + "</tem:CancelUser>" + "\n" +
                        @"                  <tem:CustomerCode>" + outboundOrder.CustomerCode + "</tem:CustomerCode>" + "\n" +
                        @"                  <tem:CustomerName>" + outboundOrder.CustomerName + "</tem:CustomerName>" + "\n" +
                        @"                  <tem:DeliveryAddress1>" + outboundOrder.DeliveryAddress1 + "</tem:DeliveryAddress1>" + "\n" +
                        @"                  <tem:DeliveryAddress2>" + outboundOrder.DeliveryAddress2 + "</tem:DeliveryAddress2>" + "\n" +
                        @"                  <tem:CountryNameDelivery>" + outboundOrder.CountryNameDelivery + "</tem:CountryNameDelivery>" + "\n" +
                        @"                  <tem:StateNameDelivery>" + outboundOrder.StateNameDelivery + "</tem:StateNameDelivery>" + "\n" +
                        @"                  <tem:CityNameDelivery>" + outboundOrder.CityNameDelivery + "</tem:CityNameDelivery>" + "\n" +
                        @"                  <tem:DeliveryPhone>" + outboundOrder.DeliveryPhone + "</tem:DeliveryPhone>" + "\n" +
                        @"                  <tem:DeliveryEmail>" + outboundOrder.DeliveryEmail + "</tem:DeliveryEmail>" + "\n" +
                        @"                  <tem:WhsCodeTarget>" + outboundOrder.WhsCodeTarget + "</tem:WhsCodeTarget>" + "\n" +
                        @"                  <tem:FullShipment>" + outboundOrder.FullShipment + "</tem:FullShipment>" + "\n" +
                        @"                  <tem:CarrierCode>" + outboundOrder.CarrierCode + "</tem:CarrierCode>" + "\n" +
                        @"                  <tem:RouteCode>" + outboundOrder.RouteCode + "</tem:RouteCode>" + "\n" +
                        @"                  <tem:Plate>" + outboundOrder.Plate + "</tem:Plate>" + "\n" +
                        @"                  <tem:Invoice>" + outboundOrder.Invoice + "</tem:Invoice>" + "\n" +
                        @"                  <tem:FactAddress1>" + outboundOrder.FactAddress1 + "</tem:FactAddress1>" + "\n" +
                        @"                  <tem:FactAddress2>" + outboundOrder.FactAddress2 + "</tem:FactAddress2>" + "\n" +
                        @"                  <tem:CountryNameFact>" + outboundOrder.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                        @"                  <tem:StateNameFact>" + outboundOrder.StateNameFact + "</tem:StateNameFact>" + "\n" +
                        @"                  <tem:CityNameFact>" + outboundOrder.CityNameFact + "</tem:CityNameFact>" + "\n" +
                        @"                  <tem:FactPhone>" + outboundOrder.FactPhone + "</tem:FactPhone>" + "\n" +
                        @"                  <tem:FactEmail>" + outboundOrder.FactEmail + "</tem:FactEmail>" + "\n" +
                        @"                  <tem:AllowCrossDock>" + outboundOrder.AllowCrossDock + "</tem:AllowCrossDock>" + "\n" +
                        @"                  <tem:AllowBackOrder>" + outboundOrder.AllowBackOrder + "</tem:AllowBackOrder>" + "\n" +
                        @"                  <tem:BranchCode>" + outboundOrder.BranchCode + "</tem:BranchCode>" + "\n" +
                        @"                  <tem:SpecialField1>" + outboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>" + outboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>" + outboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>" + outboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + outboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + outboundOrder.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + outboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"               </tem:OutboundOrderIfz>" + "\n" +
                        @"            </tem:ListOutboundOrderIfz>" + "\n" +
                        @"         </tem:outboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportOutboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
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
            else if (libreria == "RmiLibReversoEIT")
            {
                if (outboundOrder.ListOutboundOrderDetailDTO.Count > 0)
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportOutboundOrder");
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
                        @"      <tem:ImportOutboundOrder>" + "\n" +
                        @"         <tem:outboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListOutboundOrderIfz>" + "\n" +
                        @"               <tem:OutboundOrderIfz>" + "\n" +
                        @"                  <tem:Comment>" + outboundOrder.Comment + "</tem:Comment>" + "\n" +
                        @"                  <tem:WhsCode>" + outboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + outboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + outboundOrder.OutboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:OutboundTypeCode>" + outboundOrder.OutboundTypeCode + "</tem:OutboundTypeCode>" + "\n" +
                        @"                  <tem:Status>" + outboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:ReferenceNumber>" + outboundOrder.ReferenceNumber + "</tem:ReferenceNumber>" + "\n" +
                        @"                  <tem:LoadCode>" + outboundOrder.LoadCode + "</tem:LoadCode>" + "\n" +
                        @"                  <tem:LoadSeq>" + outboundOrder.LoadSeq + "</tem:LoadSeq>" + "\n" +
                        @"                  <tem:Priority>" + outboundOrder.Priority + "</tem:Priority>" + "\n" +
                        @"                  <tem:InmediateProcess>" + outboundOrder.InmediateProcess + "</tem:InmediateProcess>" + "\n" +
                        @"                  <tem:EmissionDate>" + outboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpectedDate>" + outboundOrder.ExpectedDate + "</tem:ExpectedDate>" + "\n" +
                        @"                  <tem:ShipmentDate>" + outboundOrder.ShipmentDate + "</tem:ShipmentDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + outboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:CancelDate>" + outboundOrder.CancelDate + "</tem:CancelDate>" + "\n" +
                        @"                  <tem:CancelUser>" + outboundOrder.CancelUser + "</tem:CancelUser>" + "\n" +
                        @"                  <tem:CustomerCode>" + outboundOrder.CustomerCode + "</tem:CustomerCode>" + "\n" +
                        @"                  <tem:CustomerName>" + outboundOrder.CustomerName + "</tem:CustomerName>" + "\n" +
                        @"                  <tem:DeliveryAddress1>" + outboundOrder.DeliveryAddress1 + "</tem:DeliveryAddress1>" + "\n" +
                        @"                  <tem:DeliveryAddress2>" + outboundOrder.DeliveryAddress2 + "</tem:DeliveryAddress2>" + "\n" +
                        @"                  <tem:CountryNameDelivery>" + outboundOrder.CountryNameDelivery + "</tem:CountryNameDelivery>" + "\n" +
                        @"                  <tem:StateNameDelivery>" + outboundOrder.StateNameDelivery + "</tem:StateNameDelivery>" + "\n" +
                        @"                  <tem:CityNameDelivery>" + outboundOrder.CityNameDelivery + "</tem:CityNameDelivery>" + "\n" +
                        @"                  <tem:DeliveryPhone>" + outboundOrder.DeliveryPhone + "</tem:DeliveryPhone>" + "\n" +
                        @"                  <tem:DeliveryEmail>" + outboundOrder.DeliveryEmail + "</tem:DeliveryEmail>" + "\n" +
                        @"                  <tem:WhsCodeTarget>" + outboundOrder.WhsCodeTarget + "</tem:WhsCodeTarget>" + "\n" +
                        @"                  <tem:FullShipment>" + outboundOrder.FullShipment + "</tem:FullShipment>" + "\n" +
                        @"                  <tem:CarrierCode>" + outboundOrder.CarrierCode + "</tem:CarrierCode>" + "\n" +
                        @"                  <tem:RouteCode>" + outboundOrder.RouteCode + "</tem:RouteCode>" + "\n" +
                        @"                  <tem:Plate>" + outboundOrder.Plate + "</tem:Plate>" + "\n" +
                        @"                  <tem:Invoice>" + outboundOrder.Invoice + "</tem:Invoice>" + "\n" +
                        @"                  <tem:FactAddress1>" + outboundOrder.FactAddress1 + "</tem:FactAddress1>" + "\n" +
                        @"                  <tem:FactAddress2>" + outboundOrder.FactAddress2 + "</tem:FactAddress2>" + "\n" +
                        @"                  <tem:CountryNameFact>" + outboundOrder.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                        @"                  <tem:StateNameFact>" + outboundOrder.StateNameFact + "</tem:StateNameFact>" + "\n" +
                        @"                  <tem:CityNameFact>" + outboundOrder.CityNameFact + "</tem:CityNameFact>" + "\n" +
                        @"                  <tem:FactPhone>" + outboundOrder.FactPhone + "</tem:FactPhone>" + "\n" +
                        @"                  <tem:FactEmail>" + outboundOrder.FactEmail + "</tem:FactEmail>" + "\n" +
                        @"                  <tem:AllowCrossDock>" + outboundOrder.AllowCrossDock + "</tem:AllowCrossDock>" + "\n" +
                        @"                  <tem:AllowBackOrder>" + outboundOrder.AllowBackOrder + "</tem:AllowBackOrder>" + "\n" +
                        @"                  <tem:BranchCode>" + outboundOrder.BranchCode + "</tem:BranchCode>" + "\n" +
                        @"                  <tem:SpecialField1>" + outboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>" + outboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>" + outboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>" + outboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + outboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + outboundOrder.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + outboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                  <tem:OutboundDetailsIfz>" + "\n" +
                        @"                     <tem:OutboundDetailIfz>" + "\n" +
                        @"                        <tem:OutboundOrderIfz/>" + "\n" +
                        @"                        <tem:LineNumber>" + outboundOrder.ListOutboundOrderDetailDTO[0].LineNumber + "</tem:LineNumber>" + "\n" +
                        @"                        <tem:LineCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].LineCode + "</tem:LineCode>" + "\n" +
                        @"                        <tem:ItemCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].ItemCode + "</tem:ItemCode>" + "\n" +
                        @"                        <tem:CtgCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].CtgCode + "</tem:CtgCode>" + "\n" +
                        @"                        <tem:ItemQty>" + outboundOrder.ListOutboundOrderDetailDTO[0].ItemQty + "</tem:ItemQty>" + "\n" +
                        @"                        <tem:Status>" + outboundOrder.ListOutboundOrderDetailDTO[0].Status + "</tem:Status>" + "\n" +
                        @"                        <tem:LotNumber>" + outboundOrder.ListOutboundOrderDetailDTO[0].LotNumber + "</tem:LotNumber>" + "\n" +
                        @"                        <tem:FifoDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].FifoDate + "</tem:FifoDate>" + "\n" +
                        @"                        <tem:ExpirationDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                        <tem:FabricationDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].FabricationDate + "</tem:FabricationDate>" + "\n" +
                        @"                        <tem:GrpClass1>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass1 + "</tem:GrpClass1>" + "\n" +
                        @"                        <tem:GrpClass2>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass2 + "</tem:GrpClass2>" + "\n" +
                        @"                        <tem:GrpClass3>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass3 + "</tem:GrpClass3>" + "\n" +
                        @"                        <tem:GrpClass4>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass4 + "</tem:GrpClass4>" + "\n" +
                        @"                        <tem:GrpClass5>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass5 + "</tem:GrpClass5>" + "\n" +
                        @"                        <tem:GrpClass6>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass6 + "</tem:GrpClass6>" + "\n" +
                        @"                        <tem:GrpClass7>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass7 + "</tem:GrpClass7>" + "\n" +
                        @"                        <tem:GrpClass8>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass8 + "</tem:GrpClass8>" + "\n" +
                        @"                        <tem:SpecialField1>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                        <tem:SpecialField2>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                        <tem:SpecialField3>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                        <tem:SpecialField4>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                        <tem:StateInterface>" + outboundOrder.ListOutboundOrderDetailDTO[0].StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                        <tem:DateCreatedERP>" + outboundOrder.ListOutboundOrderDetailDTO[0].DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                        <tem:DateReadWMS>" + outboundOrder.ListOutboundOrderDetailDTO[0].DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                     </tem:OutboundDetailIfz>" + "\n" +
                        @"                  </tem:OutboundDetailsIfz>" + "\n" +
                        @"               </tem:OutboundOrderIfz>" + "\n" +
                        @"            </tem:ListOutboundOrderIfz>" + "\n" +
                        @"         </tem:outboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportOutboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
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
                else
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportOutboundOrder");
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
                        @"      <tem:ImportOutboundOrder>" + "\n" +
                        @"         <tem:outboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListOutboundOrderIfz>" + "\n" +
                        @"               <tem:OutboundOrderIfz>" + "\n" +
                        @"                  <tem:Comment>" + outboundOrder.Comment + "</tem:Comment>" + "\n" +
                        @"                  <tem:WhsCode>" + outboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + outboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + outboundOrder.OutboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:OutboundTypeCode>" + outboundOrder.OutboundTypeCode + "</tem:OutboundTypeCode>" + "\n" +
                        @"                  <tem:Status>" + outboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:ReferenceNumber>" + outboundOrder.ReferenceNumber + "</tem:ReferenceNumber>" + "\n" +
                        @"                  <tem:LoadCode>" + outboundOrder.LoadCode + "</tem:LoadCode>" + "\n" +
                        @"                  <tem:LoadSeq>" + outboundOrder.LoadSeq + "</tem:LoadSeq>" + "\n" +
                        @"                  <tem:Priority>" + outboundOrder.Priority + "</tem:Priority>" + "\n" +
                        @"                  <tem:InmediateProcess>" + outboundOrder.InmediateProcess + "</tem:InmediateProcess>" + "\n" +
                        @"                  <tem:EmissionDate>" + outboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpectedDate>" + outboundOrder.ExpectedDate + "</tem:ExpectedDate>" + "\n" +
                        @"                  <tem:ShipmentDate>" + outboundOrder.ShipmentDate + "</tem:ShipmentDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + outboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:CancelDate>" + outboundOrder.CancelDate + "</tem:CancelDate>" + "\n" +
                        @"                  <tem:CancelUser>" + outboundOrder.CancelUser + "</tem:CancelUser>" + "\n" +
                        @"                  <tem:CustomerCode>" + outboundOrder.CustomerCode + "</tem:CustomerCode>" + "\n" +
                        @"                  <tem:CustomerName>" + outboundOrder.CustomerName + "</tem:CustomerName>" + "\n" +
                        @"                  <tem:DeliveryAddress1>" + outboundOrder.DeliveryAddress1 + "</tem:DeliveryAddress1>" + "\n" +
                        @"                  <tem:DeliveryAddress2>" + outboundOrder.DeliveryAddress2 + "</tem:DeliveryAddress2>" + "\n" +
                        @"                  <tem:CountryNameDelivery>" + outboundOrder.CountryNameDelivery + "</tem:CountryNameDelivery>" + "\n" +
                        @"                  <tem:StateNameDelivery>" + outboundOrder.StateNameDelivery + "</tem:StateNameDelivery>" + "\n" +
                        @"                  <tem:CityNameDelivery>" + outboundOrder.CityNameDelivery + "</tem:CityNameDelivery>" + "\n" +
                        @"                  <tem:DeliveryPhone>" + outboundOrder.DeliveryPhone + "</tem:DeliveryPhone>" + "\n" +
                        @"                  <tem:DeliveryEmail>" + outboundOrder.DeliveryEmail + "</tem:DeliveryEmail>" + "\n" +
                        @"                  <tem:WhsCodeTarget>" + outboundOrder.WhsCodeTarget + "</tem:WhsCodeTarget>" + "\n" +
                        @"                  <tem:FullShipment>" + outboundOrder.FullShipment + "</tem:FullShipment>" + "\n" +
                        @"                  <tem:CarrierCode>" + outboundOrder.CarrierCode + "</tem:CarrierCode>" + "\n" +
                        @"                  <tem:RouteCode>" + outboundOrder.RouteCode + "</tem:RouteCode>" + "\n" +
                        @"                  <tem:Plate>" + outboundOrder.Plate + "</tem:Plate>" + "\n" +
                        @"                  <tem:Invoice>" + outboundOrder.Invoice + "</tem:Invoice>" + "\n" +
                        @"                  <tem:FactAddress1>" + outboundOrder.FactAddress1 + "</tem:FactAddress1>" + "\n" +
                        @"                  <tem:FactAddress2>" + outboundOrder.FactAddress2 + "</tem:FactAddress2>" + "\n" +
                        @"                  <tem:CountryNameFact>" + outboundOrder.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                        @"                  <tem:StateNameFact>" + outboundOrder.StateNameFact + "</tem:StateNameFact>" + "\n" +
                        @"                  <tem:CityNameFact>" + outboundOrder.CityNameFact + "</tem:CityNameFact>" + "\n" +
                        @"                  <tem:FactPhone>" + outboundOrder.FactPhone + "</tem:FactPhone>" + "\n" +
                        @"                  <tem:FactEmail>" + outboundOrder.FactEmail + "</tem:FactEmail>" + "\n" +
                        @"                  <tem:AllowCrossDock>" + outboundOrder.AllowCrossDock + "</tem:AllowCrossDock>" + "\n" +
                        @"                  <tem:AllowBackOrder>" + outboundOrder.AllowBackOrder + "</tem:AllowBackOrder>" + "\n" +
                        @"                  <tem:BranchCode>" + outboundOrder.BranchCode + "</tem:BranchCode>" + "\n" +
                        @"                  <tem:SpecialField1>" + outboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>" + outboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>" + outboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>" + outboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + outboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + outboundOrder.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + outboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"               </tem:OutboundOrderIfz>" + "\n" +
                        @"            </tem:ListOutboundOrderIfz>" + "\n" +
                        @"         </tem:outboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportOutboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
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
            else {
                if (outboundOrder.ListOutboundOrderDetailDTO.Count > 0)
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportOutboundOrder");
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
                        @"      <tem:ImportOutboundOrder>" + "\n" +
                        @"         <tem:outboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListOutboundOrderIfz>" + "\n" +
                        @"               <tem:OutboundOrderIfz>" + "\n" +
                        @"                  <tem:Comment>" + outboundOrder.Comment + "</tem:Comment>" + "\n" +
                        @"                  <tem:WhsCode>" + outboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + outboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + outboundOrder.OutboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:OutboundTypeCode>" + outboundOrder.OutboundTypeCode + "</tem:OutboundTypeCode>" + "\n" +
                        @"                  <tem:Status>" + outboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:ReferenceNumber>" + outboundOrder.ReferenceNumber + "</tem:ReferenceNumber>" + "\n" +
                        @"                  <tem:LoadCode>" + outboundOrder.LoadCode + "</tem:LoadCode>" + "\n" +
                        @"                  <tem:LoadSeq>" + outboundOrder.LoadSeq + "</tem:LoadSeq>" + "\n" +
                        @"                  <tem:Priority>" + outboundOrder.Priority + "</tem:Priority>" + "\n" +
                        @"                  <tem:InmediateProcess>" + outboundOrder.InmediateProcess + "</tem:InmediateProcess>" + "\n" +
                        @"                  <tem:EmissionDate>" + outboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpectedDate>" + outboundOrder.ExpectedDate + "</tem:ExpectedDate>" + "\n" +
                        @"                  <tem:ShipmentDate>" + outboundOrder.ShipmentDate + "</tem:ShipmentDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + outboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:CancelDate>" + outboundOrder.CancelDate + "</tem:CancelDate>" + "\n" +
                        @"                  <tem:CancelUser>" + outboundOrder.CancelUser + "</tem:CancelUser>" + "\n" +
                        @"                  <tem:CustomerCode>" + outboundOrder.CustomerCode + "</tem:CustomerCode>" + "\n" +
                        @"                  <tem:CustomerName>" + outboundOrder.CustomerName + "</tem:CustomerName>" + "\n" +
                        @"                  <tem:DeliveryAddress1>" + outboundOrder.DeliveryAddress1 + "</tem:DeliveryAddress1>" + "\n" +
                        @"                  <tem:DeliveryAddress2>" + outboundOrder.DeliveryAddress2 + "</tem:DeliveryAddress2>" + "\n" +
                        @"                  <tem:CountryNameDelivery>" + outboundOrder.CountryNameDelivery + "</tem:CountryNameDelivery>" + "\n" +
                        @"                  <tem:StateNameDelivery>" + outboundOrder.StateNameDelivery + "</tem:StateNameDelivery>" + "\n" +
                        @"                  <tem:CityNameDelivery>" + outboundOrder.CityNameDelivery + "</tem:CityNameDelivery>" + "\n" +
                        @"                  <tem:DeliveryPhone>" + outboundOrder.DeliveryPhone + "</tem:DeliveryPhone>" + "\n" +
                        @"                  <tem:DeliveryEmail>" + outboundOrder.DeliveryEmail + "</tem:DeliveryEmail>" + "\n" +
                        @"                  <tem:WhsCodeTarget>" + outboundOrder.WhsCodeTarget + "</tem:WhsCodeTarget>" + "\n" +
                        @"                  <tem:FullShipment>" + outboundOrder.FullShipment + "</tem:FullShipment>" + "\n" +
                        @"                  <tem:CarrierCode>" + outboundOrder.CarrierCode + "</tem:CarrierCode>" + "\n" +
                        @"                  <tem:RouteCode>" + outboundOrder.RouteCode + "</tem:RouteCode>" + "\n" +
                        @"                  <tem:Plate>" + outboundOrder.Plate + "</tem:Plate>" + "\n" +
                        @"                  <tem:Invoice>" + outboundOrder.Invoice + "</tem:Invoice>" + "\n" +
                        @"                  <tem:FactAddress1>" + outboundOrder.FactAddress1 + "</tem:FactAddress1>" + "\n" +
                        @"                  <tem:FactAddress2>" + outboundOrder.FactAddress2 + "</tem:FactAddress2>" + "\n" +
                        @"                  <tem:CountryNameFact>" + outboundOrder.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                        @"                  <tem:StateNameFact>" + outboundOrder.StateNameFact + "</tem:StateNameFact>" + "\n" +
                        @"                  <tem:CityNameFact>" + outboundOrder.CityNameFact + "</tem:CityNameFact>" + "\n" +
                        @"                  <tem:FactPhone>" + outboundOrder.FactPhone + "</tem:FactPhone>" + "\n" +
                        @"                  <tem:FactEmail>" + outboundOrder.FactEmail + "</tem:FactEmail>" + "\n" +
                        @"                  <tem:AllowCrossDock>" + outboundOrder.AllowCrossDock + "</tem:AllowCrossDock>" + "\n" +
                        @"                  <tem:AllowBackOrder>" + outboundOrder.AllowBackOrder + "</tem:AllowBackOrder>" + "\n" +
                        @"                  <tem:BranchCode>" + outboundOrder.BranchCode + "</tem:BranchCode>" + "\n" +
                        @"                  <tem:SpecialField1>" + outboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>" + outboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>" + outboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>" + outboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + outboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + outboundOrder.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + outboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                  <tem:OutboundDetailsIfz>" + "\n" +
                        @"                     <tem:OutboundDetailIfz>" + "\n" +
                        @"                        <tem:OutboundOrderIfz/>" + "\n" +
                        @"                        <tem:LineNumber>" + outboundOrder.ListOutboundOrderDetailDTO[0].LineNumber + "</tem:LineNumber>" + "\n" +
                        @"                        <tem:LineCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].LineCode + "</tem:LineCode>" + "\n" +
                        @"                        <tem:ItemCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].ItemCode + "</tem:ItemCode>" + "\n" +
                        @"                        <tem:CtgCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].CtgCode + "</tem:CtgCode>" + "\n" +
                        @"                        <tem:ItemQty>" + outboundOrder.ListOutboundOrderDetailDTO[0].ItemQty + "</tem:ItemQty>" + "\n" +
                        @"                        <tem:Status>" + outboundOrder.ListOutboundOrderDetailDTO[0].Status + "</tem:Status>" + "\n" +
                        @"                        <tem:LotNumber>" + outboundOrder.ListOutboundOrderDetailDTO[0].LotNumber + "</tem:LotNumber>" + "\n" +
                        @"                        <tem:FifoDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].FifoDate + "</tem:FifoDate>" + "\n" +
                        @"                        <tem:ExpirationDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                        <tem:FabricationDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].FabricationDate + "</tem:FabricationDate>" + "\n" +
                        @"                        <tem:GrpClass1>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass1 + "</tem:GrpClass1>" + "\n" +
                        @"                        <tem:GrpClass2>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass2 + "</tem:GrpClass2>" + "\n" +
                        @"                        <tem:GrpClass3>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass3 + "</tem:GrpClass3>" + "\n" +
                        @"                        <tem:GrpClass4>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass4 + "</tem:GrpClass4>" + "\n" +
                        @"                        <tem:GrpClass5>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass5 + "</tem:GrpClass5>" + "\n" +
                        @"                        <tem:GrpClass6>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass6 + "</tem:GrpClass6>" + "\n" +
                        @"                        <tem:GrpClass7>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass7 + "</tem:GrpClass7>" + "\n" +
                        @"                        <tem:GrpClass8>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass8 + "</tem:GrpClass8>" + "\n" +
                        @"                        <tem:SpecialField1>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                        <tem:SpecialField2>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                        <tem:SpecialField3>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                        <tem:SpecialField4>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                        <tem:StateInterface>" + outboundOrder.ListOutboundOrderDetailDTO[0].StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                        <tem:DateCreatedERP>" + outboundOrder.ListOutboundOrderDetailDTO[0].DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                        <tem:DateReadWMS>" + outboundOrder.ListOutboundOrderDetailDTO[0].DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"                     </tem:OutboundDetailIfz>" + "\n" +
                        @"                  </tem:OutboundDetailsIfz>" + "\n" +
                        @"               </tem:OutboundOrderIfz>" + "\n" +
                        @"            </tem:ListOutboundOrderIfz>" + "\n" +
                        @"         </tem:outboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportOutboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
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
                else
                {
                    var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportOutboundOrder");
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
                        @"      <tem:ImportOutboundOrder>" + "\n" +
                        @"         <tem:outboundOrderIfzFun>" + "\n" +
                        @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                        @"            <tem:ListOutboundOrderIfz>" + "\n" +
                        @"               <tem:OutboundOrderIfz>" + "\n" +
                        @"                  <tem:Comment>" + outboundOrder.Comment + "</tem:Comment>" + "\n" +
                        @"                  <tem:WhsCode>" + outboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                        @"                  <tem:OwnCode>" + outboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                        @"                  <tem:Number>" + outboundOrder.OutboundNumber + "</tem:Number>" + "\n" +
                        @"                  <tem:OutboundTypeCode>" + outboundOrder.OutboundTypeCode + "</tem:OutboundTypeCode>" + "\n" +
                        @"                  <tem:Status>" + outboundOrder.Status + "</tem:Status>" + "\n" +
                        @"                  <tem:ReferenceNumber>" + outboundOrder.ReferenceNumber + "</tem:ReferenceNumber>" + "\n" +
                        @"                  <tem:LoadCode>" + outboundOrder.LoadCode + "</tem:LoadCode>" + "\n" +
                        @"                  <tem:LoadSeq>" + outboundOrder.LoadSeq + "</tem:LoadSeq>" + "\n" +
                        @"                  <tem:Priority>" + outboundOrder.Priority + "</tem:Priority>" + "\n" +
                        @"                  <tem:InmediateProcess>" + outboundOrder.InmediateProcess + "</tem:InmediateProcess>" + "\n" +
                        @"                  <tem:EmissionDate>" + outboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                        @"                  <tem:ExpectedDate>" + outboundOrder.ExpectedDate + "</tem:ExpectedDate>" + "\n" +
                        @"                  <tem:ShipmentDate>" + outboundOrder.ShipmentDate + "</tem:ShipmentDate>" + "\n" +
                        @"                  <tem:ExpirationDate>" + outboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                        @"                  <tem:CancelDate>" + outboundOrder.CancelDate + "</tem:CancelDate>" + "\n" +
                        @"                  <tem:CancelUser>" + outboundOrder.CancelUser + "</tem:CancelUser>" + "\n" +
                        @"                  <tem:CustomerCode>" + outboundOrder.CustomerCode + "</tem:CustomerCode>" + "\n" +
                        @"                  <tem:CustomerName>" + outboundOrder.CustomerName + "</tem:CustomerName>" + "\n" +
                        @"                  <tem:DeliveryAddress1>" + outboundOrder.DeliveryAddress1 + "</tem:DeliveryAddress1>" + "\n" +
                        @"                  <tem:DeliveryAddress2>" + outboundOrder.DeliveryAddress2 + "</tem:DeliveryAddress2>" + "\n" +
                        @"                  <tem:CountryNameDelivery>" + outboundOrder.CountryNameDelivery + "</tem:CountryNameDelivery>" + "\n" +
                        @"                  <tem:StateNameDelivery>" + outboundOrder.StateNameDelivery + "</tem:StateNameDelivery>" + "\n" +
                        @"                  <tem:CityNameDelivery>" + outboundOrder.CityNameDelivery + "</tem:CityNameDelivery>" + "\n" +
                        @"                  <tem:DeliveryPhone>" + outboundOrder.DeliveryPhone + "</tem:DeliveryPhone>" + "\n" +
                        @"                  <tem:DeliveryEmail>" + outboundOrder.DeliveryEmail + "</tem:DeliveryEmail>" + "\n" +
                        @"                  <tem:WhsCodeTarget>" + outboundOrder.WhsCodeTarget + "</tem:WhsCodeTarget>" + "\n" +
                        @"                  <tem:FullShipment>" + outboundOrder.FullShipment + "</tem:FullShipment>" + "\n" +
                        @"                  <tem:CarrierCode>" + outboundOrder.CarrierCode + "</tem:CarrierCode>" + "\n" +
                        @"                  <tem:RouteCode>" + outboundOrder.RouteCode + "</tem:RouteCode>" + "\n" +
                        @"                  <tem:Plate>" + outboundOrder.Plate + "</tem:Plate>" + "\n" +
                        @"                  <tem:Invoice>" + outboundOrder.Invoice + "</tem:Invoice>" + "\n" +
                        @"                  <tem:FactAddress1>" + outboundOrder.FactAddress1 + "</tem:FactAddress1>" + "\n" +
                        @"                  <tem:FactAddress2>" + outboundOrder.FactAddress2 + "</tem:FactAddress2>" + "\n" +
                        @"                  <tem:CountryNameFact>" + outboundOrder.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                        @"                  <tem:StateNameFact>" + outboundOrder.StateNameFact + "</tem:StateNameFact>" + "\n" +
                        @"                  <tem:CityNameFact>" + outboundOrder.CityNameFact + "</tem:CityNameFact>" + "\n" +
                        @"                  <tem:FactPhone>" + outboundOrder.FactPhone + "</tem:FactPhone>" + "\n" +
                        @"                  <tem:FactEmail>" + outboundOrder.FactEmail + "</tem:FactEmail>" + "\n" +
                        @"                  <tem:AllowCrossDock>" + outboundOrder.AllowCrossDock + "</tem:AllowCrossDock>" + "\n" +
                        @"                  <tem:AllowBackOrder>" + outboundOrder.AllowBackOrder + "</tem:AllowBackOrder>" + "\n" +
                        @"                  <tem:BranchCode>" + outboundOrder.BranchCode + "</tem:BranchCode>" + "\n" +
                        @"                  <tem:SpecialField1>" + outboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                        @"                  <tem:SpecialField2>" + outboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                        @"                  <tem:SpecialField3>" + outboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                        @"                  <tem:SpecialField4>" + outboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                        @"                  <tem:StateInterface>" + outboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                        @"                  <tem:DateCreatedERP>" + outboundOrder.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                        @"                  <tem:DateReadWMS>" + outboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                        @"               </tem:OutboundOrderIfz>" + "\n" +
                        @"            </tem:ListOutboundOrderIfz>" + "\n" +
                        @"         </tem:outboundOrderIfzFun>" + "\n" +
                        @"      </tem:ImportOutboundOrder>" + "\n" +
                        @"   </soapenv:Body>" + "\n" +
                        @"</soapenv:Envelope>";
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
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

        public static string GetRequestOutboundOrder2(OutboundOrderDTO outboundOrder)
        {
            if (outboundOrder.ListOutboundOrderDetailDTO.Count > 0)
            {
                var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportOutboundOrder");
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
                    @"      <tem:ImportOutboundOrder>" + "\n" +
                    @"         <tem:outboundOrderIfzFun>" + "\n" +
                    @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                    @"            <tem:ListOutboundOrderIfz>" + "\n" +
                    @"               <tem:OutboundOrderIfz>" + "\n" +
                    @"                  <tem:Comment>" + outboundOrder.Comment + "</tem:Comment>" + "\n" +
                    @"                  <tem:WhsCode>" + outboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                    @"                  <tem:OwnCode>" + outboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                    @"                  <tem:Number>" + outboundOrder.OutboundNumber + "</tem:Number>" + "\n" +
                    @"                  <tem:OutboundTypeCode>" + outboundOrder.OutboundTypeCode + "</tem:OutboundTypeCode>" + "\n" +
                    @"                  <tem:Status>" + outboundOrder.Status + "</tem:Status>" + "\n" +
                    @"                  <tem:ReferenceNumber>" + outboundOrder.ReferenceNumber + "</tem:ReferenceNumber>" + "\n" +
                    @"                  <tem:LoadCode>" + outboundOrder.LoadCode + "</tem:LoadCode>" + "\n" +
                    @"                  <tem:LoadSeq>" + outboundOrder.LoadSeq + "</tem:LoadSeq>" + "\n" +
                    @"                  <tem:Priority>" + outboundOrder.Priority + "</tem:Priority>" + "\n" +
                    @"                  <tem:InmediateProcess>" + outboundOrder.InmediateProcess + "</tem:InmediateProcess>" + "\n" +
                    @"                  <tem:EmissionDate>" + outboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                    @"                  <tem:ExpectedDate>" + outboundOrder.ExpectedDate + "</tem:ExpectedDate>" + "\n" +
                    @"                  <tem:ShipmentDate>" + outboundOrder.ShipmentDate + "</tem:ShipmentDate>" + "\n" +
                    @"                  <tem:ExpirationDate>" + outboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                    @"                  <tem:CancelDate>" + outboundOrder.CancelDate + "</tem:CancelDate>" + "\n" +
                    @"                  <tem:CancelUser>" + outboundOrder.CancelUser + "</tem:CancelUser>" + "\n" +
                    @"                  <tem:CustomerCode>" + outboundOrder.CustomerCode + "</tem:CustomerCode>" + "\n" +
                    @"                  <tem:CustomerName>" + outboundOrder.CustomerName + "</tem:CustomerName>" + "\n" +
                    @"                  <tem:DeliveryAddress1>" + outboundOrder.DeliveryAddress1 + "</tem:DeliveryAddress1>" + "\n" +
                    @"                  <tem:DeliveryAddress2>" + outboundOrder.DeliveryAddress2 + "</tem:DeliveryAddress2>" + "\n" +
                    @"                  <tem:CountryNameDelivery>" + outboundOrder.CountryNameDelivery + "</tem:CountryNameDelivery>" + "\n" +
                    @"                  <tem:StateNameDelivery>" + outboundOrder.StateNameDelivery + "</tem:StateNameDelivery>" + "\n" +
                    @"                  <tem:CityNameDelivery>" + outboundOrder.CityNameDelivery + "</tem:CityNameDelivery>" + "\n" +
                    @"                  <tem:DeliveryPhone>" + outboundOrder.DeliveryPhone + "</tem:DeliveryPhone>" + "\n" +
                    @"                  <tem:DeliveryEmail>" + outboundOrder.DeliveryEmail + "</tem:DeliveryEmail>" + "\n" +
                    @"                  <tem:WhsCodeTarget>" + outboundOrder.WhsCodeTarget + "</tem:WhsCodeTarget>" + "\n" +
                    @"                  <tem:FullShipment>" + outboundOrder.FullShipment + "</tem:FullShipment>" + "\n" +
                    @"                  <tem:CarrierCode>" + outboundOrder.CarrierCode + "</tem:CarrierCode>" + "\n" +
                    @"                  <tem:RouteCode>" + outboundOrder.RouteCode + "</tem:RouteCode>" + "\n" +
                    @"                  <tem:Plate>" + outboundOrder.Plate + "</tem:Plate>" + "\n" +
                    @"                  <tem:Invoice>" + outboundOrder.Invoice + "</tem:Invoice>" + "\n" +
                    @"                  <tem:FactAddress1>" + outboundOrder.FactAddress1 + "</tem:FactAddress1>" + "\n" +
                    @"                  <tem:FactAddress2>" + outboundOrder.FactAddress2 + "</tem:FactAddress2>" + "\n" +
                    @"                  <tem:CountryNameFact>" + outboundOrder.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                    @"                  <tem:StateNameFact>" + outboundOrder.StateNameFact + "</tem:StateNameFact>" + "\n" +
                    @"                  <tem:CityNameFact>" + outboundOrder.CityNameFact + "</tem:CityNameFact>" + "\n" +
                    @"                  <tem:FactPhone>" + outboundOrder.FactPhone + "</tem:FactPhone>" + "\n" +
                    @"                  <tem:FactEmail>" + outboundOrder.FactEmail + "</tem:FactEmail>" + "\n" +
                    @"                  <tem:AllowCrossDock>" + outboundOrder.AllowCrossDock + "</tem:AllowCrossDock>" + "\n" +
                    @"                  <tem:AllowBackOrder>" + outboundOrder.AllowBackOrder + "</tem:AllowBackOrder>" + "\n" +
                    @"                  <tem:BranchCode>" + outboundOrder.BranchCode + "</tem:BranchCode>" + "\n" +
                    @"                  <tem:SpecialField1>" + outboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                    @"                  <tem:SpecialField2>" + outboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                    @"                  <tem:SpecialField3>" + outboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                    @"                  <tem:SpecialField4>" + outboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                    @"                  <tem:StateInterface>" + outboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                    @"                  <tem:DateCreatedERP>" + outboundOrder.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                    @"                  <tem:DateReadWMS>" + outboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                    @"                  <tem:OutboundDetailsIfz>" + "\n" +
                    @"                     <tem:OutboundDetailIfz>" + "\n" +
                    @"                        <tem:OutboundOrderIfz/>" + "\n" +
                    @"                        <tem:LineNumber>" + outboundOrder.ListOutboundOrderDetailDTO[0].LineNumber + "</tem:LineNumber>" + "\n" +
                    @"                        <tem:LineCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].LineCode + "</tem:LineCode>" + "\n" +
                    @"                        <tem:ItemCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].ItemCode + "</tem:ItemCode>" + "\n" +
                    @"                        <tem:CtgCode>" + outboundOrder.ListOutboundOrderDetailDTO[0].CtgCode + "</tem:CtgCode>" + "\n" +
                    @"                        <tem:ItemQty>" + outboundOrder.ListOutboundOrderDetailDTO[0].ItemQty + "</tem:ItemQty>" + "\n" +
                    @"                        <tem:Status>" + outboundOrder.ListOutboundOrderDetailDTO[0].Status + "</tem:Status>" + "\n" +
                    @"                        <tem:LotNumber>" + outboundOrder.ListOutboundOrderDetailDTO[0].LotNumber + "</tem:LotNumber>" + "\n" +
                    @"                        <tem:FifoDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].FifoDate + "</tem:FifoDate>" + "\n" +
                    @"                        <tem:ExpirationDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                    @"                        <tem:FabricationDate>" + outboundOrder.ListOutboundOrderDetailDTO[0].FabricationDate + "</tem:FabricationDate>" + "\n" +
                    @"                        <tem:GrpClass1>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass1 + "</tem:GrpClass1>" + "\n" +
                    @"                        <tem:GrpClass2>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass2 + "</tem:GrpClass2>" + "\n" +
                    @"                        <tem:GrpClass3>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass3 + "</tem:GrpClass3>" + "\n" +
                    @"                        <tem:GrpClass4>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass4 + "</tem:GrpClass4>" + "\n" +
                    @"                        <tem:GrpClass5>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass5 + "</tem:GrpClass5>" + "\n" +
                    @"                        <tem:GrpClass6>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass6 + "</tem:GrpClass6>" + "\n" +
                    @"                        <tem:GrpClass7>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass7 + "</tem:GrpClass7>" + "\n" +
                    @"                        <tem:GrpClass8>" + outboundOrder.ListOutboundOrderDetailDTO[0].GrpClass8 + "</tem:GrpClass8>" + "\n" +
                    @"                        <tem:SpecialField1>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField1 + "</tem:SpecialField1>" + "\n" +
                    @"                        <tem:SpecialField2>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField2 + "</tem:SpecialField2>" + "\n" +
                    @"                        <tem:SpecialField3>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField3 + "</tem:SpecialField3>" + "\n" +
                    @"                        <tem:SpecialField4>" + outboundOrder.ListOutboundOrderDetailDTO[0].SpecialField4 + "</tem:SpecialField4>" + "\n" +
                    @"                        <tem:StateInterface>" + outboundOrder.ListOutboundOrderDetailDTO[0].StateInterface + "</tem:StateInterface>" + "\n" +
                    @"                        <tem:DateCreatedERP>" + outboundOrder.ListOutboundOrderDetailDTO[0].DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                    @"                        <tem:DateReadWMS>" + outboundOrder.ListOutboundOrderDetailDTO[0].DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                    @"                     </tem:OutboundDetailIfz>" + "\n" +
                    @"                  </tem:OutboundDetailsIfz>" + "\n" +
                    @"               </tem:OutboundOrderIfz>" + "\n" +
                    @"            </tem:ListOutboundOrderIfz>" + "\n" +
                    @"         </tem:outboundOrderIfzFun>" + "\n" +
                    @"      </tem:ImportOutboundOrder>" + "\n" +
                    @"   </soapenv:Body>" + "\n" +
                    @"</soapenv:Envelope>";
                request.AddParameter("text/xml", body, ParameterType.RequestBody);
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
            else
            {
                var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportOutboundOrder");
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
                    @"      <tem:ImportOutboundOrder>" + "\n" +
                    @"         <tem:outboundOrderIfzFun>" + "\n" +
                    @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                    @"            <tem:ListOutboundOrderIfz>" + "\n" +
                    @"               <tem:OutboundOrderIfz>" + "\n" +
                    @"                  <tem:Comment>" + outboundOrder.Comment + "</tem:Comment>" + "\n" +
                    @"                  <tem:WhsCode>" + outboundOrder.WhsCode + "</tem:WhsCode>" + "\n" +
                    @"                  <tem:OwnCode>" + outboundOrder.OwnCode + "</tem:OwnCode>" + "\n" +
                    @"                  <tem:Number>" + outboundOrder.OutboundNumber + "</tem:Number>" + "\n" +
                    @"                  <tem:OutboundTypeCode>" + outboundOrder.OutboundTypeCode + "</tem:OutboundTypeCode>" + "\n" +
                    @"                  <tem:Status>" + outboundOrder.Status + "</tem:Status>" + "\n" +
                    @"                  <tem:ReferenceNumber>" + outboundOrder.ReferenceNumber + "</tem:ReferenceNumber>" + "\n" +
                    @"                  <tem:LoadCode>" + outboundOrder.LoadCode + "</tem:LoadCode>" + "\n" +
                    @"                  <tem:LoadSeq>" + outboundOrder.LoadSeq + "</tem:LoadSeq>" + "\n" +
                    @"                  <tem:Priority>" + outboundOrder.Priority + "</tem:Priority>" + "\n" +
                    @"                  <tem:InmediateProcess>" + outboundOrder.InmediateProcess + "</tem:InmediateProcess>" + "\n" +
                    @"                  <tem:EmissionDate>" + outboundOrder.EmissionDate + "</tem:EmissionDate>" + "\n" +
                    @"                  <tem:ExpectedDate>" + outboundOrder.ExpectedDate + "</tem:ExpectedDate>" + "\n" +
                    @"                  <tem:ShipmentDate>" + outboundOrder.ShipmentDate + "</tem:ShipmentDate>" + "\n" +
                    @"                  <tem:ExpirationDate>" + outboundOrder.ExpirationDate + "</tem:ExpirationDate>" + "\n" +
                    @"                  <tem:CancelDate>" + outboundOrder.CancelDate + "</tem:CancelDate>" + "\n" +
                    @"                  <tem:CancelUser>" + outboundOrder.CancelUser + "</tem:CancelUser>" + "\n" +
                    @"                  <tem:CustomerCode>" + outboundOrder.CustomerCode + "</tem:CustomerCode>" + "\n" +
                    @"                  <tem:CustomerName>" + outboundOrder.CustomerName + "</tem:CustomerName>" + "\n" +
                    @"                  <tem:DeliveryAddress1>" + outboundOrder.DeliveryAddress1 + "</tem:DeliveryAddress1>" + "\n" +
                    @"                  <tem:DeliveryAddress2>" + outboundOrder.DeliveryAddress2 + "</tem:DeliveryAddress2>" + "\n" +
                    @"                  <tem:CountryNameDelivery>" + outboundOrder.CountryNameDelivery + "</tem:CountryNameDelivery>" + "\n" +
                    @"                  <tem:StateNameDelivery>" + outboundOrder.StateNameDelivery + "</tem:StateNameDelivery>" + "\n" +
                    @"                  <tem:CityNameDelivery>" + outboundOrder.CityNameDelivery + "</tem:CityNameDelivery>" + "\n" +
                    @"                  <tem:DeliveryPhone>" + outboundOrder.DeliveryPhone + "</tem:DeliveryPhone>" + "\n" +
                    @"                  <tem:DeliveryEmail>" + outboundOrder.DeliveryEmail + "</tem:DeliveryEmail>" + "\n" +
                    @"                  <tem:WhsCodeTarget>" + outboundOrder.WhsCodeTarget + "</tem:WhsCodeTarget>" + "\n" +
                    @"                  <tem:FullShipment>" + outboundOrder.FullShipment + "</tem:FullShipment>" + "\n" +
                    @"                  <tem:CarrierCode>" + outboundOrder.CarrierCode + "</tem:CarrierCode>" + "\n" +
                    @"                  <tem:RouteCode>" + outboundOrder.RouteCode + "</tem:RouteCode>" + "\n" +
                    @"                  <tem:Plate>" + outboundOrder.Plate + "</tem:Plate>" + "\n" +
                    @"                  <tem:Invoice>" + outboundOrder.Invoice + "</tem:Invoice>" + "\n" +
                    @"                  <tem:FactAddress1>" + outboundOrder.FactAddress1 + "</tem:FactAddress1>" + "\n" +
                    @"                  <tem:FactAddress2>" + outboundOrder.FactAddress2 + "</tem:FactAddress2>" + "\n" +
                    @"                  <tem:CountryNameFact>" + outboundOrder.CountryNameFact + "</tem:CountryNameFact>" + "\n" +
                    @"                  <tem:StateNameFact>" + outboundOrder.StateNameFact + "</tem:StateNameFact>" + "\n" +
                    @"                  <tem:CityNameFact>" + outboundOrder.CityNameFact + "</tem:CityNameFact>" + "\n" +
                    @"                  <tem:FactPhone>" + outboundOrder.FactPhone + "</tem:FactPhone>" + "\n" +
                    @"                  <tem:FactEmail>" + outboundOrder.FactEmail + "</tem:FactEmail>" + "\n" +
                    @"                  <tem:AllowCrossDock>" + outboundOrder.AllowCrossDock + "</tem:AllowCrossDock>" + "\n" +
                    @"                  <tem:AllowBackOrder>" + outboundOrder.AllowBackOrder + "</tem:AllowBackOrder>" + "\n" +
                    @"                  <tem:BranchCode>" + outboundOrder.BranchCode + "</tem:BranchCode>" + "\n" +
                    @"                  <tem:SpecialField1>" + outboundOrder.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                    @"                  <tem:SpecialField2>" + outboundOrder.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                    @"                  <tem:SpecialField3>" + outboundOrder.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                    @"                  <tem:SpecialField4>" + outboundOrder.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                    @"                  <tem:StateInterface>" + outboundOrder.StateInterface + "</tem:StateInterface>" + "\n" +
                    @"                  <tem:DateCreatedERP>" + outboundOrder.DateCreateERP + "</tem:DateCreatedERP>" + "\n" +
                    @"                  <tem:DateReadWMS>" + outboundOrder.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                    @"               </tem:OutboundOrderIfz>" + "\n" +
                    @"            </tem:ListOutboundOrderIfz>" + "\n" +
                    @"         </tem:outboundOrderIfzFun>" + "\n" +
                    @"      </tem:ImportOutboundOrder>" + "\n" +
                    @"   </soapenv:Body>" + "\n" +
                    @"</soapenv:Envelope>";
                request.AddParameter("text/xml", body, ParameterType.RequestBody);
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
}
