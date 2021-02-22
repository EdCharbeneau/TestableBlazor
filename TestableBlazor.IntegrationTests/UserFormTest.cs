using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Telerik.JustMock;
using TestableBlazor.Client;
using TestableBlazor.Client.Pages;
using TestableBlazor.Client.Services;
using Xunit;
using static Bunit.ComponentParameterFactory;


namespace TestableBlazor.IntegrationTests
{
    public class UserFormTest : TestContext
    {
        public UserFormTest()
        {
            // We're testing a Telerik application
            RenderTree.Add<TelerikRootComponent>();
            // Add Root Component
            AddMockDataService();
        }

        private void AddMockDataService()
        {
            var mockDataService = Mock.Create<IDataService>();

            Mock.Arrange(() => mockDataService.GetRegions())
                .Returns(
                    Task.FromResult(new string[] { "AA", "BB", "CC", "DD" })
                );

            Mock.Arrange(() => mockDataService.GetTeamsByRegion(Arg.AnyString))
                .Returns(
                    (string region) => Task.FromResult(new string[] { $"Red {region}", $"Green {region}", $"Blue {region}" })
                );

            Services.AddSingleton(mockDataService);
            Services.AddTelerikBlazor();
            Services.AddMockJSRuntime();
        }

        [Fact(DisplayName = "User form initialized with default birth year.")]
        public void InitializedWithDefaultBirthYear()
        {
            // Arrange
            var uut = new UserFormViewModel();
            var expected = 1980;

            // Assert
            Assert.Equal(expected, uut.BirthDate.Year);
        }

        [Fact(DisplayName = "Region change loads teams by region")]
        public void RegionChangeLoadsTeams()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Act
            var ddl = cut.FindComponent<TelerikDropDownList<string, string>>();
            cut.InvokeAsync(() => ddl.Instance.ValueChanged.InvokeAsync("BB"));

            //await cut.Instance.SelectedRegionChanged("BB");

            var expected = new string[] { "Red BB", "Green BB", "Blue BB" };

            // Assert
            Assert.Equal(expected, cut.Instance.Model.Teams);
        }

        [Fact(DisplayName = "Region first item is selected on initialization.")]
        public void SettingRegionSelectsFirstItem()
        {
            // Render the index page
            // Component internally calls IDataService.GetRegions()
            //  and IDataService.GetTeamsByRegion()
            var cut = RenderComponent<Index>();

            // Get the Model property from the component Instance
            var cutModel = cut.Instance.Model;

            // Did our Model bind?
            // Was the Regions collection filled?
            Assert.Collection(cutModel.Regions,
                                i => i.Contains("AA"),
                                i => i.Contains("BB"),
                                i => i.Contains("CC"),
                                i => i.Contains("DD"));

            // Was the first Region selected by default?
            Assert.Equal("AA", cut.Instance.Model.SelectedRegion);
        }


        [Fact(DisplayName = "Selecting a region selects the first team value.")]
        async Task SettingRegionSelectsFirstTeam()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Act
            await cut.Instance.SelectedRegionChanged("BB");

            // Assert
            Assert.Equal("Red BB", cut.Instance.Model.SelectedTeam);
        }

    }

}

