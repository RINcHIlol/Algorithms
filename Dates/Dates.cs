class Program{
    static void Main(){
        DateTime[] startTimes = {new DateTime(2024, 1, 1, 10, 0, 0), new DateTime(2024, 1, 1, 11, 0, 0), new DateTime(2024, 1, 1, 15, 0, 0), new DateTime(2024, 1, 1, 15, 30, 0), new DateTime(2024, 1, 1, 16, 50, 0)};
        int[] durations = {60, 30, 10, 10, 40};
        var beginWorkingTime = new DateTime(2024, 1, 1, 8, 0, 0);
        var endWorkingTime = new DateTime(2024, 1, 1, 18, 0, 0);
        var consultationTime = 30;
        int count = 0;

        var result = DatesBumBum(startTimes, durations, consultationTime, beginWorkingTime, endWorkingTime);

        for (int i = 0; i < result.Length - 1; i++){
            if (i == result.Length-2){
                Console.WriteLine(result[i].ToShortTimeString() + "-" + result[i+1].ToShortTimeString());
                continue;
            }

            if (result[i+1].Subtract(result[i]).TotalMinutes == consultationTime){
                Console.WriteLine(result[i].ToShortTimeString() + "-" + result[i+1].ToShortTimeString());
                count++;
            } else if (result[i+2].Subtract(result[i]).TotalMinutes == consultationTime){
                Console.WriteLine(result[i].ToShortTimeString() + "-" + result[i+2].ToShortTimeString());
                i++;
                count++;
                // && !startTimes.Contains(result[i+3])
            } else{
                i++;
            }
        }
        Console.WriteLine(count);
    }

    static DateTime[] DatesBumBum(DateTime[] startTimes, int[] durations, int consultationTime, DateTime beginWorkingTime, DateTime endWorkingTime)
    {
        DateTime[] result =  new DateTime[0];
        DateTime[] realResult = new DateTime[0];
        DateTime i = beginWorkingTime;
        int j = 0;
        Array.Resize(ref result, result.Length + 1);
        result[result.Length - 1] = i;

//Добваление всех выходных данных(ПОЛНЫЙ)
        while(i < endWorkingTime){
            if (i >= startTimes[j]){
                if (j < durations.Length-1){
                    j++;
                }
            }
            if (j > 0){
                if (durations[j-1] < consultationTime){
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = i.AddMinutes(durations[j-1]);
                }
                if (durations[j-1] > consultationTime && durations[j-1] < 60){
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = i.AddMinutes(durations[j-1]);
                }
            }
            i = i.AddMinutes(consultationTime);
            Array.Resize(ref result, result.Length + 1);
            result[result.Length - 1] = i;
        }
        foreach(DateTime date in result){
            Console.WriteLine(date.ToShortTimeString());
        }

        DateTime lastOccupiedEndTime = DateTime.MinValue;
        foreach (DateTime date in result)
        {
            bool isOccupied = false;

            for (int k = 0; k < startTimes.Length; k++)
            {
                DateTime start = startTimes[k];
                DateTime end = start.AddMinutes(durations[k]);

                if (date >= start && date < end)
                {
                    isOccupied = true;
                    lastOccupiedEndTime = end;
                    break;
                }

                // if (k != durations.Length-1){
                //     if (startTimes[k+1].Subtract(date.AddMinutes(durations[k])).TotalMinutes < 30){
                //         isOccupied = true;
                //         break;
                //     }
                // }

            }

            if (!isOccupied)
            {
                Array.Resize(ref realResult, realResult.Length + 1);
                realResult[realResult.Length - 1] = date;
            }

            if (date == startTimes[0]){
                Array.Resize(ref realResult, realResult.Length + 1);
                realResult[realResult.Length - 1] = date;
            }
            if (realResult.Length - 1 > 0){
                if (date.Subtract(realResult[realResult.Length - 1]).TotalMinutes <= consultationTime && startTimes.Contains(date)){
                    Array.Resize(ref realResult, realResult.Length + 1);
                    realResult[realResult.Length - 1] = date;
                }
            }
        }
        Console.WriteLine(realResult.Length);
        foreach(DateTime opa in realResult){
            Console.WriteLine(opa.ToShortTimeString());
        }
        Console.WriteLine("");
        return realResult;
    }
}