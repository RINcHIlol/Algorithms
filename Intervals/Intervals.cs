using System.Xml.XPath;

class SummaryRanges
{
    private int[] numbers;

    public SummaryRanges(){
        numbers = new int[]{};
    }

    public void addNum(int value){
        Array.Resize(ref numbers, numbers.Length+1);
        numbers[numbers.Length - 1] = value;
        Array.Sort(numbers);
    }

    public int[][] getIntervals(){
        var result = new int[][]{};
        var perehod = new int[]{};
        for (int i = 0; i < numbers.Length; i++)
        {
            if (perehod.Length == 0)
            {
                Array.Resize(ref perehod, perehod.Length+1);
                perehod[perehod.Length - 1] = numbers[i];
            }
            if (i == numbers.Length-1)
            {
                if (perehod.Length == 1)
                {
                    Array.Resize(ref perehod, perehod.Length+1);
                    perehod[perehod.Length - 1] = numbers[i];
                }
                Array.Resize(ref result, result.Length+1);
                result[result.Length - 1] = perehod;
                return result; 
            }

            if (numbers[i+1] - numbers[i] == 1)
            {
                Array.Resize(ref perehod, perehod.Length+1);
                perehod[perehod.Length - 1] = numbers[i+1];
            }else{
                if (perehod.Length < 2)
                {
                    Array.Resize(ref perehod, perehod.Length+1);
                    perehod[perehod.Length - 1] = numbers[i];
                }
                Array.Resize(ref result, result.Length+1);
                result[result.Length - 1] = perehod;
                perehod = new int[]{};
            }
        }
        return result;
    }

    public void Print(int[][] result)
    {
        foreach(var lala in result)
        {
            Console.Write("[");
            for (int i = 0; i < lala.Length; i++)
            {
                Console.Write(lala[i]);
                if (i != lala.Length-1)
                {
                    Console.Write(",");
                }
            }
            Console.Write(']');
            if (lala != result[result.Length-1])
            {
                Console.Write(", ");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        SummaryRanges sumR = new SummaryRanges();
        sumR.addNum(1);
        sumR.addNum(3);
        sumR.addNum(7);
        sumR.addNum(4);
        sumR.addNum(2);
        var a = sumR.getIntervals();
        sumR.Print(a);
    }
}