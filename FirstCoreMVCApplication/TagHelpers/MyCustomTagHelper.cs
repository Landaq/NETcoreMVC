using Microsoft.AspNetCore.Razor.TagHelpers;

using System.Text;

namespace FirstCoreMVCApplication.TagHelpers
{
    [HtmlTargetElement("employee-details")]
    public class MyCustomTagHelper : TagHelper
    {
        // PascalCase gets translated into Camel-case.
        // Can be passed via <my-custom employee-id="..." />
       [HtmlAttributeName("for-id")]
        public int EmployeeId { get; set; }

        // Can be passed via <my-custom employee-name="..." />
        [HtmlAttributeName("for-name")]
        public string? EmployeeName { get; set; }

        // Can be passed via <my-custom designation="..." />
        [HtmlAttributeName("for-designation")]
        public string? Designation {  get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //TagName: The HTML element's tag name
            //A whitespace or null value results in no start or end tag being rendered.
            output.TagName = "EmployeeSectionTagHelper"; // Set the HTML element name

            //TagMode: Syntax of the element in the generated HTML.
            //StartTagAndEndTag: Include both start and end tags.
            output.TagMode = TagMode.StartTagAndEndTag;

            //Create a String Builder Object to Hold the Employee Informations
            var sb= new StringBuilder();
            sb.AppendFormat($"<span>Employee Id:</span> <strong>{EmployeeId}</strong> <br />");
            sb.AppendFormat($"<span>Employee Name:</span> <strong>{EmployeeName}</strong><br/>");
            sb.AppendFormat($"<span>Employee Designation:</span> <strong>{Designation}</strong><br/>");

            //Convert the StringBuilder Object to String Type and
            //then set that string as the content either using SetContent and SetHtmlContent method
            //Content: Get or set the HTML element's main content.
            //SetHtmlContent: Sets the content.
            //output.Content.SetHtmlContent(sb.ToString());
            //output.Content.SetContent(sb.ToString());
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
