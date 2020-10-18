using System;
using System.Web;

namespace CleanCode.LongMethods
{
    public class Download : System.Web.UI.Page
    {
        private readonly MemoryFile _memoryFile = new MemoryFile();
        private readonly DataSource _dataSource = new DataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClearContentResponse();
            SetCaching();
            WriteContentToResponse(CreateCSV());
        }

        private void WriteContentToResponse(byte[] byteArray)
        {
            Response.Charset = System.Text.Encoding.UTF8.WebName;
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "text/comma-separated-values";
            Response.AddHeader("Content-Disposition", "attachment; filename=FooFoo.csv");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.BinaryWrite(byteArray);
        }

        private void SetCaching()
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.CacheControl = "private";
            Response.AppendHeader("Expires", "60");
            Response.AppendHeader("Pragma", "cache");
        }

        private void ClearContentResponse()
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Cookies.Clear();
        }

        private byte[] CreateCSV()
        {
            var ms = _memoryFile.CreateMemoryFile(_dataSource.ReadFromDataTable());
            var byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();
            return byteArray;
        }
    }
}