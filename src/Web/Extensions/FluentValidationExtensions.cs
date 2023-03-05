using FluentValidation.AspNetCore;

namespace Zowari.Extensions;

public static class FluentValidationExtensions
{
    internal static IMvcBuilder AddValidators(this IMvcBuilder builder)
    {
        builder.AddFluentValidation(fv =>
        {
            // fv.RegisterValidatorsFromAssemblyContaining<>();
        });
        return builder;
    }
}