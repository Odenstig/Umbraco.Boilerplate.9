using Boilerplate.Core.Classes;
using Boilerplate.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Common.LanguagePicker
{
    public class LanguagePickerViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;
        private readonly ILocalizationService _localizationService;

        public LanguagePickerViewComponent(ISiteService siteService, ILocalizationService localizationService)
        {
            _siteService = siteService;
            _localizationService = localizationService;
        }

        public IViewComponentResult Invoke(int currentPageId)
        {
            var viewModel = new LanguagePickerViewModel();

            // TODO: Cache languages
            var allCultures = _localizationService.GetAllLanguages();
            var currentPage = _siteService.ContentQuery.GetById(currentPageId);

            if (currentPage != null)
            {
                var currentCulture = currentPage.GetCultureFromDomains();
                viewModel.ScreenReaderText = _siteService.Translate(TranslationKeys.LanguagePicker_ScreenReaderText, currentCulture);

                foreach (var culture in allCultures)
                {
                    var isoCode = culture.IsoCode;

                    string displayName = isoCode switch
                    {
                        "sv" => _siteService.Translate(TranslationKeys.Globals_Swedish, currentCulture),
                        "en-US" => _siteService.Translate(TranslationKeys.Globals_English, currentCulture),
                        _ => _siteService.Translate(TranslationKeys.Globals_Swedish, currentCulture),
                    };

                    viewModel.AvailableCultures.Add(new AvailableCultureViewModel
                    {
                        DisplayName = displayName,
                        Iso = isoCode,
                        IsSelected = currentCulture == isoCode,
                        NavigateTo = currentPage.Url(isoCode)
                    });
                }
            }

            return View(viewModel);
        }
    }
}
