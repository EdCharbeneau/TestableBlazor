using Microsoft.Playwright;

namespace TestableBlazor.e2e;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HomePageForm : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }

    private async Task WaitForInteractivity()
    {
        await Page.GetByText("Loading Resources")
            .WaitForAsync(new() { State = WaitForSelectorState.Hidden});
    }

    [Test]
    public async Task HomePageHasFormWithInputAndSubmitButton()
    {
        await Page.GotoAsync("https://localhost:7002/");
        await WaitForInteractivity();
        await Expect(Page.GetByText("I'm dismiss-able! ×")).ToBeVisibleAsync();
        await Page.GetByLabel("Close").ClickAsync();
        await Expect(Page.GetByLabel("Open Alert")).ToBeVisibleAsync();
    }



    [Test]
    public async Task HomePageInitializesWithEmptyForm()
    {
        await Page.GotoAsync("https://localhost:7002/");
        await Expect(Page.GetByLabel("First Name")).ToBeEmptyAsync();
        await Expect(Page.GetByLabel("Last Name")).ToBeEmptyAsync();
        await Expect(Page.GetByLabel("Birth Date")).ToHaveValueAsync("1/1/1980");
        await Expect(Page.GetByPlaceholder("email@domain.com")).ToBeEmptyAsync();
        await Expect(Page.Locator("#regionSelect_selectId")).ToContainTextAsync("AE");
        await Expect(Page.Locator("#teamSelect_selectId")).ToContainTextAsync("Red AE");
    }

    [Test]
    public async Task HomePageFormShowsValidationErrorsWhenEmpty()
    {
        await Page.GotoAsync("https://localhost:7002/");
        await WaitForInteractivity();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("The FirstName field is required.");
        await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("The LastName field is required.");
        await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("The Email field is required.");
    }

    [Test]
    public async Task HomePageFromCanBeSubmittedAndShowsThankYouConfirmationDialog()
    {
        await Page.GotoAsync("https://localhost:7002/");
        await WaitForInteractivity();
        var submit =  Page.GetByRole(AriaRole.Button, new() { Name = "Submit" });
        await submit.ClickAsync();
        await Page.GetByLabel("First Name").FillAsync("Ed");
        await Page.GetByLabel("Last Name").FillAsync("Charbeneau");
        await Page.GetByLabel("Email").FillAsync("jdoe@gmail.com");
        await Page.GetByText("The Email field is required.").WaitForAsync(new() { State = WaitForSelectorState.Hidden });
        await submit.ClickAsync();
        var elThankYou = Page.GetByLabel("Thank You").Locator("div").Filter(new() { HasText = "Thank you, we have received your information and will contact you using the email provided." });
        await Expect(elThankYou).ToBeVisibleAsync();
    }

    [Test]
    public async Task HomePageHasCascadingDropDown()
    {
        await Page.GotoAsync("https://localhost:7002/");
        await WaitForInteractivity();
        await Page.GetByLabel("Region").ClickAsync();
        await Page.GetByRole(AriaRole.Option, new() { Name="BQ"}).ClickAsync();
        await Expect(Page.GetByLabel("Team")).ToContainTextAsync("​Red BQ");
    }
}