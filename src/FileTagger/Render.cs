using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileTagger
{
    public static class Render
    {
        private const string ScriptTemplate = "<script src='{0}' type='text/javascript'></script>";
        private const string LinkTemplate = "<link href='{0}' rel='stylesheet' />";

        private static IEnumerable<string> GetFiles(string search, int count = 0)
        {
            var lastSegment = search.LastIndexOf('/');

            var dirName = search.Substring(0, lastSegment);
            
            var path = VirtualPathUtility.ToAbsolute(dirName);

            var folder = new DirectoryInfo(HttpContext.Current.Server.MapPath(dirName));

            if (!folder.Exists)
                return Enumerable.Empty<string>();

            var fileSearch = search.Substring(lastSegment + 1);

            var results = folder.GetFiles(fileSearch)
                                  .Select(file => path + "/" + file.Name);

            if (count > 0)
                results = results.Take(count);

            return results;
        }

        private static MvcHtmlString CreateTags(string search, string template, int count = 0)
        {
            var tags = GetFiles(search, count)
                        .Select(file => String.Format(template, file));

            var retVal = String.Join(Environment.NewLine, tags);

            return MvcHtmlString.Create(retVal);
        }

        #region Public API

        public static MvcHtmlString Tag(string search, string template)
        {
            return CreateTags(search, template, 1);
        }

        public static MvcHtmlString Tags(string search, string template, int limit = 0)
        {
            return CreateTags(search, template, limit);
        }

        public static MvcHtmlString Script(string search)
        {
            return Tag(search, ScriptTemplate);
        }

        public static MvcHtmlString Scripts(string search, int limit = 0)
        {
            return Tags(search, ScriptTemplate, limit);
        }

        public static MvcHtmlString Link(string search)
        {
            return Tag(search, LinkTemplate);
        }

        public static MvcHtmlString Links(string search, int limit = 0)
        {
            return Tags(search, LinkTemplate, limit);
        }

        #endregion
    }
}