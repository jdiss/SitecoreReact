using System.Web.Mvc;

namespace SitecoreReact
{
    public static class HtmlHelperExtentions
    {
        public static SitecoreReactHelper SitecoreReact(this HtmlHelper htmlHelper)
        {
            return new SitecoreReactHelper(htmlHelper);
        }
    }
}
