using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Extensions
{
    #region List / Collection Extensions

    public static T GetRandom<T>(this IList<T> list)
    {
        if (list == null || list.Count == 0)
            throw new InvalidOperationException("List is null or empty");

        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    
    public static int Random0To100(this object _)
    {
        return Random.Range(0, 101);
    }

    #endregion
}