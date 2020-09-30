using Bunit;
using Microsoft.Extensions.DependencyInjection;
//using NSubstitute;
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
        //private void AddMockDataService()
        //{
        //    var mockDataService = Substitute.For<IDataService>();
        //    mockDataService.GetRegions()
        //        .Returns(new string[] { "AA", "BB", "CC", "DD" });
        //    mockDataService.GetTeamsByRegion(Arg.Any<string>())
        //        .Returns(x => new string[] { $"Red {x.Arg<string>()}", $"Green {x.Arg<string>()}", $"Blue {x.Arg<string>()}" });
        //    Services.AddSingleton(mockDataService);
        //}

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

        [Fact(DisplayName = "Region first item is selected on initialization.")]
        public void SettingRegionSelectsFirstItem()
        {
            // Arrange
            AddMockDataService();

            var cut = RenderComponent<Index>();

            // Act
            // Component internally calls IDataService.GetRegions()  and IDataService.GetTeamsByRegion()

            // Assert
            cut.WaitForAssertion(() => Assert.Equal("AA", cut.Instance.Model.SelectedRegion));
        }

        [Fact(DisplayName = "Selecting a region selects the first team value.")]
        public void SettingRegionSelectsFirstTeam()
        {
            // Arrange
            AddMockDataService();
            var cut = RenderComponent<Index>();
            var x = cut.Markup;

            // Act
            cut.Find("#regionSelect").Change("BB");

            // Assert
            cut.WaitForAssertion(() => Assert.Equal("Red BB", cut.Instance.Model.SelectedTeam));
        }

    }

}

