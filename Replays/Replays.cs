using System.Runtime.InteropServices;

class Replays
{
    private int[] numbers;
    public Replays()
    {
        numbers = new int[2];
    }

    public void Find(int[] input)
    {
        var Replays = new Dictionary<int, int>();
        foreach(var i in input)
        {
            if (Replays.ContainsKey(i))
            {
                Replays[i]++;
            } else{
                Replays[i] = 1;
            }
        }
        int chislo = 0;
        foreach(var r in Replays)
        {
            if (r.Value < 2)
            {
                numbers[chislo] = r.Key;
                chislo++;
            }
        }
    }


    public void Print()
    {
        foreach(var i in numbers)
        {
            Console.Write(i + " ");
        }
    }
}

class Program()
{
    static void Main()
    {
        int[] buba = {1, 2, 5, 3, 5, 2};
        var replays = new Replays();
        replays.Find(buba);
        replays.Print();
    }
}