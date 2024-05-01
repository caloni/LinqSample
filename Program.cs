public class LinqSample
{
    private static void FirstSample()
    {
        // https://learn.microsoft.com/en-us/dotnet/csharp/linq/

        // Specify the data source.
        int[] scores = [97, 92, 81, 60];

        // Define the query expression.
        IEnumerable<int> scoreQuery =
            from score in scores
            where score > 80
            select score;

        // Execute the query.
        foreach (var i in scoreQuery)
        {
            Console.Write(i + " ");
        }
        // Output: 97 92 81
        Console.WriteLine();
    }
    private static void FirstSampleV2()
    {
        // Specify the data source.
        int[] scores = [97, 92, 81, 60];

        // Define the query expression.
        IEnumerable<int> scoreQuery =
            scores.Where(s => s > 80);

        // Execute the query.
        foreach (var i in scoreQuery)
        {
            Console.Write(i + " ");
        }
        // Output: 97 92 81
        Console.WriteLine();
    }
    private static void SecondSample()
    {
        // Specify the data source.
        int[] numbers = [1, 2, 3, 4];

        // Define the query expression.
        int result = numbers.Aggregate((interim, next) => interim + next);

        // Execute the query.
        Console.WriteLine(result);
        // Output: 10
    }
    private static void ThirdSample()
    {
        // Specify the data source.
        int[] numbers = [4, 2, 3, 1];

        // Define the query expression.
        IEnumerable<int> result = numbers.Order();

        // Execute the query.
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        // Output: 1, 2, 3, 4
        Console.WriteLine();
    }

    private static void ThirdSampleV2()
    {
        // Specify the data source.
        int[] numbers = [4, 2, 3, 1];

        // Define the query expression.
        IEnumerable<int> result = numbers.OrderDescending();

        // Execute the query.
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        // Output: 4, 3, 2, 1
        Console.WriteLine();
    }

    private static void ThirdSampleV3()
    {
        // Specify the data source.
        int[] numbers = [4, 2, 3, 1];

        // Define the query expression.
        IEnumerable<int> result = numbers.Order(Comparer<int>.Create((left, right) => left - right));

        // Execute the query.
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        // Output: 1, 2, 3, 4
        Console.WriteLine();
    }

    private static void ThirdSampleV4()
    {
        // Specify the data source.
        int[] numbers = [4, 2, 3, 1];

        // Define the query expression.
        IEnumerable<int> result = numbers.OrderDescending(Comparer<int>.Create((left, right) => left - right));

        // Execute the query.
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        // Output: 4, 3, 2, 1
        Console.WriteLine();
    }

    private struct FourthElement
    {
        public int numberA;
        public int numberB;
    };

    private static void FourthSample()
    {
        // Specify the data source.
        FourthElement[] numbers = [
            new FourthElement{ numberA = 4, numberB = 21 },
            new FourthElement{ numberA = 2, numberB = 23 },
            new FourthElement{ numberA = 1, numberB = 24 },
            new FourthElement{ numberA = 3, numberB = 22 },
        ];

        // Define the query expression.
        IEnumerable<FourthElement> result = numbers.OrderBy(e => e.numberA, 
            Comparer<int>.Create((left, right) => left - right));

        // Execute the query.
        foreach (var i in result)
        {
            Console.WriteLine($"A: {i.numberA} B: {i.numberB}");
        }
        // Output:
        // A: 1 B: 24
        // A: 2 B: 23
        // A: 3 B: 22
        // A: 4 B: 21
    }
    private static void FourthSampleV2()
    {
        // Specify the data source.
        FourthElement[] numbers = [
            new FourthElement{ numberA = 4, numberB = 21 },
            new FourthElement{ numberA = 2, numberB = 23 },
            new FourthElement{ numberA = 1, numberB = 24 },
            new FourthElement{ numberA = 3, numberB = 22 },
        ];

        // Define the query expression.
        IEnumerable<FourthElement> result = numbers.OrderBy(e => e.numberB, 
            Comparer<int>.Create((left, right) => left - right));

        // Execute the query.
        foreach (var i in result)
        {
            Console.WriteLine($"A: {i.numberA} B: {i.numberB}");
        }
        // Output:
        // A: 4 B: 21
        // A: 3 B: 22
        // A: 2 B: 23
        // A: 1 B: 24
    }
    private static void FourthSampleV3()
    {
        // Specify the data source.
        FourthElement[] numbers = [
            new FourthElement{ numberA = 2, numberB = 2 },
            new FourthElement{ numberA = 1, numberB = 1 },
            new FourthElement{ numberA = 2, numberB = 1 },
            new FourthElement{ numberA = 1, numberB = 2 },
        ];

        // Define the query expression.
        IEnumerable<FourthElement> result = numbers.Order(Comparer<FourthElement>.Create((l, r) 
            => l.numberA < r.numberA ? -1 : r.numberA < l.numberA ? 1 : l.numberB - r.numberB ));

        // Execute the query.
        foreach (var i in result)
        {
            Console.WriteLine($"{i.numberA}.{i.numberB}");
        }
        // Output:
        // 1.1
        // 1.2
        // 2.1
        // 2.2
    }
    private static void FourthSampleV4()
    {
        // Specify the data source.
        FourthElement[] numbers = [
            new FourthElement{ numberA = 2, numberB = 2 },
            new FourthElement{ numberA = 1, numberB = 1 },
            new FourthElement{ numberA = 2, numberB = 1 },
            new FourthElement{ numberA = 1, numberB = 2 },
        ];

        // Define the query expression.
        IEnumerable<FourthElement> result = numbers.Order(Comparer<FourthElement>.Create((l, r) 
            => l.numberB < r.numberB ? 1 : r.numberB < l.numberB ? -1 : l.numberA - r.numberA ));

        // Execute the query.
        foreach (var i in result)
        {
            Console.WriteLine($"{i.numberA}.{i.numberB}");
        }
        // Output:
        // 1.2
        // 2.2
        // 1.1
        // 2.1
    }
    private static void FifthSample()
    {
        // Specify the data source.
        FourthElement[] numbers = [
            new FourthElement{ numberA = 4, numberB = 21 },
            new FourthElement{ numberA = 2, numberB = 23 },
            new FourthElement{ numberA = 1, numberB = 24 },
            new FourthElement{ numberA = 3, numberB = 22 },
        ];

        // Define the query expression.
        var result = numbers.Select(n => n.numberA);

        // Execute the query.
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        // Output:
        // 4 2 1 3
    }
    private static void FifthSampleV2()
    {
        // Specify the data source.
        FourthElement[] numbers = [
            new FourthElement{ numberA = 4, numberB = 21 },
            new FourthElement{ numberA = 2, numberB = 23 },
            new FourthElement{ numberA = 1, numberB = 24 },
            new FourthElement{ numberA = 3, numberB = 22 },
        ];

        // Define the query expression.
        var result = numbers.Select(n => n.numberB + n.numberA);

        // Execute the query.
        foreach (var i in result)
        {
            Console.Write($"{i} ");
        }
        // Output:
        // 25 25 25 25
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        FifthSampleV2();
    }
}
