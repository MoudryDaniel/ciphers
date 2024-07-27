using System.Collections;

namespace cipher.Tests;

public static class CustomAssert
{
    public static void AreEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
    {
        Assert.AreEqual(expected.Count(), actual.Count());

        IEnumerator exp = expected.GetEnumerator();
        IEnumerator act = actual.GetEnumerator();

        while (exp.MoveNext() && act.MoveNext())
        {
            Assert.AreEqual(exp.Current, act.Current);
        }
    }
}
