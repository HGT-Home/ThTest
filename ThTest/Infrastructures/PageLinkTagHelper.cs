using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Models.ViewModels;

namespace ThTest.Infrastructures
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper: TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageNormal { get; set; }

        public string PageSelected { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrl { get; set; } = new Dictionary<string, object>();

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this._urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = this._urlHelperFactory.GetUrlHelper(this.ViewContext);
            TagBuilder div = new TagBuilder("div");
            for (int i = 1; i <= this.PageModel.TotalPages; i++)
            {
                TagBuilder a = new TagBuilder("a");
                this.PageUrl["page"] = i;
                a.Attributes["href"] = urlHelper.Action(this.PageAction, this.PageUrl);

                if (this.PageClassesEnabled)
                {
                    a.AddCssClass(this.PageClass);
                    a.AddCssClass(i == this.PageModel.CurrentPage ? this.PageSelected : this.PageNormal);
                }

                a.InnerHtml.Append(i.ToString());
                div.InnerHtml.AppendHtml(a);
            }

            output.Content.AppendHtml(div);
        }
    }
}
