using System.Text;
using Domain.Enum;
using Domain.Interface;
using Spectre.Console;

namespace Business.Service.CommandEffects;

public class OneLineEffect : BaseEffect
{
    public OneLineEffect(ICommandOutputEffect commandOutputEffect) : base(commandOutputEffect)
    {
    }


    public override IList<IStore> ApplyEffectAsWide()
    {
        if (CommandOutputEffect.OutputDecoratorType == OutputDecoratorType.OutputDecorator)
            throw new Exception("More then one output option is not allowed");
        CommandOutputEffect.OutputDecoratorType = OutputDecoratorType;

        var stores = CommandOutputEffect.ApplyEffectAsWide();
        var storeStringBuilder = new StringBuilder();
        storeStringBuilder.Append("Address Flavor of the Day\n");
        foreach (var store in stores)
            storeStringBuilder.Append(
                $"{store.StoreLocation}, {store.FlavorOfTheDay}, {store.DineInHours}, {store.DriveThruHours}, {store.OnlineOrderStatus};");
        storeStringBuilder.Replace("\n", " ");
        storeStringBuilder.Replace("\r", " ");
        var console = AnsiConsole.Create(new AnsiConsoleSettings());
        console.WriteLine(storeStringBuilder.ToString());
        return stores;
    }

    public override IList<ICommonStoreMethod> ApplyEffect()
    {
        if (CommandOutputEffect.OutputDecoratorType == OutputDecoratorType.OutputDecorator)
            throw new Exception("More then one output option is not allowed");
        CommandOutputEffect.OutputDecoratorType = OutputDecoratorType;

        var stores = base.ApplyEffect();
        var storeStringBuilder = new StringBuilder();
        storeStringBuilder.Append("Address Flavor of the Day\n");

        foreach (var store in stores)
            storeStringBuilder.Append($"{store.StoreLocation}, {store.FlavorOfTheDay}\n");
        storeStringBuilder.Replace("\n", " ");
        storeStringBuilder.Replace("\r", " ");
        var console = AnsiConsole.Create(new AnsiConsoleSettings());
        console.WriteLine(storeStringBuilder.ToString());
        return stores;
    }
}