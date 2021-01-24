using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class EnumExtensions
{

    /// <summary>
    /// Gets all items for an enum value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static IEnumerable<T> GetAllItems<T>(this Enum value)
    {
        foreach (object item in Enum.GetValues(typeof(T)))
        {
            yield return (T)item;
        }
    }

    public static IEnumerable<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

    public static Type GetTypeByName(string name)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.Name == name)
                    return type;
            }
        }

        return null;
    }
}
