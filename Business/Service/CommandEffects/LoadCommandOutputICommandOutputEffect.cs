using Domain;
using Domain.Enum;
using Domain.Interface;

namespace Business.Service.CommandEffects;

public class LoadCommandOutputICommandOutputEffect : ICommandOutputEffect
{
    private readonly IList<IStore> _stores;


    public LoadCommandOutputICommandOutputEffect(IList<IStore> stores)
    {
        _stores = stores;
    }

    public OutputDecoratorType OutputDecoratorType { get; set; } = OutputDecoratorType.LoaderDecorator;

    public IList<IStore> ApplyEffectAsWide()
    {
        return _stores;
    }

    public IList<ICommonStoreMethod> ApplyEffect()
    {
        //! how the fuck does the editor not complain  
        var x = _stores.Select(x => new SmallStore(x).ConvertToStoreModel()).ToList();
        return x;
    }
}