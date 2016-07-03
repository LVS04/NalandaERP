using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Text;

namespace DNXTest.Helpers
{
    public static class WebHelpers
    {
        public static string CreateLink(IUrlHelper url, string Controller, string Action, string text, Guid Id, string cssClass = null, string onClick = null)
        {
            string href = url.Action(Action, Controller, new { Id = Id });
            return string.Format("<a href='{0}' class='{1}' onclick=\"{2}\">{3}</a>", href, cssClass, onClick, text);
        }

        public static string CreateTable(string columns, string columnsTexts = null)
        {
            string[] columnsArray = columns.Replace("'", "").Split(',');
            string[] textsArray = columns.Split(',');

            StringBuilder htmlOutput = new StringBuilder();
            
            for( int index=0;index< columnsArray.Length; index++)
            {
                string column = columnsArray[index];
                string[] columnParts = column.Split('.');
                string columnField = columnParts[1].Replace("\"", "");

                string columnText;
                if (columnsTexts == null)
                    columnText = columnField;
                else
                    columnText = textsArray[index];

                htmlOutput.AppendFormat("<th data-column-id='{0}'data-sortable='false' >{1}</th>", columnField, columnText);
            }

            return htmlOutput.ToString();
        }
    }
}
