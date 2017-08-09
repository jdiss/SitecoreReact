using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.Mvc;
using Sitecore.Mvc.Helpers;

namespace SitecoreReact
{
    public class SitecoreReactHelper
    {
        private readonly SitecoreHelper _sitecoreHelper;
        private readonly string _script = "<script>window.SitecoreReact = window.SitecoreReact || {{}};window.SitecoreReact.Data = window.SitecoreReact.Data || {{}}; window.SitecoreReact.{0}='{1}'</script>";
        public SitecoreReactHelper(HtmlHelper htmlHelper)
        {
            _sitecoreHelper = htmlHelper.Sitecore();
        }

        public HtmlString Field(string fieldName)
        {
            var scHtml = _sitecoreHelper.Field(fieldName);
            var jsV = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(scHtml.ToHtmlString()));
            return new HtmlString(string.Format(_script, fieldName.Replace(' ', '_'), jsV));
        }

        public HtmlString AddData(string name, object obj)
        {
            var jsV = JsonConvert.SerializeObject(obj);
            return new HtmlString(string.Format(_script,"Data." + name.Replace(' ', '_'), jsV));
        }
    }
}
