namespace PlayersGuide.Notes.SubNotes;

public static class CharDeepDive
{
    public static void Show()
    {
        Console.WriteLine("Char Deep Dive:");

        // C# uses UTF-16 encoding for char literals
        // This means a char is 2 bytes and can represent a wide range of Unicode characters.
        // If you know the hex code for a Unicode character, you can use it in a char literal.
        char aLetter = '\u0061'; // Unicode for 'a'
        Console.WriteLine($"Character literal: {aLetter}");

        // UTF-16 means it can represent 65535 characters directly, but for characters outside the Basic Multilingual Plane (BMP), it uses surrogate pairs.
        // Surrogate pairs (high and low surrogates) mean that some characters are represented by two char values.
        // For example 🚀
        // This is why you can't put the rocket emoji directly in a char literal, because it requires two char values to represent it in UTF-16.
        // It also means that if you check the length of a string containing the rocket emoji, it will be 2, not 1, because it's made up of two char values.
        string rocketEmoji = "🚀";
        Console.WriteLine($"Rocket emoji length: {rocketEmoji.Length}");

        // This also produces some weird results when you check if the characters in the string are letters, because the surrogate pairs are not considered letters.
        foreach (char myChar in rocketEmoji)
        {
            Console.WriteLine($"Is letter: {char.IsLetter(myChar)}");
        }

        // The modern fix for this is the Rune type, which represents a Unicode scalar value and can handle all Unicode characters without needing surrogate pairs.
        Console.WriteLine($"Rune count: {("🚀".EnumerateRunes().Count())}");

        // Today the world agrees on the Unicode standard.
        // The encodings that are used to represent Unicode characters in memory are UTF-8, UTF-16, and UTF-32.
        // The numbers don't refer to the number of bits in the character, but rather the number of bits used to encode each code point. Or puzzle piece.
        // UTF-32: minimum puzzle piece size is 32 bits (4 bytes). It can represent all Unicode characters directly so every character uses exactly 1 puzzle piece. (fixed width encoding)
        // UTF-16: minimum puzzle piece size is 16 bits (2 bytes). It can represent characters in the BMP directly with one puzzle piece, but characters outside the BMP require two puzzle pieces (surrogate pairs). (variable width encoding)
        // UTF-8: minimum puzzle piece size is 8 bits (1 byte). It uses a variable number of bytes to encode each character, from 1 to 4 bytes. It can represent all Unicode characters, but the number of bytes used depends on the character. (variable width encoding)


        // Programming language divide
        // Different languages chose different encodings for their string types, which has led to a divide in the programming world.
        // UTF-16 era languages C#, Java, JavaScript. Invented when 16 bits seemed enough forever. Fast for CPUs but permanently stuck with surrogate pairs for characters outside the BMP.
        // UTF-8 era languages Rust, Go, Swift. Highly memory efficient but trades away CPU speed (the computer has to manually scan strings left to right to find the start of each character).
        // UTF-32 trickster: Python. Normally uses 1 byte but the moment you insert an emoji it secretly upgrades the entire string in memory to UTF-32 (4 bytes per character).

        // If you want the memory efficiency of UTF-8 in C# you can force it by adding the u8 suffix to a string.
        // Standard UTF-16 (takes 10 bytes)
        string hello = "Hello";
        // Highly compressed UTF-8 (takes 5 bytes)
        ReadOnlySpan<byte> helloUtf8 = "Hello"u8;

        // The above example takes 5 bytes because each character in "Hello" is an ASCII character, which can be represented in a single byte in UTF-8. 
        // In contrast, the standard UTF-16 encoding uses 2 bytes for each character, resulting in a total of 10 bytes for the same string.

        // And we also again can't trust our "eyes" to count characters
        ReadOnlySpan<byte> utf8Ogre = "👹"u8;
        Console.WriteLine($"UTF-8 Length: {utf8Ogre.Length}");
    }
}
