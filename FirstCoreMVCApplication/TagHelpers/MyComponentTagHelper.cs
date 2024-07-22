using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FirstCoreMVCApplication.TagHelpers
{
    [HtmlTargetElement("my-component")]
    public class MyComponentTagHelper : TagHelper
    {
        // IViewComponentHelper: Supports the rendering of view components in a view.
        private readonly IViewComponentHelper _viewComponentHelper;

        // Initializing the _viewComponentHelper through Constructor
        public MyComponentTagHelper(IViewComponentHelper viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        // This Property will hold the parameter value required for MyComponentViewComponent
        public string? Param { get; set; }

        // Indicates the associated Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper property
        // should not be bound to HTML attributes
        [HtmlAttributeNotBound]
        // Specifies that a tag helper property should be set with the current ViewContext
        // when creating the tag helper
        [ViewContext]
        // Context for view execution
        public ViewContext ViewContext { get; set; }

        // Override the Process Method
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // IViewContextAware: Contract for contextualizing a property activated by a view with the ViewContext.
            // Contextualize: Contextualizes the instance with the specified viewContext
            ((IViewContextAware)_viewComponentHelper).Contextualize(ViewContext);

            var content = _viewComponentHelper.InvokeAsync("MyComponent", new { param = Param }).Result;
            output.Content.SetHtmlContent(content);
        }
    }
}
