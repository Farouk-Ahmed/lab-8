using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    
    public static void Main()
    {
        Trainee[] Ts = new Trainee[]
        {
            new Trainee { name = "Farouk", Age = 25 },
            new Trainee { name = "Ahmed", Age = 32 },
            new Trainee { name = "Ola", Age = 28 },
            new Trainee { name = "Ali", Age = 35 },
            new Trainee { name = "Kmal", Age = 22 },

            
        };

        var firstPerson = Ts.First();
        Console.WriteLine($"First Person: {firstPerson.name}");

        var lastPerson = Ts.Last();
        Console.WriteLine($"Last Person: {lastPerson.name}");

        var Older = Ts.Where(person => person.Age > 30);
        Console.WriteLine("Older people:");
        foreach (var adult in Older)
        {
            Console.WriteLine($"{adult.name}, Age {adult.Age}");
        }

        var Younger = Ts.OrderBy(person => person.Age).Take(3);
        Console.WriteLine("Younger people :");
        foreach (var person in Younger)
        {
            Console.WriteLine($"{person.name}, Age {person.Age}");
        }

        var names = Ts.Select(person => person.name);
        Console.WriteLine("The All Names:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}
public class Trainee
{
    public string name { get; set; }
    public int Age { get; set; }
}
public static class CustomOperators
{
    public static TSource First<TSource>(this IEnumerable<TSource> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        foreach (var item in source)
        {
            return item;
        }

        throw new InvalidOperationException("No Elements.");
    }

    public static TSource Last<TSource>(this IEnumerable<TSource> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var lastItem = default(TSource);
        var found = false;

        foreach (var item in source)
        {
            lastItem = item;
            found = true;
        }

        if (!found)
        {
            throw new InvalidOperationException(" No Elements.");
        }

        return lastItem;
    }

    public static IEnumerable<TSource> Where<TSource>(
        this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TSource> Take<TSource>(
        this IEnumerable<TSource> source, int count)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        int co = 0;
        foreach (var item in source)
        {
            if (co >= count)
            {
                yield break;
            }

            yield return item;
            co++;
        }
    }

    public static IEnumerable<TSource> OrderBy<TSource, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> Selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (Selector == null)
        {
            throw new ArgumentNullException(nameof(Selector));
        }

        var sortedList = source.ToList();
        sortedList.Sort((x, y) => Comparer<TKey>.Default.Compare(Selector(x), Selector(y)));

        foreach (var item in sortedList)
        {
            yield return item;
        }
    }

    public static IEnumerable<TResult> Select<TSource, TResult>(
        this IEnumerable<TSource> source, Func<TSource, TResult> select)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (select == null)
        {
            throw new ArgumentNullException(nameof(select));
        }

        foreach (var item in source)
        {
            yield return select(item);
        }
    }
}

