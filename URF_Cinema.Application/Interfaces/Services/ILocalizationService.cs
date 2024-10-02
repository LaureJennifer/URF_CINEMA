using Microsoft.Extensions.Localization;
using System.Globalization;

namespace URF_Cinema.Application.Interfaces.Services
{
    public interface ILocalizationService
    {
        LocalizedString this[string name] { get; }

        LocalizedString this[string name, params object[] arguments] { get; }

        CultureInfo CurrentCulture { get; }

        IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures);
    }
}
