using System;
using System.Threading;

class Program
{
    static int[] array;
    static int maxResult;
    static int minResult;

    static void Main(string[] args)
    {
        Console.Write("Введіть розмір масиву: ");
        int size = int.Parse(Console.ReadLine());
        array = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введіть елемент масиву {i}: ");
            array[i] = int.Parse(Console.ReadLine());
        }


        Thread maxThread = new Thread(FindMax);
        Thread minThread = new Thread(FindMin);
        maxThread.Start();
        minThread.Start();
        maxThread.Join();
        minThread.Join();


        Console.WriteLine($"Максимальний елемент: {maxResult}");
        Console.WriteLine($"Мінімальний елемент: {minResult}");

        Console.ReadKey();
    }

    static void FindMax()
    {
        int max = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        maxResult = max;
    }

    static void FindMin()
    {
        int min = int.MaxValue;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        minResult = min;
    }
}




