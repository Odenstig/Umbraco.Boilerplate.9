using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Boilerplate.Core.Classes
{
    public static class Extensions
    {
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
                input.Substring(1, input.Length - 1);
        }

        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null; // could also return string.Empty
        }

        public static string ToPrettyDateString(this DateTime date, string culture)
        {
            return date.ToString("dd MMMM, yyyy", CultureInfo.GetCultureInfo(culture)).ToUpper();
        }
    }
}
