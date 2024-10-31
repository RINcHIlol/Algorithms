using System.Security.Cryptography;

class MedianFinder
{
    private int[] numbers;

    public MedianFinder(){
        numbers = new int[]{};
    }

    public void AddNum(int input){
        Array.Resize(ref numbers, numbers.Length+1);
        numbers[numbers.Length - 1] = input;
        Array.Sort(numbers);
    }

    public double FindMedian(){
        var len = numbers.Length;
        if (len%2 == 0){
            return (Convert.ToDouble(numbers[len/2])+Convert.ToDouble(numbers[len/2-1]))/2;
        } else{
            return numbers[len/2];
        }
    }
}

class Program
{
    static void Main(){
        MedianFinder medianFinder = new MedianFinder();
        medianFinder.AddNum(1);
        medianFinder.AddNum(3);
        medianFinder.AddNum(4);
        medianFinder.AddNum(5);
        Console.WriteLine(medianFinder.FindMedian());
    }
}