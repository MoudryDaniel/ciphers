using cipher.Enums;
using cipher.Extensions;
using System.Text;

namespace cipher.Ciphers;

public sealed class Rot13Cipher
{
    private const int Positions = 13;

    private readonly Dictionary<char, char> _substitutions = new();

    public Rot13Cipher()
    {
        char[] alphabetChars = new char[Constants.AlphabetLength];
        char[] rotatedAlphabetChars = new char[Constants.AlphabetLength];

        Constants.alphabet.CopyTo(alphabetChars, 0);
        rotatedAlphabetChars = Constants.alphabet.Rotate(Positions, Direction.Right).ToArray();

        _substitutions = Enumerable.Range(0, Constants.AlphabetLength)
            .ToDictionary(i => alphabetChars[i], i => rotatedAlphabetChars[i]);
    }

    public string Encrypt(string text)
        => Substitute(text);
    public string Decrypt(string ciphertext)
        => Substitute(ciphertext);

    private string Substitute(string text)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char ch in text)
        {
            if (_substitutions.TryGetValue(char.ToLower(ch), out char newChar))
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
