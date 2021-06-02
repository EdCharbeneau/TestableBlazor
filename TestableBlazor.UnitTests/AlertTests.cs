using Bunit;
using TestableBlazor.Client.Shared;
using Xunit;


namespace TestableBlazor.UnitTests
{
    public class AlertTests : TestContext
    {

        [Fact(DisplayName = "Initial Alert renders correct markup")]
        public void AlertInit()
        {
            // Render an Alert component
            var cut = RenderComponent<Alert>();

            // Expected HTML rendered
            string expectedMarkup = @"
            <div class=""alert alert-danger"">
                <button type=""button"" class=""close"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>";

            // Did it match?
            cut.MarkupMatches(expectedMarkup);
        }

        [Fact(DisplayName = "Alert is dismiss-able")]
        public void AlertHide()
        {
            // Arrange
            var cut = RenderComponent<Alert>();
            string expectedMarkup = @"
            <button type=""button"" aria-label=""Open"">
                <span class=""oi oi-envelope-open"" aria-hidden=""true""></span>
            </button>";

            cut.Find("button").Click();
            // Act

            cut.MarkupMatches(expectedMarkup);
        }

        [Fact(DisplayName = "Alert has info theme")]
        public void AlertColor()
        {
            // Render the component with IsInfo = true
            var cut = RenderComponent<Alert>(parameters => 
                        parameters.Add(p => p.IsInfo, true));

            // The expected CSS value
            var expectedCss = "alert alert-info";

            // The actual CSS value
            var actualCss = cut.Find("div").GetAttribute("class");

            // Did it match?
            Assert.Equal(expectedCss, actualCss);
        }

    }
}

