using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TestApp01.Helper
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl)
        {
            StringBuilder sb = new StringBuilder();

            var prevBuilder = new TagBuilder("a");
            prevBuilder.InnerHtml = "<<";
            if (currentPage == 1)
            {
                prevBuilder.MergeAttribute("href","#");
                sb.Append("<li class=\"active\">");
            }
            else
            {
                prevBuilder.MergeAttribute("href", pageUrl.Invoke(currentPage - 1));
                sb.Append("<li>");
            }
            sb.Append(prevBuilder.ToString()).AppendLine("</li>");

            for (int i = 1; i <= totalPages; i++)
            {
                if ((i <= 3 || i > totalPages - 3) || ((i > (currentPage - 2)) && (i < (currentPage + 2))))
                {
                    var subBuilder = new TagBuilder("a");
                    subBuilder.InnerHtml = i.ToString(CultureInfo.InvariantCulture);
                    if (i == currentPage)
                    {
                        subBuilder.MergeAttribute("href", "#");
                        sb.Append("<li class=\"active\">");
                    }
                    else
                    {
                        subBuilder.MergeAttribute("href", pageUrl.Invoke(i));
                        sb.Append("<li>");
                    }
                    sb.Append(subBuilder.ToString()).AppendLine("</li>"); 
                }
                else if((i == 4 && currentPage > 5) || 
                    (i == (totalPages - 3 ) && currentPage < (totalPages - 4)))
                {
                    sb.AppendLine("<li class=\"disabled\"><a href=\"#\">...</a></li>");
                }                
            }

            var nextBuilder = new TagBuilder("a");
            nextBuilder.InnerHtml = ">>";

            if (currentPage == totalPages)
            {
                nextBuilder.MergeAttribute("href","#");
                sb.Append("<li class=\"active\">");
            }
            else
            {
                nextBuilder.MergeAttribute("href",pageUrl.Invoke(currentPage + 1));
                sb.Append("<li>");
            }
            sb.Append(nextBuilder.ToString()).AppendLine("</li>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}