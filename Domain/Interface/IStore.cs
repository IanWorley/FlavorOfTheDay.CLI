namespace Domain.Interface;

public interface IStore : ICommonStoreMethod
{
    string DineInHours { get; set; }
    string DriveThruHours { get; set; }
    int? OnlineOrderStatus { get; set; }
    bool? IsTemporarilyClosed { get; set; }
    string OpenDate { get; set; }
}