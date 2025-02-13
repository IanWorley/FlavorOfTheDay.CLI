using Domain.Enum;

namespace Business.Service;

public interface IFlavorOfTheDayCommandOutputFactory
{
    IFlavorOfTheDayCommandOutput GetCommandOutput(OutputColorEnum outputColorEnum);
}