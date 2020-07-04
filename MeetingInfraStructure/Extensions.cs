using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace MeetingInfraStructure
{
    public static class Extensions
    {



        public static string AsString(this XmlDocument prmXmlDocument)
        {
            using (StringWriter tmpStringWriter = new StringWriter())
            {
                using (XmlTextWriter tmpXmlTextWriter = new XmlTextWriter(tmpStringWriter))
                {
                    prmXmlDocument.WriteTo(tmpXmlTextWriter);
                    string strXmlText = tmpStringWriter.ToString();
                    return strXmlText;
                }
            }
        }


        public static void Test()
        {
            string test = "dbksdjf";
            test = "dsdfgsfdsdf";
        }

    }
}
