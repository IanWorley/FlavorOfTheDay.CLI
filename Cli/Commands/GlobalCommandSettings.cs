using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Culvers_cli.Commands;

public abstract class GlobalCommandSettings : CommandSettings
{
    [Description("Use color output and enhance the display")]
    [CommandOption("--pretty|--Pretty|-p")]
    [DefaultValue(false)]
    public bool Pretty { get; set; }


    public override ValidationResult Validate()
    {
        if (Pretty)
            return ValidationResult.Error("OneLine and Pretty cannot be used together.");
        return ValidationResult.Success();
    }
}