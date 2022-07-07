namespace Roguelike.Extensions;

public static class HashSetEx
{
    public static bool AddRange<T>(this HashSet<T> source, IEnumerable<T> items)
    {
        var allAdded = true;
        foreach (var item in items)
        {
            allAdded &= source.Add(item);
        }
        return allAdded;
    }
}