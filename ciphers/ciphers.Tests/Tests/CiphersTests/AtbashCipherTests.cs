using cipher.Ciphers;

namespace ciphers.Tests.Tests.CiphersTests;

[TestClass]
public sealed class AtbashCipherTests
{
    private const string SourceText = "Hello&world!12-";
    private const string CipherText = "Svool&dliow!12-";

    private AtbashCipher _cipher = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _cipher = new AtbashCipher();
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