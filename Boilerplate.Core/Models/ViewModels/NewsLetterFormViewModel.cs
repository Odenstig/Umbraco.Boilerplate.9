using Boilerplate.Core.Classes.Attributes;
using Boilerplate.Core.Models.DataModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Core.Models.ViewModels
{
    public class NewsLetterFormViewModel
    {
        public Guid Identifier { get; set; }
        public string NamePlaceholder { get; set; }
        public string EmailPlaceholder { get; set; }
        public string ConsentText { get; set; }
        public string SubmitButtonText { get; set; }
        public string SubmitSuccessText { get; set; }
        public string SubmitErrorText { get; set; }
        public NewsLetterForm Form { get; set; } = new NewsLetterForm();
        public string ClassNames { get; set; }
    }
}
