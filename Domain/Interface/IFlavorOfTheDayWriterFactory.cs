using Domain.Enum;

namespace Business.Service;

public interface IFlavorOfTheDayWriterFactory
{
    IFlavorOfTheDayWriter GetWriter(WriterEnum writerEnum);
}