using cipher.Ciphers;
using cipher.Enums;

namespace ciphers.Tests.Tests.CiphersTests;

[TestClass]
public sealed class CaesarCipherTests
{
    private const string SourceText = "Hello world&!12-";
    private const string CipherTextRotationRight = "Dahhk sknhz&!12-";
    private const string CipherTextRotationLeft = "Lipps asvph&!12-";

    private const int Positions = 56;

    private CaesarCipher _cipherRotateRight = null!;
    private CaesarCipher _cipherRotateLeft = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _cipherRotateRight = new CaesarCipher(Positions, Direction.Left);
        _cipherRotateLeft = new CaesarCipher(Positions, Direction.Right);
    }

    // -------------------------------------- Rotate Right --------------------------------------
    [TestMethod]
    public void Encrypt_RotateRight_ReturnsCorrectCiphertext()
    {
        string cipherText = _cipherRotateLeft.Encrypt(SourceText);

        Assert.AreEqual(CipherTextRotationRight, cipherText);
    }

    [TestMethod]
    public void Decrypt_RotateRight_ReturnMatchesSourceText()
    {
        string text = _cipherRotateLeft.Decrypt(CipherTextRotationRight);

        Assert.AreEqual(SourceText, text);
    }

    // -------------------------------------- Rotate Left --------------------------------------
    [TestMethod]
    public void Encrypt_RotateLeft_ReturnsCorrectCiphertext()
    {
        string cipherText = _cipherRotateRight.Encrypt(SourceText);

        Assert.AreEqual(CipherTextRotationLeft, cipherText);
    }

    [TestMethod]
    public void Decrypt_RotateLeft_ReturnMatchesSourceText()
    {
        string text = _cipherRotateRight.Decrypt(CipherTextRotationLeft);

        Assert.AreEqual(SourceText, text);
    }
}
