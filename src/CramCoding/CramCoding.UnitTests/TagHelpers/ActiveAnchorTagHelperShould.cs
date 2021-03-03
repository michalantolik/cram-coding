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
    public class ActiveAnchorTagHelperShould
    {
        #region Test methods

        [Fact]
        public async void ThrowExceptionWhenNullContext()
        {
            // ARRANGE
            var sut = new ActiveAnchorTagHelper();

            var outputAttributes = CreateAttributeList(("class", "bg-dark"), ("href", "#"));
            var childContentFactory = CreateChildContentFactory("AnchorText 123");
            TagHelperOutput output = new TagHelperOutput("a", outputAttributes, childContentFactory);

            // ACT & ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ProcessAsync(context: null, output));
        }

        [Fact]
        public async void ThrowExceptionWhensNullOutput()
        {
            // ARRANGE
            var sut = new ActiveAnchorTagHelper();

            var contextAttributes = CreateAttributeList(("href", "#"), ("active-item", "AnchorText 123"));
            var emptyContextItems = CreateEmptyContextItems();
            var uniqueId = CreateUniqueId();
            TagHelperContext context = new TagHelperContext(contextAttributes, emptyContextItems, uniqueId);

            // ACT & ASSERT
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ProcessAsync(context, output: null));
        }

        [Fact]
        public async void AddActiveClassWhenItemSelectedAndClassAttributeNotPresent()
        {
            // ARRANGE
            var activeItemValue = "AnchorText 123";
            var sut = new ActiveAnchorTagHelper() { ActiveItem = activeItemValue };

            var contextAttributes = CreateAttributeList(("href", "#"), ("active-item", activeItemValue));
            var emptyContextItems = CreateEmptyContextItems();
            var uniqueId = CreateUniqueId();
            TagHelperContext context = new TagHelperContext(contextAttributes, emptyContextItems, uniqueId);

            var outputAttributes = CreateAttributeList(("href", "#"));
            var childContentFactory = CreateChildContentFactory(activeItemValue);
            TagHelperOutput output = new TagHelperOutput("a", outputAttributes, childContentFactory);

            // ACT
            await sut.ProcessAsync(context, output);

            // ASSERT
            var classAttribute = output.Attributes.SingleOrDefault(a => a.Name == "class");
            Assert.NotNull(classAttribute);

            var classValueString = classAttribute.Value as string;
            Assert.NotNull(classValueString);

            var classes = classValueString.Split(" ");
            Assert.Single(classes, "active");
        }

        [Fact]
        public async void AddActiveClassWhenItemSelectedAndClassAttributePresent()
        {
            // ARRANGE
            var activeItemValue = "AnchorText 123";
            var sut = new ActiveAnchorTagHelper() { ActiveItem = activeItemValue };

            var contextAttributes = CreateAttributeList(("class", "text-light"), ("href", "#"), ("active-item", activeItemValue));
            var emptyContextItems = CreateEmptyContextItems();
            var uniqueId = CreateUniqueId();
            TagHelperContext context = new TagHelperContext(contextAttributes, emptyContextItems, uniqueId);

            var outputAttributes = CreateAttributeList(("class", "text-light"), ("href", "#"));
            var childContentFactory = CreateChildContentFactory(activeItemValue);
            TagHelperOutput output = new TagHelperOutput("a", outputAttributes, childContentFactory);

            // ACT
            await sut.ProcessAsync(context, output);

            // ASSERT
            var classAttribute = output.Attributes.SingleOrDefault(a => a.Name == "class");
            Assert.NotNull(classAttribute);

            var classValueString = classAttribute.Value as string;
            Assert.NotNull(classValueString);

            var classes = classValueString.Split(" ");
            Assert.Single(classes, "active");
        }

        [Fact]
        public async void KeepSingleActiveClassWhenItemSelectedAndActiveClassAlreadyPresent()
        {
            // ARRANGE
            var activeItemValue = "AnchorText 123";
            var sut = new ActiveAnchorTagHelper() { ActiveItem = activeItemValue };

            var contextAttributes = CreateAttributeList(("class", "text-light active"), ("href", "#"), ("active-item", activeItemValue));
            var emptyContextItems = CreateEmptyContextItems();
            var uniqueId = CreateUniqueId();
            TagHelperContext context = new TagHelperContext(contextAttributes, emptyContextItems, uniqueId);

            var outputAttributes = CreateAttributeList(("class", "text-light"), ("href", "#"));
            var childContentFactory = CreateChildContentFactory(activeItemValue);
            TagHelperOutput output = new TagHelperOutput("a", outputAttributes, childContentFactory);

            // ACT
            await sut.ProcessAsync(context, output);

            // ASSERT
            var classAttribute = output.Attributes.SingleOrDefault(a => a.Name == "class");
            Assert.NotNull(classAttribute);

            var classValueString = classAttribute.Value as string;
            Assert.NotNull(classValueString);

            var classes = classValueString.Split(" ");
            Assert.Single(classes, "active");
        }

        [Fact]
        public async void RemoveActiveClassWhenItemNotSelectedAndActiveClassPresent()
        {
            // ARRANGE
            var activeItemValue = "AnchorText 123";
            var sut = new ActiveAnchorTagHelper() { ActiveItem = activeItemValue };

            var contextAttributes = CreateAttributeList(("class", "text-light active"), ("href", "#"), ("active-item", activeItemValue));
            var emptyContextItems = CreateEmptyContextItems();
            var uniqueId = CreateUniqueId();
            TagHelperContext context = new TagHelperContext(contextAttributes, emptyContextItems, uniqueId);

            var outputAttributes = CreateAttributeList(("class", "text-light"), ("href", "#"));
            var childContentFactory = CreateChildContentFactory("Different Anchor Text 456");
            TagHelperOutput output = new TagHelperOutput("a", outputAttributes, childContentFactory);

            // ACT
            await sut.ProcessAsync(context, output);

            // ASSERT
            var classAttribute = output.Attributes.SingleOrDefault(a => a.Name == "class");
            Assert.NotNull(classAttribute);

            var classValueString = classAttribute.Value as string;
            Assert.NotNull(classValueString);

            var classes = classValueString.Split(" ");
            Assert.DoesNotContain("active", classes);
        }

        [Fact]
        public async void HaveNoEffectOnClassesWhenItemNotSelectedAndActiveClassNotPresent()
        {
            // ARRANGE
            var activeItemValue = "AnchorText 123";
            var sut = new ActiveAnchorTagHelper() { ActiveItem = activeItemValue };

            var contextAttributes = CreateAttributeList(("class", "text-light"), ("href", "#"), ("active-item", activeItemValue));
            var emptyContextItems = CreateEmptyContextItems();
            var uniqueId = CreateUniqueId();
            TagHelperContext context = new TagHelperContext(contextAttributes, emptyContextItems, uniqueId);

            var outputAttributes = CreateAttributeList(("class", "text-light"), ("href", "#"));
            var childContentFactory = CreateChildContentFactory("Different Anchor Text 456");
            TagHelperOutput output = new TagHelperOutput("a", outputAttributes, childContentFactory);

            // ACT
            await sut.ProcessAsync(context, output);

            // ASSERT
            var classAttribute = output.Attributes.SingleOrDefault(a => a.Name == "class");
            Assert.NotNull(classAttribute);

            var classValueString = classAttribute.Value as string;
            Assert.NotNull(classValueString);

            var classes = classValueString.Split(" ");
            Assert.DoesNotContain("active", classes);
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
