using Culvers_cli.Commands;
using Domain.Interface;
using Moq;
using Spectre.Console;
using Spectre.Console.Testing;

namespace Tests.Commands;

public class FlavorOfTheDayCommandTest
{
    [Fact]
    public async Task GetFlavorOfTheDayAsync_Happy_Path()
    {
        //Arrange
        IAnsiConsole ansiConsoleMock = new TestConsole();

        var flavorOfTheDayMock = new Mock<IFlavorOfTheDayApiCall>();
        flavorOfTheDayMock.Setup(x => x.GetFlavorOfTheDayAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(
            new Dictionary<string, string>
            {
                { "123 Main St, Springfield, IL, 62701", "Vanilla" },
                { "456 Main St, Springfield, IL, 62701", "Chocolate" }
            });

        var settings = new FlavorOfTheDayCommandSettings
        {
            ZipCode = "12345",
            Limit = 2
        };


        //Act

        var flavorOfTheDayCommand = new FlavorOfTheDayCommand(flavorOfTheDayMock.Object, ansiConsoleMock);


        await flavorOfTheDayCommand.ExecuteAsync(null, settings);

// Assert
        flavorOfTheDayMock.Verify(x => x.GetFlavorOfTheDayAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }
}