using Spectre.Console.Cli;

namespace Culvers_cli.DI;

public sealed class TypeResolver : ITypeResolver, IDisposable
{
    private readonly IServiceProvider _provider;

    public TypeResolver(IServiceProvider provider)
    {
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    public void Dispose()
    {
        if (_provider is IDisposable disposable) disposable.Dispose();
    }

    public object? Resolve(Type type)
    {
        if (type == null) return null;
        return _provider.GetService(type);
    }
}