using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Data;
using System.Diagnostics;

namespace UI.WebService
{
    /// <summary>
    /// Summary description for WebServiceEventLog
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceEventLog : System.Web.Services.WebService
    {

        [WebMethod]
        public string ConvertDataTableToXML(DataTable dt)
        {
            DataTable currentPageData = dt.Clone();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                currentPageData.ImportRow(dt.Rows[i]);
            }

            StringWriter stringWriter = new StringWriter();
            currentPageData.WriteXml(stringWriter);
            return stringWriter.ToString();
        }
    }
}
