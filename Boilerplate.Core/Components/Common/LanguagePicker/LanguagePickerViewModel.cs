using System.Collections.Generic;

namespace Boilerplate.Core.Components.Common.LanguagePicker
{
    public class LanguagePickerViewModel
    {
        public string ScreenReaderText { get; set; }
        public List<AvailableCultureViewModel> AvailableCultures { get; set; } = new List<AvailableCultureViewModel>();
    }

    public class AvailableCultureViewModel
    {
        public string DisplayName { get; set; }
        public string Iso { get; set; }
        public bool IsSelected { get; set; }
        public string NavigateTo { get; set; }
    }
}
