﻿namespace Blog.API._Utils;

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

        return string.Concat(value.Remove(1).ToUpper(), value.AsSpan(1));
    }

    /// <summary>
    /// It trims the target value, and also applies a capitalization of only the first letter.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>A string trimmed and also with only its first letter capitalized.</returns>
    public static string ToName(this string value)
    {
        return value.Trim().ToTitleCase();
    }
}