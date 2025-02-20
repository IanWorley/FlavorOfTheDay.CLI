using Business.Service.CommandEffects;
using Domain.Interface;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Culvers_cli.Commands;

public class FlavorOfTheDayCommand : AsyncCommand<FlavorOfTheDayCommandSettings>
{
    private readonly IFlavorOfTheDayApiCall _flavorOfTheDayApiCall;

    public FlavorOfTheDayCommand(IFlavorOfTheDayApiCall flavorOfTheDayApiCall)
    {
        _flavorOfTheDayApiCall = flavorOfTheDayApiCall;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, FlavorOfTheDayCommandSettings settings)
    {
        var apiCallResult =
            await _flavorOfTheDayApiCall.GetFlavorOfTheDayAsync(int.Parse(settings.ZipCode), settings.Limit);


        var displayingEffectDecorator = new BaseEffect(new LoadCommandOutputICommandOutputEffect(apiCallResult));

        if (settings.Pretty)
            displayingEffectDecorator = new PrettyEffect(displayingEffectDecorator);

        if (settings.OneLine) displayingEffectDecorator = new OneLineEffect(displayingEffectDecorator);


        if (!settings.OneLine && !settings.Pretty)
            displayingEffectDecorator = new NormalTextEffect(displayingEffectDecorator);

        if (settings.Wide)
            displayingEffectDecorator.ApplyEffectAsWide();
        else
            displayingEffectDecorator.ApplyEffect();

        return 0;
    }

    public ValidationResult Validate(CommandContext context, CommandSettings settings)
    {
        if (settings is not FlavorOfTheDayCommandSettings flavorOfTheDayCommandSettings)
            return ValidationResult.Error("Invalid settings type");

        return flavorOfTheDayCommandSettings.Validate();
    }
}