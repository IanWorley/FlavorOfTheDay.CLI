using System.ComponentModel;
using System.Text.RegularExpressions;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Culvers_cli.Commands;

public sealed partial class FlavorOfTheDayCommandSettings : GlobalCommandSettings
{
    [Description("Zip code to get the flavor of the day for a store")]
    [CommandArgument(0, "<ZIPCODE>")]
    public string ZipCode { get; set; } = string.Empty;

    [Description("Limit the number of results")]
    [CommandOption("-l|--limit")]
    [DefaultValue(1)]
    public int Limit { get; set; }


    public override ValidationResult Validate()
    {
        //regex us zip code
        if (string.IsNullOrWhiteSpace(ZipCode) && !MyRegex().IsMatch(ZipCode))
            return ValidationResult.Error("Zip code is required.");

        if (Limit <= 0) return ValidationResult.Error("Limit must be greater than 0.");

        return ValidationResult.Success();
    }

    [GeneratedRegex("$\\d{5}^")]
    private static partial Regex MyRegex();
}