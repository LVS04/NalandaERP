using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

public static class Util
    {
        public static string CreateLink(IUrlHelper url, string Controller, string Action, string text, Guid Id, string cssClass = null, string onClick = null)
        {
            string href = url.Action(Action, Controller, new { Id = Id });
            return string.Format("<a href='{0}' class='{1}' onclick='{2}'>{3}</a>", href, cssClass, onClick, text);

        }
}
