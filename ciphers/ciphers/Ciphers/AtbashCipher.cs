using System.Text;

namespace cipher.Ciphers;

public sealed class AtbashCipher
{
    private readonly Dictionary<char, char> _encryptionSubstitutions = new();
    private readonly Dictionary<char, char> _decryptionSubstitutions = new();

    public AtbashCipher()
    {
        char[] alphabetChars = new char[Constants.AlphabetLength];
        char[] reversedAlphabetChars = new char[Constants.AlphabetLength];

        Constants.alphabet.CopyTo(alphabetChars, 0);
        Constants.alphabet.Reverse().ToArray().CopyTo(reversedAlphabetChars, 0);

        _encryptionSubstitutions = Enumerable.Range(0, Constants.AlphabetLength)
            .ToDictionary(i => alphabetChars[i], i => reversedAlphabetChars[i]);

        _decryptionSubstitutions = _encryptionSubstitutions.ToDictionary(substitution => substitution.Value, substitution => substitution.Key);
    }

    public string Encrypt(string text)
        => Substitute(_encryptionSubstitutions, text);

    public string Decrypt(string ciphertext)
        => Substitute(_decryptionSubstitutions, ciphertext);

    private static string Substitute(Dictionary<char, char> substitutions, string text)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char ch in text)
        {
            if (substitutions.TryGetValue(char.ToLower(ch), out char newChar))
            {
                if (char.IsUpper(ch))
                {
                    newChar = char.ToUpper(newChar);
                }
                
                stringBuilder.Append(newChar);
            }
            else
            {
                stringBuilder.Append(ch);
            }
        }

        return stringBuilder.ToString();
    }
}
