using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace ThTest.Infrastructures
{
    [HtmlTargetElement("input", Attributes = ForAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class InvariantNumberTagHelper: InputTagHelper
    {
        private const string ForAttributeName = "asp-for";

        private IHtmlGenerator _generator;

        [HtmlAttributeName("asp-is-invariant")]
        public bool IsInvariant { get; set; }

        public InvariantNumberTagHelper(IHtmlGenerator generator)
            : base(generator)
        {
            this._generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (this.IsInvariant
                && output.TagName == "input"
                && this.For.Model != null
                && this.For.Model is decimal)
            {
                if (decimal.TryParse(this.For.Model.ToString(), out decimal value))
                {
                    var invariantValue = value.ToString(Thread.CurrentThread.CurrentCulture);

                    output.Attributes.SetAttribute(new TagHelperAttribute("value", invariantValue));
                }
            }
        }
    }
}
