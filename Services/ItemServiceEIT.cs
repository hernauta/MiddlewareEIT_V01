using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Configuration;

namespace MiddlewareEIT.API.Services
{
    public class ItemServiceEIT
    {
        public static string GetRequestItem(ItemDTO item)
        {
            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportItem");
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
                @"      <tem:ImportItem>" + "\n" +
                @"         <tem:itemIfzFun>" + "\n" +
                @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
                @"            <tem:ListItemIfz>" + "\n" +
                @"               <tem:ItemIfz>" + "\n" +
                @"                  <tem:Code>" + item.ItemCode + "</tem:Code>" + "\n" +
                @"                  <tem:OwnCode>" + item.OwnCode + "</tem:OwnCode>" + "\n" +
                @"                  <tem:AltItemCode>" + item.AltItemCode + "</tem:AltItemCode>" + "\n" +
                @"                  <tem:Description>" + item.Description + "</tem:Description>" + "\n" +
                @"                  <tem:GrpItem1Code>" + item.GrpItem1Code + "</tem:GrpItem1Code>" + "\n" +
                @"                  <tem:GrpItem2Code>" + item.GrpItem2Code + "</tem:GrpItem2Code>" + "\n" +
                @"                  <tem:GrpItem3Code>" + item.GrpItem3Code + "</tem:GrpItem3Code>" + "\n" +
                @"                  <tem:GrpItem4Code>" + item.GrpItem4Code + "</tem:GrpItem4Code>" + "\n" +
                @"                  <tem:LongItemName>" + item.LongItemName + "</tem:LongItemName>" + "\n" +
                @"                  <tem:ShortItemName>" + item.ShortItemName + "</tem:ShortItemName>" + "\n" +
                @"                  <tem:Status>" + item.Status + "</tem:Status>" + "\n" +
                @"                  <tem:ItemComment>" + item.ItemComment + "</tem:ItemComment>" + "\n" +
                @"                  <tem:ShelfLife>" + item.ShelfLife + "</tem:ShelfLife>" + "\n" +
                @"                  <tem:ExpirationDays>" + item.ExpirationDays + "</tem:ExpirationDays>" + "\n" +
                @"                  <tem:CtrlSerialInbound>" + item.CtrlSerialInbound + "</tem:CtrlSerialInbound>" + "\n" +
                @"                  <tem:CtrlSerialInternal>" + item.CtrlSerialInternal + "</tem:CtrlSerialInternal>" + "\n" +
                @"                  <tem:CtrlSerialOutbound>" + item.CtrlSerialOutbound + "</tem:CtrlSerialOutbound>" + "\n" +
                @"                  <tem:LotControlInbound>" + item.LotControlInbound + "</tem:LotControlInbound>" + "\n" +
                @"                  <tem:LotControlInternal>" + item.LotControlInternal + "</tem:LotControlInternal>" + "\n" +
                @"                  <tem:LotControlOutbound>" + item.LotControlOutbound + "</tem:LotControlOutbound>" + "\n" +
                @"                  <tem:Weight>" + item.Weight + "</tem:Weight>" + "\n" +
                @"                  <tem:Volume>" + item.Volume + "</tem:Volume>" + "\n" +
                @"                  <tem:Length>" + item.Length + "</tem:Length>" + "\n" +
                @"                  <tem:Width>" + item.Width + "</tem:Width>" + "\n" +
                @"                  <tem:Height>" + item.Height + "</tem:Height>" + "\n" +
                @"                  <tem:NestedVolume>" + item.NestedVolume + "</tem:NestedVolume>" + "\n" +
                @"                  <tem:InspectionRequerid>" + item.InspectionRequerid + "</tem:InspectionRequerid>" + "\n" +
                @"                  <tem:InspectionCode>" + item.InspectionCode + "</tem:InspectionCode>" + "\n" +
                @"                  <tem:CtrlExpiration>" + item.CtrlExpiration + "</tem:CtrlExpiration>" + "\n" +
                @"                  <tem:CtrlFabrication>" + item.CtrlFabrication + "</tem:CtrlFabrication>" + "\n" +
                @"                  <tem:Acumulable>" + item.Acumulable + "</tem:Acumulable>" + "\n" +
                @"                  <tem:ReOrderPoint>" + item.ReOrderPoint + "</tem:ReOrderPoint>" + "\n" +
                @"                  <tem:ReOrderQty>" + item.ReOrderQty + "</tem:ReOrderQty>" + "\n" +
                @"                  <tem:PalletQty>" + item.PalletQty + "</tem:PalletQty>" + "\n" +
                @"                  <tem:CutMinimum>" + item.CutMinimum + "</tem:CutMinimum>" + "\n" +
                @"                  <tem:Originator>" + item.Originator + "</tem:Originator>" + "\n" +
                @"                  <tem:VasProfile>" + item.VasProfile + "</tem:VasProfile>" + "\n" +
                @"                  <tem:Hazard>" + item.Hazard + "</tem:Hazard>" + "\n" +
                @"                  <tem:Price>" + item.Price + "</tem:Price>" + "\n" +
                @"                  <tem:InventoryType>" + item.InventoryType + "</tem:InventoryType>" + "\n" +
                @"                  <tem:StackingSequence>" + item.StackingSequence + "</tem:StackingSequence>" + "\n" +
                @"                  <tem:CommentControl>" + item.CommentControl + "</tem:CommentControl>" + "\n" +
                @"                  <tem:CompatibilyCode>" + item.CompatibilyCode + "</tem:CompatibilyCode>" + "\n" +
                @"                  <tem:MsdsUrl>" + item.MsdsUrl + "</tem:MsdsUrl>" + "\n" +
                @"                  <tem:PictureUrl>" + item.PictureUrl + "</tem:PictureUrl>" + "\n" +
                @"                  <tem:GrpClass1>" + item.GrpClass1 + "</tem:GrpClass1>" + "\n" +
                @"                  <tem:GrpClass2>" + item.GrpClass2 + "</tem:GrpClass2>" + "\n" +
                @"                  <tem:GrpClass3>" + item.GrpClass3 + "</tem:GrpClass3>" + "\n" +
                @"                  <tem:GrpClass4>" + item.GrpClass4 + "</tem:GrpClass4>" + "\n" +
                @"                  <tem:GrpClass5>" + item.GrpClass5 + "</tem:GrpClass5>" + "\n" +
                @"                  <tem:GrpClass6>" + item.GrpClass6 + "</tem:GrpClass6>" + "\n" +
                @"                  <tem:GrpClass7>" + item.GrpClass7 + "</tem:GrpClass7>" + "\n" +
                @"                  <tem:GrpClass8>" + item.GrpClass8 + "</tem:GrpClass8>" + "\n" +
                @"                  <tem:SpecialField1>" + item.SpecialField1 + "</tem:SpecialField1>" + "\n" +
                @"                  <tem:SpecialField2>" + item.SpecialField2 + "</tem:SpecialField2>" + "\n" +
                @"                  <tem:SpecialField3>" + item.SpecialField3 + "</tem:SpecialField3>" + "\n" +
                @"                  <tem:SpecialField4>" + item.SpecialField4 + "</tem:SpecialField4>" + "\n" +
                @"                  <tem:StateInterface>" + item.StateInterface + "</tem:StateInterface>" + "\n" +
                @"                  <tem:DateCreatedERP>" + item.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
                @"                  <tem:DateReadWMS>" + item.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
                @"               </tem:ItemIfz>" + "\n" +
                @"            </tem:ListItemIfz>" + "\n" +
                @"         </tem:itemIfzFun>" + "\n" +
                @"      </tem:ImportItem>" + "\n" +
                @"   </soapenv:Body>" + "\n" +
                @"</soapenv:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return (response.Content);
        }
    }
}
