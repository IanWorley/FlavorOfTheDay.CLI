using Domain.Enum;
using Domain.Interface;
using Spectre.Console;

namespace Business.Service.CommandEffects;

public class PrettyEffect : BaseEffect
{
    public PrettyEffect(ICommandOutputEffect commandOutputEffect) : base(commandOutputEffect)
    {
    }


    public override IList<IStore> ApplyEffectAsWide()
    {
        if (CommandOutputEffect.OutputDecoratorType == OutputDecoratorType.OutputDecorator)
            throw new Exception("More then one output option is not allowed");

        CommandOutputEffect.OutputDecoratorType = OutputDecoratorType;

        var stores = CommandOutputEffect.ApplyEffectAsWide();

        if (stores.Count == 1)
        {
            AnsiConsole.WriteLine(
                $"[green]Address:[/] {stores[0].StoreLocation} \n[green]Flavor of the Day:[/] {stores[0].FlavorOfTheDay}  \n[yellow]Dine In Hours:[/]{stores.First().DineInHours} \n[yellow]Drive Thru Hours:[/]{stores.First().DriveThruHours}, \n[yellow]Online Order Status:[/]{stores.First().OnlineOrderStatus}");
            return stores;
        }

        var table = new Table();
        table.AddColumn("[green]Address[/]");
        table.AddColumn(":ice_cream:Flavor of the Day:ice_cream:");
        table.AddColumn("[yellow]Dine In Hours[/]");
        table.AddColumn("[yellow]Drive Thru Hours[/]");
        table.AddColumn("[yellow]Online Order Status[/]");

        foreach (var store in stores)
            table.AddRow(store.StoreLocation.ToString(), store.FlavorOfTheDay, store.DineInHours, store.DriveThruHours,
                store.OnlineOrderStatus.ToString());
        AnsiConsole.Write(table);
        return stores;
    }


    public override IList<ICommonStoreMethod> ApplyEffect()
    {
        if (CommandOutputEffect.OutputDecoratorType == OutputDecoratorType.OutputDecorator)
            throw new Exception("More then one output option is not allowed");

        CommandOutputEffect.OutputDecoratorType = OutputDecoratorType;

        var stores = base.ApplyEffect();

        if (stores.Count == 1)
        {
            AnsiConsole.WriteLine(
                $"[green]Address:[/] {stores[0].StoreLocation} [green]Flavor of the Day:[/] {stores[0].FlavorOfTheDay}");
            return stores;
        }

        var table = new Table();
        table.AddColumn("[green]Address[/]");
        table.AddColumn(":ice_cream:Flavor of the Day:ice_cream:");
        foreach (var store in stores)
            table.AddRow(store.StoreLocation.ToString(), store.FlavorOfTheDay);
        AnsiConsole.Write(table);
        return stores;
    }
}