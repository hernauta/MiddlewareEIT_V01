using MiddlewareEIT.BL.DTOs;
using RestSharp;
using System;
using System.Configuration;

namespace MiddlewareEIT.API.Services
{
    public class ItemUomServiceEIT
    {
        public static string GetRequestItemUom(ItemUomDTO itemUom)
        {
            var client = new RestClient("http://200.6.96.183/WMSTekWS/wsImportIfz.asmx?op=ImportItemUom");
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
            @"      <tem:ImportItemUom>" + "\n" +
            @"         <tem:itemUomIfzFun>" + "\n" +
            @"            <tem:NroTicket>" + 0 + "</tem:NroTicket>" + "\n" +
            @"            <tem:ListItemUomIfz>" + "\n" +
            @"               <tem:ItemUomIfz>" + "\n" +
            @"                  <tem:OwnCode>" + itemUom.OwnCode + "</tem:OwnCode>" + "\n" +
            @"                  <tem:ItemCode>" + itemUom.ItemCode + "</tem:ItemCode>" + "\n" +
            @"                  <tem:UomCode>" + itemUom.UomCode + "</tem:UomCode>" + "\n" +
            @"                  <tem:ConversionFactor>" + itemUom.ConversionFactor + "</tem:ConversionFactor>" + "\n" +
            @"                  <tem:BarCode>" + itemUom.BarCode + "</tem:BarCode>" + "\n" +
            @"                  <tem:UomName>" + itemUom.UomName + "</tem:UomName>" + "\n" +
            @"                  <tem:Length>" + itemUom.Length + "</tem:Length>" + "\n" +
            @"                  <tem:Width>" + itemUom.Width + "</tem:Width>" + "\n" +
            @"                  <tem:Height>" + itemUom.Height + "</tem:Height>" + "\n" +
            @"                  <tem:Volume>" + itemUom.Volume + "</tem:Volume>" + "\n" +
            @"                  <tem:Weight>" + itemUom.Weight + "</tem:Weight>" + "\n" +
            @"                  <tem:Status>" + itemUom.Status + "</tem:Status>" + "\n" +
            @"                  <tem:LayoutUomQty>" + itemUom.LayoutUomQty + "</tem:LayoutUomQty>" + "\n" +
            @"                  <tem:LayoutUnitQty>" + itemUom.LayoutUnitQty + "</tem:LayoutUnitQty>" + "\n" +
            @"                  <tem:LayoutMaxWeightUpon>" + itemUom.LayoutMaxWeightUpon + "</tem:LayoutMaxWeightUpon>" + "\n" +
            @"                  <tem:PutawayZone>" + itemUom.PutawayZone + "</tem:PutawayZone>" + "\n" +
            @"                  <tem:PickArea>" + itemUom.PickArea + "</tem:PickArea>" + "\n" +
            @"                  <tem:SpecialField1>" + itemUom.SpecialField1 + "</tem:SpecialField1>" + "\n" +
            @"                  <tem:SpecialField2>" + itemUom.SpecialField2 + "</tem:SpecialField2>" + "\n" +
            @"                  <tem:SpecialField3>" + itemUom.SpecialField3 + "</tem:SpecialField3>" + "\n" +
            @"                  <tem:SpecialField4>" + itemUom.SpecialField4 + "</tem:SpecialField4>" + "\n" +
            @"                  <tem:StateInterface>" + itemUom.StateInterface + "</tem:StateInterface>" + "\n" +
            @"                  <tem:DateCreatedERP>" + itemUom.DateCreatedERP + "</tem:DateCreatedERP>" + "\n" +
            @"                  <tem:DateReadWMS>" + itemUom.DateReadWMS + "</tem:DateReadWMS>" + "\n" +
            @"               </tem:ItemUomIfz>" + "\n" +
            @"            </tem:ListItemUomIfz>" + "\n" +
            @"         </tem:itemUomIfzFun>" + "\n" +
            @"      </tem:ImportItemUom>" + "\n" +
            @"   </soapenv:Body>" + "\n" +
            @"</soapenv:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return (response.Content);
        }
    }
}
