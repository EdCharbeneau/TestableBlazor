using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Telerik.JustMock;
using TestableBlazor.Client;
using TestableBlazor.Client.Pages;
using TestableBlazor.Client.Services;
using Xunit;

namespace TestableBlazor.IntegrationTests
{
    public class UserFormTest : TestContext
    {

        [Fact(DisplayName = "User form initialized with default birth year.")]
        public void InitializedWithDefaultBirthYear()
        {
            // Arrange
            var uut = new UserFormViewModel();
            var expected = 1980;

            // Assert
            Assert.Equal(expected, uut.BirthDate.Year);
        }

        [Fact(DisplayName = "Region first item is selected on initialization.")]
        public void SettingRegionSelectsFirstItem()
        {
            // Arrange
            using var ctx = new TestContext();
            var mockDataService = Mock.Create<IDataService>();
            Mock.Arrange(() => mockDataService.GetRegions())
                .Returns(() => Task.Run(() => new string[] { "AA", "BB", "CC", "DD" }));
            Mock.Arrange(() => mockDataService.GetTeamsByRegion(Arg.AnyString))
                .Returns((string region) => Task.Run(() => new string[] { $"Red {region}", $"Green {region}", $"Blue {region}" }));
            ctx.Services.AddSingleton(mockDataService);

            var cut = ctx.RenderComponent<Index>();

            // Act
            // Component internally calls IDataService.GetRegions()  and IDataService.GetTeamsByRegion()

            // Assert
            Assert.Equal("AA", cut.Instance.Model.SelectedRegion);
        }

        [Fact(DisplayName = "Selecting a region selects the first team value.")]
        public void SettingRegionSelectsFirstTeam()
        {
            // Arrange
            using var ctx = new TestContext();
            var mockDataService = Mock.Create<IDataService>();
            Mock.Arrange(() => mockDataService.GetRegions())
                .Returns(() => Task.Run(() => new string[] { "AA", "BB", "CC", "DD" }));
            Mock.Arrange(() => mockDataService.GetTeamsByRegion(Arg.AnyString))
                .Returns((string region) => Task.Run(() => new string[] { $"Red {region}", $"Green {region}", $"Blue {region}" }));
            ctx.Services.AddSingleton(mockDataService);

            var cut = ctx.RenderComponent<Index>();
            var x = cut.Markup;
            // Act
            cut.Find("#regionSelect").Change("BB");
            // Assert
            Assert.Equal("Red BB", cut.Instance.Model.SelectedTeam);
        }

    }

}

