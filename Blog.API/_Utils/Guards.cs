namespace Blog.API._Utils;

public static class Guards
{
    public static void ValidateStringLentgh(string value, int? minLength, int? maxLength)
    {
        if (minLength is null && maxLength is null) return;

        if ((minLength is not null && minLength > value.Length) 
            || (maxLength is not null && value.Length > maxLength))
        {
            throw new ArgumentException(
                $"The value {value} needs to have {minLength} minimum length and {maxLength} maximum length");
        }
    }
}
