class Zeros
{
    public int[] Move(int[] input)
    {
        for(int i = 0; i < input.Length-1; i++)
        {
            if (input[i] == 0)
            {
                for (int k = i; k < input.Length-1; k++)
                {
                    input[k] = input[k+1];
                }
                input[input.Length-1] = 0;
            }
        }
        return input;
    }
}

class Program
{
    static void Main()
    {
        int[] buba = {0, 2, 0, 4, 5, 0};
        var Mover = new Zeros();
        buba = Mover.Move(buba);
        foreach(var i in buba)
        {
            Console.Write(i + " ");
        }
    }
}