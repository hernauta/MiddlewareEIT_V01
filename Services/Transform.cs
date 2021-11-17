using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RmiApiReversoEIT.Services
{
    public static class Transform
    {
        public static string Exec(string soapResponse)
        {
            var xm = XElement.Parse(soapResponse);
            //var response = RemoveAllNamespacesXml(xm).CleanXml().ToJson();

            var response = RemoveAllNamespacesXml(xm);
            var response2 = CleanXml(response);
            return response2;
        }

        public static string ExecJs(string soapResponse)
        {
            var xm = XElement.Parse(soapResponse);
            var response = RemoveAllNamespacesXml(xm);
            var response1 = CleanXml(response);
            var response2 = ToJson(response1);

            return response2;
        }

        private static string RemoveAllNamespacesXml(XElement xmlDocument)
        {
            try
            {
                if (!xmlDocument.HasElements)
                {
                    var xElement = new XElement(xmlDocument.Name.LocalName);
                    xElement.Value = xmlDocument.Value;

                    foreach (XAttribute attribute in xmlDocument.Attributes())
                        xElement.Add(attribute);

                    return xElement.ToString();
                }
                return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespacesXml(el))).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in T Remove Namespaces XML: " + ex.Message);
                //Elog.save(xmlDocument, ex);
                return "";
            }
        }

        private static string ToJson(string soapResponse2)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(soapResponse2);

            return JsonConvert.SerializeXmlNode(xmlDoc);
        }

        private static string CleanXml(this string soapResponse)
        {
            soapResponse = soapResponse.Replace("amp;", "").Replace("&lt;", "<").Replace("&gt;", ">");
            return soapResponse;
        }
    }
}
