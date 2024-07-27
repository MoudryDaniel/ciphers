using cipher.Enums;
using cipher.Extensions;
using System.Text;

namespace cipher.Ciphers;

public sealed class CaesarCipher
{
    private readonly Dictionary<char, char> _encryptionSubstitutions = new();
    private readonly Dictionary<char, char> _decryptionSubstitutions = new();

    public CaesarCipher(int positions, Direction direction)
    {
        char[] alphabetChars = new char[Constants.AlphabetLength];
        char[] rotatedAlphabetChars = new char[Constants.AlphabetLength];

        Constants.alphabet.CopyTo(alphabetChars, 0);
        rotatedAlphabetChars = Constants.alphabet.Rotate(positions, direction).ToArray();

        _encryptionSubstitutions = Enumerable.Range(0, Constants.AlphabetLength)
            .ToDictionary(i => alphabetChars[i], i => rotatedAlphabetChars[i]);

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
