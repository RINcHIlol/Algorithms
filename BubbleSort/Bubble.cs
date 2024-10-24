using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

class Programm
{
    static void Main(){
        static void BubbleSort(int[] array)
            {
                int i = array.Length - 1;
                while (i > 0)
                {
                    int check = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (array[j].CompareTo(array[j+1]) > 0){
                            int temp = array[j];
                            array[j] = array[j+1];
                            array[j+1] = temp;
                            check = j;
                            foreach (int element in array){
                                Console.Write(element + " ");
                            }
                            Console.WriteLine("");
                        }
                    }
                    i = check;
                }
            }

    Console.Write("Введите количество чисел: ");
    int count = Convert.ToInt32(Console.ReadLine());
    int[] array = new int[count];
    Console.Write("Введите Числа: ");
    for (int i = 0; i < count; i++){
        int number = Convert.ToInt32(Console.ReadLine());
        array[i] = number;
    }
    BubbleSort(array);
    }
}