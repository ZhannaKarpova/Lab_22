using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() => {
                Console.WriteLine($"номер задач: {Task.CurrentId}");
            });
            Console.WriteLine("Введите n");
            int l = int.Parse(Console.ReadLine());
            int[] a = new int[l];
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine("Введите {0}-й элемент", i + 1);
                a[i] = int.Parse(Console.ReadLine());
            }
            int k = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] % 2 == 0)
                    k++;
            Console.WriteLine("максимальное значение");
            int max = int.MinValue;
            foreach (int m in a)
            {
                if (m > max)
                {

                    max = m;
                }
            }
            Console.WriteLine(max);
            // задача продолжения
            Task task2 = task1.ContinueWith(Display);

            task1.Start();
            Console.WriteLine("сумма чисел");

            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            Console.WriteLine(sum);

            task2.Wait();
            Console.WriteLine("Выполняется работа метода Main");
            Console.ReadLine();
            Console.ReadKey();
            }
        static void Display(Task t)
        {
            Console.WriteLine($"номер задачи: {Task.CurrentId}");
            Console.WriteLine($"номер предыдущей задачи: {t.Id}");
            Thread.Sleep(1000);
        }
    }
}

    

