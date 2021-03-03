using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CramCoding.WebApp.TagHelpers
{
    /// <summary>
    /// Adds or removes <c>active</c> class on the target anchor tag
    /// depending on the anchor text and the given <see cref="ActiveItem"/> parameter.
    /// </summary>
    /// <remarks>Adds <c>active</c> class when anchor text equals <see cref="ActiveItem"/> parameter.</remarks>
    /// <remarks>Removes <c>active</c> class otherwise.</remarks>
    [HtmlTargetElement("a", Attributes = ActiveItemAttributName)]
    public class ActiveAnchorTagHelper : TagHelper
    {
        private const string ActiveItemAttributName = "active-item";

        [HtmlAttributeName(ActiveItemAttributName)]
        public string ActiveItem { get; set; }

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

            var anchorText = (await output.GetChildContentAsync()).GetContent();
            if (anchorText == ActiveItem)
            {
                EnsureActiveClassAdded(output);
            }
            else
            {
                EnsureActiveClassRemoved(output);
            }
        }

        private void EnsureActiveClassAdded(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");

            // Anchor tag has no "class" attribute defined yet
            if (classAttr == null)
            {
                classAttr = new TagHelperAttribute("class", "active");
                output.Attributes.Add(classAttr);
            }
            // Anchor tag has "class" attribute defined but its value is "null"
            else if (classAttr.Value == null)
            {
                output.Attributes.SetAttribute("class", "active");
            }
            // Anchor tag has "class" attribute defined but it does not contain the "active" class on its list
            else if (!classAttr.Value.ToString().Contains("active"))
            {
                var newClassAttrValue = classAttr.Value.ToString() + " active";
                output.Attributes.SetAttribute("class", newClassAttrValue);
            }
            // Anchor tag has "class" attribute defined and it already contains the "active" class on its list
        }

        private void EnsureActiveClassRemoved(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");

            // Remove "active" class if present
            if (classAttr != null && classAttr.Value != null && classAttr.Value.ToString().Contains("active"))
            {
                var classes = classAttr.Value.ToString().Split();
                if (classes.Contains("active"))
                {
                    var newClassAttrValue = String.Join(" ", classes.Where(c => c != "active"));
                    output.Attributes.SetAttribute("class", newClassAttrValue);
                }
            }
        }
    }
}
