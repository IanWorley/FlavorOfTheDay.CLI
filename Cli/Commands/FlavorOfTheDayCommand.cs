using Business.Service;
using Domain.Enum;
using Domain.Interface;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Culvers_cli.Commands;

public class FlavorOfTheDayCommand : AsyncCommand<FlavorOfTheDayCommandSettings>
{
    private readonly IFlavorOfTheDayApiCall _flavorOfTheDayApiCall;
    private readonly IFlavorOfTheDayCommandOutputFactory _flavorOfTheDayCommandOutputFactory;

    public FlavorOfTheDayCommand(IFlavorOfTheDayApiCall flavorOfTheDayApiCall,
        IFlavorOfTheDayCommandOutputFactory flavorOfTheDayCommandOutputFactory)
    {
        _flavorOfTheDayApiCall = flavorOfTheDayApiCall;
        _flavorOfTheDayCommandOutputFactory = flavorOfTheDayCommandOutputFactory;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, FlavorOfTheDayCommandSettings settings)
    {
        var apiCallResult =
            await _flavorOfTheDayApiCall.GetFlavorOfTheDayAsync(int.Parse(settings.ZipCode), settings.Limit);

        var enumForTerminalColor = OutputColorEnum.Plain;

        if (settings.Color) enumForTerminalColor = OutputColorEnum.Color;


        var commandOutput = _flavorOfTheDayCommandOutputFactory.GetCommandOutput(enumForTerminalColor);

        commandOutput.DisplayFlavorOfTheDay(apiCallResult);

        return 0;
    }

    public ValidationResult Validate(CommandContext context, CommandSettings settings)
    {
        if (settings is not FlavorOfTheDayCommandSettings flavorOfTheDayCommandSettings)
            return ValidationResult.Error("Invalid settings type");

        return flavorOfTheDayCommandSettings.Validate();
    }
}