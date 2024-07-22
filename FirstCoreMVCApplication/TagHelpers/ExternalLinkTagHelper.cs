using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FirstCoreMVCApplication.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "exeternal-link")]
    public class ExternalLinkTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("target", "_blank");
            // output.Attributes.SetAttribute("rel", "noopener noreferrer");
            output.Attributes.Add("class", "external-link");
        }
    }
}
