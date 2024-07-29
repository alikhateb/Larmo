using Enigma.String;
using Microsoft.Extensions.DependencyInjection;

namespace Larmo.Domain;

public static class DependencyInjection
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.ConfigureGenerics();
    }

    private static void ConfigureGenerics(this IServiceCollection services)
    {
        services.AddEnigmaEncryption(options =>
        {
            options.SymmetricKey = "b14ca5898a4e4133bbce2ea2315a1916";
        });
    }
}
