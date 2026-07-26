using System.Text;

namespace PlayersGuide.Notes.SubNotes.ExtensionMethodsNotesHelpers;

public static class StringExtensions
{
    public static string Shout(this string text) => text.ToUpper() + "!";

    public static string ToAlternating(this string text)
    {
        var sb = new StringBuilder();
        bool isCapital = true;

        foreach (char c in text)
        {
            sb.Append(isCapital ? char.ToUpper(c) : char.ToLower(c));
            isCapital = !isCapital;
        }

        return sb.ToString();
    }
}
