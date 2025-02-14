using Business.Service;
using Culvers_cli.Commands;
using Domain.Enum;
using Domain.Interface;
using Moq;
using Spectre.Console.Testing;

namespace Tests.Commands;

public class FlavorOfTheDayCommandTest
{
    [Fact]
    public async Task GetFlavorOfTheDayAsync_Happy_Path()
    {
        //Arrange
        var flavorOfTheDayCommandOutputFactoryMock = new Mock<IFlavorOfTheDayWriterFactory>();
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

        flavorOfTheDayCommandOutputFactoryMock.Setup(x => x.GetWriter(It.IsAny<WriterEnum>()))
            .Returns(new FlavorOfTheDayCommandPrettyWriter(new TestConsole()));


        //Act

        var flavorOfTheDayCommand =
            new FlavorOfTheDayCommand(flavorOfTheDayMock.Object, flavorOfTheDayCommandOutputFactoryMock.Object);


        var result = await flavorOfTheDayCommand.ExecuteAsync(null, settings);

// Assert
        // means the app closed successfully
        Assert.Equal(0, result);
    }
}