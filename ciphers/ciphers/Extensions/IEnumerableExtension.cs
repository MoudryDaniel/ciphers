using cipher.Enums;

namespace cipher.Extensions;

public static class IEnumerableExtension
{
    public static IEnumerable<T> Rotate<T>(this IEnumerable<T> enumerable, int positions, Direction direction)
    {
        if (positions < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(positions), $"Parameter {nameof(positions)} can contain only non-negative values.");
        }

        if (positions == 0)
        {
            return enumerable.ToList();
        }

        positions %= enumerable.Count();

        T[] temp = new T[positions];
        T[] arr = enumerable.ToArray();

        int arrLengthDiff = arr.Length - positions;

        if (direction == Direction.Right)
        {
            Array.Copy(arr, arrLengthDiff, temp, 0, positions);
            Array.Copy(arr, 0, arr, positions, arrLengthDiff);
            Array.Copy(temp, 0, arr, 0, positions);
        }
        else
        {
            Array.Copy(arr, 0, temp, 0, positions);
            Array.Copy(arr, positions, arr, 0, arrLengthDiff);
            Array.Copy(temp, 0, arr, arrLengthDiff, positions);
        }

        return arr;
    }
}
