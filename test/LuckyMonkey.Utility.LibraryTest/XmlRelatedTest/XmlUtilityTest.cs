using LuckyMonkey.Utility.Library.XmlRelated;
using System;
using System.Collections.Generic;
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
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><country><city><name>黑龙江</name><name>哈尔滨</name><name>大庆</name></city></country>";


            var result = XmlUtility.XmlToObject<Country>(xml, null);
            Assert.True(result.Name == "黑龙江");
        }

        [XmlRoot("country")]
        public class Country
        {
            [XmlArray("city")]
            public string City { get; set; }

            [XmlElement("name")]
            public string Name { get; set; }

            //public string Province { get; set; }
            //public string Province { get; set; }
            //public string Province { get; set; }
            //public string Province { get; set; }

        }
    }
}
