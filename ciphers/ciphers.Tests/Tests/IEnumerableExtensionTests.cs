using cipher.Enums;
using cipher.Extensions;

namespace cipher.Tests.Tests;

[TestClass]
public sealed class IEnumerableExtensionTests
{
    private readonly IEnumerable<string> _enumerable = ["Hello", "world", "!"];

    // -------------------------------------- Rotate Right --------------------------------------
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RotateRight_PositionsNegative_Throws()
    {
        int positions = -2;
        _enumerable.Rotate(positions, Direction.Right);
    }

    [TestMethod]
    public void RotateRight_PositionsZero_ReturnsIdenticalEnumerable()
    {
        int positions = 0;

        CustomAssert.AreEqual(["Hello", "world", "!"], _enumerable.Rotate(positions, Direction.Right));
    }

    [TestMethod]
    public void RotateRight_PositionsPositive_ReturnsRotatedEnumerable()
    {
        int positions = 2;

        CustomAssert.AreEqual(["world", "!", "Hello"], _enumerable.Rotate(positions, Direction.Right));
    }

    [TestMethod]
    public void RotateRight_PositionsGreaterThanEnumerableLength_ReturnsRotatedEnumerable()
    {
        int positions = 7;

        CustomAssert.AreEqual(["!", "Hello", "world"], _enumerable.Rotate(positions, Direction.Right));
    }

    // -------------------------------------- Rotate Left --------------------------------------
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RotateLeft_PositionsNegative_Throws()
    {
        int positions = -2;
        _enumerable.Rotate(positions, Direction.Left);
    }

    [TestMethod]
    public void RotateLeft_PositionsZero_ReturnsIdenticalEnumerable()
    {
        int positions = 0;

        CustomAssert.AreEqual(["Hello", "world", "!"], _enumerable.Rotate(positions, Direction.Left));
    }

    [TestMethod]
    public void RotateLeft_PositionsPositive_ReturnsRotatedEnumerable()
    {
        int positions = 2;

        CustomAssert.AreEqual(["!", "Hello", "world"], _enumerable.Rotate(positions, Direction.Left));
    }

    [TestMethod]
    public void RotateLeft_PositionsGreaterThanEnumerableLength_ReturnsRotatedEnumerable()
    {
        int positions = 7;

        CustomAssert.AreEqual(["world", "!", "Hello"], _enumerable.Rotate(positions, Direction.Left));
    }
}
