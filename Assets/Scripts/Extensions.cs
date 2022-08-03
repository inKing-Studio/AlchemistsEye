using UnityEngine;
using System.Collections.Generic;
using System.Linq;

static class Extensions
{
    public static T PickRandom<T>(this IEnumerable<T> collection) => PickRandom(collection, Random.Range);

    public static T PickRandom<T>(this IEnumerable<T> collection, System.Func<int, int, int> rng)
    {
        var element = rng(0, collection.Count());
        return collection.ElementAt(element);
    }
}
