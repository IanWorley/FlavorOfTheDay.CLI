using Domain.Enum;

namespace Business.Service;

public class FlavorOfTheDayCommandWriterFactory : IFlavorOfTheDayWriterFactory
{
    private readonly IEnumerable<IFlavorOfTheDayWriter> _flavorOfTheDayCommandOutputs;

    public FlavorOfTheDayCommandWriterFactory(IEnumerable<IFlavorOfTheDayWriter> flavorOfTheDayCommandOutputs)
    {
        _flavorOfTheDayCommandOutputs = flavorOfTheDayCommandOutputs;
    }

    public IFlavorOfTheDayWriter GetWriter(WriterEnum writerEnum)
    {
        return _flavorOfTheDayCommandOutputs.FirstOrDefault(x =>
                   x.DetermineOutputColorEnum() == writerEnum) ??
               throw new NotImplementedException("Output type not found");
    }
}