using Domain.Modal;

namespace Domain.Interface;

public interface ICommonStoreMethod : IStoreExportToSmallStoreInfo
{
    public StoreLocation StoreLocation { get; set; }
    public string FlavorOfTheDay { get; set; }
}