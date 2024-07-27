using cipher.Ciphers;

namespace ciphers.Tests.Tests.CiphersTests;


[TestClass]
public sealed class Rot13CipherTests
{
    private const string SourceText = "Hello&world!12-";
    private const string CipherText = "Uryyb&jbeyq!12-";

    private Rot13Cipher _cipher = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _cipher = new Rot13Cipher();
    }

    [TestMethod]
    public void Encrypt_ReturnsCorrectCiphertext()
    {
        string cipherText = _cipher.Encrypt(SourceText);

        Assert.AreEqual(CipherText, cipherText);
    }

    [TestMethod]
    public void Decrypt_ReturnMatchesSourceText()
    {
        string text = _cipher.Decrypt(CipherText);

        Assert.AreEqual(SourceText, text);
    }
}
