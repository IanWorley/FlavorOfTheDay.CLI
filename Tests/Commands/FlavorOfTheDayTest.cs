using CliFx.Infrastructure;
using Culvers_cli.Commands;
using Domain.Interface;
using Moq;
using Spectre.Console;
using Spectre.Console.Testing;

namespace Tests.Commands;

public class FlavorOfTheDayTest
{
    [Fact]
    public async Task GetFlavorOfTheDayAsync_Happy_Path()
    {
        
        //Arrange
        IAnsiConsole ansiConsoleMock = new TestConsole();
    
        Mock<IFlavorOfTheDay> flavorOfTheDayMock = new Mock<IFlavorOfTheDay>();
        flavorOfTheDayMock.Setup(x => x.GetFlavorOfTheDayAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new Dictionary<string, string>
        {
            {"123 Main St, Springfield, IL, 62701", "Vanilla"},
            {"456 Main St, Springfield, IL, 62701", "Chocolate"}
        });
        
        //Act
        
        var flavorOfTheDayCommand = new FlavorOfTheDayCommand(flavorOfTheDayMock.Object, ansiConsoleMock)
        {
            ZipCode =  "62701",
            Limit = 2
        };
        await flavorOfTheDayCommand.ExecuteAsync( new FakeConsole());

// Assert
        flavorOfTheDayMock.Verify(x => x.GetFlavorOfTheDayAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

    }
    
    [Fact]
    public async Task GetFlavorOfTheDayAsync_Unhappy_Path_Throws_Expection_If_Arg_is_Zero_For_Limit()
    {
        //Arrange
        Mock<IFlavorOfTheDay> flavorOfTheDayMock = new Mock<IFlavorOfTheDay>();
        IAnsiConsole ansiConsoleMock = new TestConsole();

        flavorOfTheDayMock.Setup(x => x.GetFlavorOfTheDayAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new Dictionary<string, string>
        {
            {"123 Main St, Springfield, IL, 62701", "Vanilla"},
            {"456 Main St, Springfield, IL, 62701", "Chocolate"}
        });
        
        //Act
        
        var flavorOfTheDayCommand = new FlavorOfTheDayCommand(flavorOfTheDayMock.Object, ansiConsoleMock)
        {
            ZipCode =  "62701",
            Limit = 0
        };
    
        
        await Assert.ThrowsAsync<ArgumentException>(async () => await flavorOfTheDayCommand.ExecuteAsync(new FakeConsole()));        
        
        
        flavorOfTheDayMock.Verify(x => x.GetFlavorOfTheDayAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Never);

        
    }

    
    
}