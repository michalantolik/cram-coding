using Markdig;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace CramCoding.WebApp.TagHelpers
{
    /// <summary>
    /// Markdown tag which converts its markdown content to HTML
    /// </summary>
    /// <remarks><markdown> tag is replaced with <p> tag after conversion</remarks>
    [HtmlTargetElement("markdown")]
    public class MarkdownTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var markdownContent = (await output.GetChildContentAsync(NullHtmlEncoder.Default))
                                               .GetContent(NullHtmlEncoder.Default);

            if (String.IsNullOrEmpty(markdownContent))
            {
                return;
            }

            var htmlContent = ConvertMarkdownToHtml(markdownContent);

            // Replace <markdown> element with <p>
            output.TagName = "p";
            output.Attributes.Add(new TagHelperAttribute("style", "white-space: pre-wrap"));

            // Replace former Markdown content with HTML content
            output.Content.SetHtmlContent(htmlContent);
        }

        private string ConvertMarkdownToHtml(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .Build();

            return Markdown.ToHtml(markdown, pipeline);
        }
    }
}
