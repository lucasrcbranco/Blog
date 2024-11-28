using System.Globalization;

namespace Blog.API._Utils;

public static class StringExtensions
{
    /// <summary>
    /// English: Returns the string with only the first letter capitalized.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>A string with only its first letter capitalized.</returns>
    public static string ToTitleCase(this string value)
    {
        value = value.ToLower();

        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        if (value.Length == 1)
        {
            return value.ToUpper();
        }

        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value.Trim().ToLower());
    }
}
