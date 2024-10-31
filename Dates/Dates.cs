using System;

class Program
{
    static void Main(string[] args)
    {
        // переменные
        string[] startTimeStrings = new string[]
        {
            "10:00",
            "11:00",
            "15:00",
            "15:30",
            "16:50"
        };
        DateTime[] startTimes = Array.ConvertAll(startTimeStrings, time => DateTime.ParseExact(time, "HH:mm", null).Add(DateTime.Today.TimeOfDay));
        int[] durations = new int[] { 60, 30, 10, 10, 50 };
        DateTime beginWorkingTime = DateTime.Today.AddHours(8);
        DateTime endWorkingTime = DateTime.Today.AddHours(18);
        int consultationTime = 30;

        // вызов функции
        string[] result = DatesBumBum(beginWorkingTime, endWorkingTime, startTimes, durations, consultationTime);

        // вывод
        int count = 0;
        foreach (string date in result)
        {
            if (!string.IsNullOrEmpty(date))
            {
                Console.WriteLine(date);
                count++;
            }
        }
        Console.WriteLine(count);
    }

    static string[] DatesBumBum(DateTime beginWorkingTime, DateTime endWorkingTime, DateTime[] startTimes, int[] durations, int consultationTime)
    {
        // переменные
        int maxIntervals = (int)((endWorkingTime - beginWorkingTime).TotalMinutes / consultationTime);
        string[] availablePeriods = new string[maxIntervals];
        int index = 0;
        DateTime workTime = beginWorkingTime;
        int i = 0;

        // проход по рабочему времени
        while (workTime < endWorkingTime)
        {
            DateTime nextBusyStart = (i < startTimes.Length) ? startTimes[i] : endWorkingTime;
            TimeSpan availableTime = nextBusyStart - workTime;
            int availableMinutes = (int)availableTime.TotalMinutes;

            // проход по свободному времени
            while (availableMinutes >= consultationTime)
            {
                DateTime nextAvailableEnd = workTime.AddMinutes(consultationTime);
                
                // Проверяем, чтобы не выходить за конец рабочего дня
                if (nextAvailableEnd > endWorkingTime)
                {
                    nextAvailableEnd = endWorkingTime;
                }
                
                availablePeriods[index++] = $"{workTime:HH:mm}-{nextAvailableEnd:HH:mm}";
                
                workTime = nextAvailableEnd;
                availableMinutes -= consultationTime;
            }

            // Переход к следующему занятому периоду
            if (i < startTimes.Length)
            {
                workTime = startTimes[i].AddMinutes(durations[i]);
                i++;
            }
            else
            {
                break;
            }
        }
        return availablePeriods;
    }
}