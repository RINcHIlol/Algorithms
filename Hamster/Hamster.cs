using System;
using System.Text;

public class Kata
{
    public static string HamsterMe(string code,  string message)
    {

//объявление переменных
        int[] codeMass = new int[code.Length];
        int buba = 0;
        
        foreach (char c in code)
        {
            int runeValue = c;
            codeMass[buba] = runeValue;
            buba++;
        }
        
//сортировка букв
        int[] newCode = BubbleSort(codeMass);
//нахождение количества строк и колонн
        int arrays = FindArray(newCode) + 2;
        int columns = newCode.Length;
//объявление и заполнение матрицы
        int[,] array = new int[arrays, columns];
        FillMatrix(array, newCode, columns, arrays);
//кодировка
        string result = Encoder(array, message, arrays, columns);

        return result;
    }

    static void Main(){
        string result = HamsterMe("f", "abcdefghijklmnopqrstuvwxyz");
        Console.Write(result);
    }

//сортровка
    static int[] BubbleSort(int[] array)
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
                    }
                }
                i = check;
            }
            return array;
        }

//нахождение колечества полей
    static int FindArray(int[] array)
    {
        if (array.Length == 1){
            return array[0];
        }

        int max = array[1] - array[0] ;
            for (int i = 0; i < array.Length-1; i++){
                if (max < array[i + 1] - array[i]){
                    max = array[i + 1] - array[i];
                }
            }
        if (array[0] != 97){
            max += array[0] - 97;
        }
        return max;
    }

//заполнение матрицы
    static void FillMatrix(int[,] array, int[] mass, int columns,  int arrays){
        int buba = 0;
        if (columns == 1){
        for (int i = 0; i < columns; i++){
            int promej = mass[i];
            array[0, i] = promej;
            for (int j = 1; j < arrays; j++){
                promej++;
                if (promej < mass[i]){
                    array[j, i] = promej;
                }
            }
        }
        }
        for (int i = 0; i < columns-1; i++){
            int promej = mass[i];
            array[0, i] = promej;
            for (int j = 1; j < arrays; j++){
                promej++;
                if (promej < mass[i+1]){
                    array[j, i] = promej;
                }
            }
        }
        int boba = mass[mass.Length-1];
        while(boba < 123){
            array[buba, columns-1] = boba;
            boba++;
            buba++;
        }
        boba = 97;
        if (array[0, 0] != 97){
            while(boba < array[0, 0]){
                array[buba, columns-1] = boba;
                boba++;
                buba++;
            }
        }
    }

//кодировка
    static string Encoder(int[,] array, string message, int arrays, int columns){
        string result = "";
        foreach(char c in message){
            int prom = c;
            for (int i=0; i < arrays; i++) { 
                for (int j=0; j < columns; j++) { 
                    if (prom == array[i, j]){
                        result += (char)array[0, j] + Convert.ToString(i+1); 
                    } 
                }
            }
        }

        return result;
    }
}