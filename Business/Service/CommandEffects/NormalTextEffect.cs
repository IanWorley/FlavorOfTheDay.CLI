using System.Text;
using Domain.Enum;
using Domain.Interface;
using Spectre.Console;

namespace Business.Service.CommandEffects;

public class NormalTextEffect : BaseEffect
{
    public NormalTextEffect(ICommandOutputEffect commandOutputEffect) : base(commandOutputEffect)
    {
    }


    public override IList<ICommonStoreMethod> ApplyEffect()
    {
        if (CommandOutputEffect.OutputDecoratorType == OutputDecoratorType.OutputDecorator)
            throw new Exception("More then one output option is not allowed");
        CommandOutputEffect.OutputDecoratorType = OutputDecoratorType;

        var stores = base.ApplyEffect();
        var storeStringBuilder = new StringBuilder();
        storeStringBuilder.Append("Address, Flavor of the Day");
        foreach (var store in stores)
            storeStringBuilder.Append(
                $"{store.StoreLocation}, {store.FlavorOfTheDay}\n");
        var console = AnsiConsole.Create(new AnsiConsoleSettings());
        console.WriteLine(storeStringBuilder.ToString());
        return stores;
    }


    public override IList<IStore> ApplyEffectAsWide()
    {
        if (CommandOutputEffect.OutputDecoratorType == OutputDecoratorType.OutputDecorator)
            throw new Exception("More then one output option is not allowed");

        CommandOutputEffect.OutputDecoratorType = OutputDecoratorType;

        var stores = CommandOutputEffect.ApplyEffectAsWide();
        var storeStringBuilder = new StringBuilder();
        storeStringBuilder.Append("Address, Flavor of the Day, Dine In Hours, Drive Thru Hours, Online Order Status\n");
        foreach (var store in stores)
            storeStringBuilder.Append(
                $"{store.StoreLocation}, {store.FlavorOfTheDay}, {store.DineInHours}, {store.DriveThruHours}, {store.OnlineOrderStatus}\n");
        var console = AnsiConsole.Create(new AnsiConsoleSettings());
        console.WriteLine(storeStringBuilder.ToString());
        return stores;
    }
}