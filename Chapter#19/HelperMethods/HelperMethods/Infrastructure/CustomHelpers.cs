using System.Collections.Generic;
using System.Web.Mvc;

namespace HelperMethods.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper htmlHelper, IEnumerable<string> items)
        {
            var ul = new TagBuilder("ul");
            foreach (var item in items)
            {
                var li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }

        public static MvcHtmlString DisplayMessage(this HtmlHelper htmlHelper, string message)
        {
            return new MvcHtmlString(string.Format("This is the message: <p>{0}</p>", message));
        }
        public static MvcHtmlString DisplayMessageFixed(this HtmlHelper htmlHelper, string message)
        {
            var encodedMessage = htmlHelper.Encode(message);
            return new MvcHtmlString(string.Format("This is the message: <p>{0}</p>", encodedMessage));
        }
    }
}