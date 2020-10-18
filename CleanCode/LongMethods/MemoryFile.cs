using System;
using System.Data;
using System.IO;

namespace CleanCode.LongMethods
{
    public class MemoryFile
    {
        public System.IO.MemoryStream CreateMemoryFile(DataTable dt)
        {
            var returnStream = new MemoryStream();
            var sw = new StreamWriter(returnStream);
            WriteColumnNames(dt, sw);
            WriteRows(dt, sw);

            sw.Flush();
            sw.Close();
            return returnStream;
        }

        private static void WriteRows(DataTable dt, StreamWriter sw)
        {
            foreach (DataRow dr in dt.Rows)
            {
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    WriteCell(dr, i, sw);
                    WriteSpacerIfNecessary(dt, i, sw);
                }

                sw.WriteLine();
            }
        }

        private static void WriteSpacerIfNecessary(DataTable dt, int i, StreamWriter sw)
        {
            if (i < dt.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }

        private static void WriteCell(DataRow dr, int i, StreamWriter sw)
        {
            if (!Convert.IsDBNull(dr[i]))
            {
                var str = $"\"{dr[i].ToString():c}\"".Replace("\r\n", " ");
                sw.Write(str);
            }
            else
            {
                sw.Write("");
            }
        }

        private static void WriteColumnNames(DataTable dt, StreamWriter sw)
        {
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }

            sw.WriteLine();
        }
    }
}