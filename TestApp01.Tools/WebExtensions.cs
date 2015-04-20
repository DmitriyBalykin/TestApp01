using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestApp01.Tools
{
    public static class WebExtensions
    {
        public static MvcHtmlString NlToBr(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return new MvcHtmlString(string.Empty);
            }
            return new MvcHtmlString(source.Replace(Environment.NewLine, "<br />"));
        }
        public static string Teaser(this string source, int lentgh, string more = "...")
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return string.Empty;
            }
            else if(source.Length <= lentgh)
            {
                return source;
            }
            else
            {
                return source.Substring(0, lentgh) + more;
            }
        }
        public static string CountWord(this int count, string first, string second, string five)
        {
            if (count % 10 == 1 && (int)(count / 10) != 1)
            {
                return first;
            }
            if (count % 10 > 1 && count % 10 < 5 && ((int)(count / 10) % 10) != 1)
            {
                return second;
            }
            return five;
        }
    }
}
