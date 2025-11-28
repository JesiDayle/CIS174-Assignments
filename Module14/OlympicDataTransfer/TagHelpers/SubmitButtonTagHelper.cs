using Microsoft.AspNetCore.Razor.TagHelpers;

namespace OlympicDataTransfer.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "submit-button")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public string CssClass { get; set; } = "btn btn-primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", CssClass);
            output.Attributes.SetAttribute("type", "submit");
        }
    }
}
