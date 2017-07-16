using LuckyMonkey.Utility.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Xunit;

namespace LuckyMonkey.Utility.LibraryTest.XmlRelatedTest
{
    public class XmlUtilityTest
    {
        [Fact]
        public void XmlToObjectTest()
        {
            //string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><province><name>黑龙江</name><citys><city>哈尔滨</city><city>大庆</city></citys></province>";
            //string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><city><name>黑龙江</name><name>哈尔滨</name><name>大庆</name></city>";
            //string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><country><province><city><name>黑龙江</name><area>1000</area></city><city><name>河北</name><area>1000</area></city></province></country>";
            var xml = "<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName>" +
                "<![CDATA[FromUser]]></FromUserName><CreateTime>123456789</CreateTime>" +
                "<MsgType><![CDATA[event]]></MsgType><Event><![CDATA[subscribe]]></Event></xml>";

            var xml2 = "<xml><ToUserName><![CDATA[gh_8abd62eccf90]]></ToUserName>< FromUserName >< ![CDATA[oMogsw0MqBNgELnIVQVmCpUq0D2s]] ></ FromUserName >< CreateTime > 1500099754 </ CreateTime >< MsgType >< ![CDATA[event]]></MsgType><Event><![CDATA[unsubscribe]]></Event><EventKey><![CDATA[]]></EventKey></xml>";
            var result = XmlUtility.XmlToObject<WechatTest>(xml, null);
            Assert.True(result.ToUserName.Equals("toUser"));
        }

        [XmlRoot("xml")]
        public class WechatTest
        {
            [XmlElement("ToUserName")]
            public string ToUserName { get; set; }
            [XmlElement("FromUserName")]
            public string FromUserName { get; set; }
            [XmlElement("CreateTime")]
            public string CreateTime { get; set; }
            [XmlElement("MsgType")]
            public string MsgType { get; set; }
            [XmlElement("Event")]
            public string Event { get; set; }
        }

        [Fact]
        public void ObjectToXml()
        {
            var item = new Country
            {
                City = new List<City>()
                {
                   new City()
                   {
                        Name = "黑龙江",
                    Area = "100",
                   },
                   new City
                   {
                        Name = "河北",
                    Area = "100",
                   }

                },
            };
            var xmlStr = XmlUtility.ObjectToXml(item);
            Assert.True(true);
        }

        [XmlRoot("country")]
        public class Country
        {
            [XmlArray("province"),XmlArrayItem("city")]
            public List<City> City { get; set; }

            //[XmlElement("name")]
            //public List<string> Name { get; set; }

            //public string Province { get; set; }
            //public string Province { get; set; }
            //public string Province { get; set; }
            //public string Province { get; set; }

        }
        public class City
        {
            [XmlElement("name")]
            public string Name { get; set; }

            [XmlElement("area")]
            public string Area { get; set; }
        }

        [Fact]
        public void ReadXmlNodeValueTest()
        {
            var xml = "<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName>" +
                "<![CDATA[FromUser]]></FromUserName><CreateTime>123456789</CreateTime>" +
                "<MsgType><![CDATA[event]]></MsgType><Event><![CDATA[subscribe]]></Event></xml>";
            var result = XmlUtility.ReadXmlNodeValue("/xml/MsgType", xml);
            Assert.True(result.Equals("event"));
            Console.WriteLine(result);
        }
    }
}
