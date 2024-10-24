class Program
{
    static void Main()
    {   
        // int[] result;
        // int[]input = {52, 8, 4, 6, 53, 5, 40, 69};
        // (int[] first, int[] second) = DevideArrays(input);
        // result = SortArrays(first, second);

        int[] result;
        int[]input = {52, 8, 4, 6, 53, 5, 40, 69, 7};
        result = DevideArrays(input);

        // var str1 = string.Join(" ", first);
        // Console.WriteLine(str1);

        // var str2 = string.Join(" ", second);
        // Console.WriteLine(str2);

        var str3 = string.Join(" ", result);
        Console.WriteLine(str3 + " from Main");
    }

    static int[] DevideArrays(int[] array)
    {
        // int[] array = {1, 2, 3, 4, 5, 6, 65, 54};
        int[] result;
        int middle = array.Length / 2;
        int[] leftArray = new int[middle];
        for (int i = 0; i < middle; i++)
        {
            leftArray[i] = array[i];
        }
        int[] rightArray = new int[array.Length - middle];
        for (int i = middle; i < array.Length; i++)
        {
            rightArray[i - middle] = array[i];
        }

        if (rightArray.Length > 1){
            rightArray = DevideArrays(rightArray);
        }
        if (leftArray.Length > 1){
            leftArray = DevideArrays(leftArray);
        }
        result = SortArrays(rightArray, leftArray);

        var str3 = string.Join(" ", result);
        Console.WriteLine(str3 + " from DevideArrays");

        return result;
    }

    static int[] SortArrays(int[] arrayOne, int[] arrayTwo)
    {
        // int[] arrayOne = {1,3};
        // int[] arrayTwo = {2,6,8};
        int[] arrayRes = new int[arrayOne.Length + arrayTwo.Length];
        int result = 0;
        int i = 0;
        int j = 0;

        while (i < arrayOne.Length && j < arrayTwo.Length)
        {
            if (arrayOne[i] <= arrayTwo[j])
            {
                arrayRes[result] = arrayOne[i];
                i++;
            }
            else
            {
                arrayRes[result] = arrayTwo[j];
                j++;
            }
            result++;
            var str3 = string.Join(" ", arrayRes);
            Console.WriteLine(str3);
        }
        while (i < arrayOne.Length)
        {
            arrayRes[result] = arrayOne[i];
            i++;
            result++;
        }
        while (j < arrayTwo.Length)
        {
            arrayRes[result] = arrayTwo[j];
            j++;
            result++;
        }

        var str = string.Join(" ", arrayRes);
        Console.WriteLine(str);

        return arrayRes;
    }
}