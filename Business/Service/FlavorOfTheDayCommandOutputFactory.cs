using Domain.Enum;

namespace Business.Service;

public class FlavorOfTheDayCommandOutputFactory : IFlavorOfTheDayCommandOutputFactory
{
    private readonly IEnumerable<IFlavorOfTheDayCommandOutput> _flavorOfTheDayCommandOutputs;

    public FlavorOfTheDayCommandOutputFactory(IEnumerable<IFlavorOfTheDayCommandOutput> flavorOfTheDayCommandOutputs)
    {
        _flavorOfTheDayCommandOutputs = flavorOfTheDayCommandOutputs;
    }

    public IFlavorOfTheDayCommandOutput GetCommandOutput(OutputColorEnum outputColorEnum)
    {
        return _flavorOfTheDayCommandOutputs.FirstOrDefault(x =>
                   x.DetermineOutputColorEnum() == outputColorEnum) ??
               throw new NotImplementedException("Output type not found");
    }
}