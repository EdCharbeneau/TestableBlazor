using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
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

        private void AddMockDataService()
        {
            var mockDataService = Mock.Create<IDataService>();
            Mock.Arrange(() => mockDataService.GetRegions())
                .Returns(Task.FromResult(new string[] { "AA", "BB", "CC", "DD" }));
            Mock.Arrange(() => mockDataService.GetTeamsByRegion(Arg.AnyString))
                .Returns((string region) => Task.FromResult(new string[] { $"Red {region}", $"Green {region}", $"Blue {region}" }));
            Services.AddSingleton(mockDataService);
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
            AddMockDataService();

            var cut = RenderComponent<Index>();

            // Act
            cut.Find("#regionSelect").Change("BB");
            var expected = new string[] { "Red BB", "Green BB", "Blue BB" };

            // Assert
            Assert.Equal(expected, cut.Instance.Model.Teams);
        }

        [Fact(DisplayName = "Region first item is selected on initialization.")]
        public void SettingRegionSelectsFirstItem()
        {
            // Arrange
            AddMockDataService();

            var cut = RenderComponent<Index>();
            // Act
            // Component internally calls IDataService.GetRegions()  and IDataService.GetTeamsByRegion()

            // Assert
            Assert.Equal("AA", cut.Instance.Model.SelectedRegion);
        }


        [Fact(DisplayName = "Selecting a region selects the first team value.")]
        public void SettingRegionSelectsFirstTeam()
        {
            // Arrange
            AddMockDataService();
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("#regionSelect").Change("BB");

            // Assert
            Assert.Equal("Red BB", cut.Instance.Model.SelectedTeam);
        }

    }

}

