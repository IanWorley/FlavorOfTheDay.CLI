using Domain.Enum;
using Domain.Interface;

namespace Business.Service.CommandEffects;

public interface ICommandOutputEffect
{
    public OutputDecoratorType OutputDecoratorType { get; set; }
    public IList<IStore> ApplyEffectAsWide();

    public IList<ICommonStoreMethod> ApplyEffect();
}