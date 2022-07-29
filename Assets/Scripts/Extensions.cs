using UnityEngine;
using System.Collections.Generic;
using System.Linq;

static class Extensions
{
    public static T PickRandom<T>(this IEnumerable<T> collection)
    {
        var element = Random.Range(0, collection.Count());
        return collection.ElementAt(element);
    }
}
