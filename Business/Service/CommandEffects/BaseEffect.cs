using Business.Strategies;
using Domain.Enum;
using Domain.Interface;

namespace Business.Service.CommandEffects;

public class BaseEffect : ICommandOutputEffect
{
    private readonly IEnumStratgies _enumStratgies;
    protected ICommandOutputEffect CommandOutputEffect;

    public BaseEffect(ICommandOutputEffect commandOutputEffect)
    {
        CommandOutputEffect = commandOutputEffect;
    }

    public OutputDecoratorType OutputDecoratorType { get; set; } = OutputDecoratorType.BaseDecorator;

    public virtual IList<IStore> ApplyEffectAsWide()
    {
        CommandOutputEffect.OutputDecoratorType = OutputDecoratorType;

        return CommandOutputEffect.ApplyEffectAsWide();
    }

    public virtual IList<ICommonStoreMethod> ApplyEffect()
    {
        CommandOutputEffect.OutputDecoratorType = OutputDecoratorType;
        return CommandOutputEffect.ApplyEffect();
    }
}