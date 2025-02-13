using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Culvers_cli.Commands;

public abstract class GlobalCommandSettings : CommandSettings
{
    [CommandOption("--color|--Color|-c")]
    [DefaultValue(false)]
    public bool Color { get; set; }

    public override ValidationResult Validate()
    {
        return ValidationResult.Success();
    }
}