namespace Tests.CommandSettings;

public class FlavorOfTheDayCommandSettings
{
    [Fact]
    public void FlavorOfTheDayCommandSettings_Valid_Parameters()
    {
        // Arrange
        var settings = new Culvers_cli.Commands.FlavorOfTheDayCommandSettings
        {
            ZipCode = "12345",
            Limit = 2
        };

        // Act & Assert
        Assert.True(settings.Validate().Successful);
    }

    [Fact]
    public void FlavorOfTheDayCommandSettings_Invalid_Parameters()
    {
        // Arrange
        var settings = new Culvers_cli.Commands.FlavorOfTheDayCommandSettings
        {
            ZipCode = "12345",
            Limit = 0
        };

        // Act & Assert
        Assert.False(settings.Validate().Successful);
    }
}