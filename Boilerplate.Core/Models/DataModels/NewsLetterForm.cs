using Boilerplate.Core.Classes.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Core.Models.DataModels
{
    public class NewsLetterForm
    {
        [Required(ErrorMessage = "Vänligen fyll i fältet")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vänligen fyll i fältet")]
        [EmailAddress(ErrorMessage = "Vänligen ange en korrekt e-postadress")]
        public string Email { get; set; }
        [EnforceTrue(ErrorMessage = "Vänligen acceptera villkoren")]
        public bool Consent { get; set; }
    }
}
