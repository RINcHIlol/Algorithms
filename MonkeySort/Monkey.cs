using System;
using System.Runtime.CompilerServices;

class Programm
{
    static void Main()
    {
        //Ввод чисел в консоль
        Console.Write("Введите количество чисел: ");
        int count = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[count];
        Console.Write("Введите Числа: ");
        for (int i = 0; i < count; i++)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            array[i] = number;
        }
        Monkey(array);
    }

    static void Monkey(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        //Рандомит местами по очереди
                        Random random = new Random();
                        int randomIndex = random.Next(array.Length);
                        int temp = array[j];
                        array[j] = array[randomIndex];
                        array[randomIndex] = temp;
                    }

                    foreach (int element in array)
                    {
                        Console.Write(element + " ");
                    }
                    Console.WriteLine("");

                    i = -1;
                }
            }
        }
    }