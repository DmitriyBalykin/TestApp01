using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TestApp01.Model;

namespace TestApp01.Search
{
    public class SearchEngine
    {
        private static readonly Regex RegexStripHtml = new Regex("<[^>]*>", RegexOptions.Compiled);
        private static string StripHtml(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                return string.Empty;
            }
            else
            {
                return RegexStripHtml.Replace(html, string.Empty).Trim();
            }
        }
        private static string CleanContent(string content, bool removeHtml)
        {
            if (removeHtml)
            {
                content = StripHtml(content);
            }
            string[] replaceStrings = new []{"\\", "|", "(",")","[", "]","{", "}", "?", "*","^", "+"};

            foreach (var replace in replaceStrings)
            {
                content = content.Replace(replace, string.Empty); 
            }
            var words = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            foreach (var word in words.Select((t => t.ToLowerInvariant().Trim())).Where(word => word.Length > 1))
            {
                sb.AppendFormat("{0}", word);
            }
            return sb.ToString();
        }
        public static IEnumerable<User> Search(string searchString, IQueryable<User> source)
        {
            var term = CleanContent(searchString.ToLowerInvariant().Trim(), false);
            var terms = term.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            var regex = string.Format(CultureInfo.InvariantCulture, "({0})", string.Join("|", terms));
            foreach (var entry in source)
            {
                var rank = 0;
                if (!string.IsNullOrWhiteSpace(entry.Email))
                {
                    rank += Regex.Matches(entry.Email.ToLowerInvariant(), regex).Count;
                }
                if (rank > 0)
                {
                    yield return entry;
                }
            }
        }
    }
}