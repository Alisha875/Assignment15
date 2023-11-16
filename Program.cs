using System;
using System.Collections.Generic;

class LargeDataCollection : IDisposable
{
    private List<object> data;

    public LargeDataCollection(int initialSize)
    {
        data = new List<object>(initialSize);
    }

    public void Add(object item)
    {
        data.Add(item);
    }

    public void Remove(object item)
    {
        data.Remove(item);
    }

    public object Get(int index)
    {
        return data[index];
    }

    public void Dispose()
    {
        data.Clear();
        data = null;
        GC.SuppressFinalize(this);
    }
}

class Program
{
    static void Main()
    {
        using (var largeDataCollection = new LargeDataCollection(1000000))
        {
            for (int i = 0; i < 1000000; i++)
            {
                largeDataCollection.Add(i);
            }

            largeDataCollection.Remove(500000);

            Console.WriteLine(largeDataCollection.Get(500000));
        }
        Console.ReadKey();
    }
}