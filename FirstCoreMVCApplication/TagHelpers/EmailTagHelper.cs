using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FirstCoreMVCApplication.TagHelpers
{
    [HtmlTargetElement("email")]
    public class EmailTagHelper : TagHelper
    {
        private const string EmailDomain = "dotnettutorials.net";

        [HtmlAttributeName("for-email")]
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Change the tag name to <a>
            // Replaces <email> with <a> tag
            output.TagName = "a";

            var address = MailTo + "@" + EmailDomain;

            //Set the href attribute of the anchot tag as the email address
            output.Attributes.SetAttribute("href", "mailto:" + address);
            var obfuscatedEmail = "Email Us";

            output.Content.SetContent(obfuscatedEmail);
        }
    }
}
