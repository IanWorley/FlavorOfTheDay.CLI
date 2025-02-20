using Business;
using Moq;
using Moq.Protected;
using Tests.Utils;

namespace Tests.Service;

public class TestFlavorOfTheDayApiCall
{
    [Fact]
    public async Task GetFlavorOfTheDayAsync_ReturnsExpectedResult()
    {
        //Arrange 
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var expectedResponse = CommonMocks.WorkingMockedJsonResponse();
        mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
        ).ReturnsAsync(expectedResponse);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock.Setup(_ => _.CreateClient("FavorOfTheDayByZipLimit")).Returns(httpClient);
        var service = new FlavorOfTheDayApiCall(httpClientFactoryMock.Object);

        var result = await service.GetFlavorOfTheDayAsync(12345);

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("123 Main St, Springfield, IL 62701", result.First().StoreLocation.ToString());
    }

    [Fact]
    public async Task ValidateArgumentsForLimits()
    {
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var expectedResponse = CommonMocks.WorkingMockedJsonResponse();

        mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
        ).ReturnsAsync(expectedResponse);

        await Assert.ThrowsAsync<ArgumentException>(() =>
            new FlavorOfTheDayApiCall(httpClientFactoryMock.Object).GetFlavorOfTheDayAsync(12345, -1));
    }
}