using CramCoding.WebApp.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Xunit;

namespace CramCoding.UnitTests.TagHelpers
{
    public class MarkdownTagHelperShould
    {
        #region Test methods

        [Fact]
        public async void ThrowExceptionWhenNullContext()
        {
            // ARRANGE
            var sut = new MarkdownTagHelper();

            var outputAttributes = CreateAttributeList();
            var childContentFactory = CreateChildContentFactory(@"### Header 1");
            TagHelperOutput output = new TagHelperOutput("markdown", outputAttributes, childContentFactory);

            // ACT & ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ProcessAsync(context: null, output));
        }

        [Fact]
        public async void ThrowExceptionWhensNullOutput()
        {
            // ARRANGE
            var sut = new MarkdownTagHelper();

            var outputAttributes = CreateAttributeList();
            var emptyContextItems = CreateEmptyContextItems();
            var uniqueId = CreateUniqueId();
            TagHelperContext context = new TagHelperContext(outputAttributes, emptyContextItems, uniqueId);

            // ACT & ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ProcessAsync(context, output: null));
        }

        [Fact]
        public async void ReplaceMarkdownWithHtml()
        {
            // ARRANGE
            var sut = new MarkdownTagHelper();

            var contextAttributes = CreateAttributeList();
            var emptyContextItems = CreateEmptyContextItems();
            var uniqueId = CreateUniqueId();
            TagHelperContext context = new TagHelperContext(contextAttributes, emptyContextItems, uniqueId);

            var markdown =
                "### Header 1\n" +
                "Some text 1\n" +
                "## Header 2\n" +
                "Some text 2\n" +
                "### Header 3\n" +
                "Some text 3\n" +
                "```csharp\n" +
                "int a = 2;\n" +
                "```";

            var outputAttributes = CreateAttributeList();
            var childContentFactory = CreateChildContentFactory(markdown);
            TagHelperOutput output = new TagHelperOutput("markdown", outputAttributes, childContentFactory);

            // ACT
            await sut.ProcessAsync(context, output);

            // ASSERT
            Assert.Equal("p", output.TagName);

            var actualContent = output.Content.GetContent();
            var expectedContent =
                "<h3 id=\"header-1\">Header 1</h3>\n" +
                "<p>Some text 1</p>\n" +
                "<h2 id=\"header-2\">Header 2</h2>\n" +
                "<p>Some text 2</p>\n" +
                "<h3 id=\"header-3\">Header 3</h3>\n" +
                "<p>Some text 3</p>\n" +
                "<pre><code class=\"language-csharp\">int a = 2;\n" +
                "</code></pre>\n";

            Assert.Equal(expectedContent, actualContent);
        }

        #endregion Test methods


        #region Private helpers

        private TagHelperAttributeList CreateAttributeList(params (string name, string value)[] attributes)
        {
            var attributesList = attributes.Select(a => new TagHelperAttribute(a.name, a.value)).ToList();
            return new TagHelperAttributeList(attributesList);
        }

        private Func<bool, HtmlEncoder, Task<TagHelperContent>> CreateChildContentFactory(string childContent)
        {
            return (useCachedResult, htmlEncoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetContent(childContent);
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            };
        }

        private IDictionary<object, object> CreateEmptyContextItems()
        {
            return new Dictionary<object, object>();
        }

        private string CreateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }

        #endregion Private helpers
    }
}
