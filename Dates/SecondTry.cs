// using System;

// public class Programmmmmmmm
// {
//     public static void Main()
//     {
//         DateTime[] startTimes = {
//             new DateTime(2024, 1, 1, 10, 0, 0), 
//             new DateTime(2024, 1, 1, 11, 0, 0), 
//             new DateTime(2024, 1, 1, 15, 0, 0), 
//             new DateTime(2024, 1, 1, 15, 30, 0), 
//             new DateTime(2024, 1, 1, 16, 50, 0)
//         };
//         int[] durations = { 60, 30, 10, 10, 40 };
//         var beginWorkingTime = new DateTime(2024, 1, 1, 8, 0, 0);
//         var endWorkingTime = new DateTime(2024, 1, 1, 18, 0, 0);
//         var consultationTime = 30;

//         var result = createAll(startTimes, durations, consultationTime, beginWorkingTime, endWorkingTime);
        
//         // Вывод результатов
//         // foreach (var buba in result)
//         // {
//         //     Console.WriteLine(buba[0].ToShortTimeString() + "-" +  buba[1].ToShortTimeString());
//         // }

//         Console.WriteLine("");

//         var result2 = createAllWorkTime(startTimes, durations);

//         // foreach (var buba in result2)
//         // {
//         //     Console.WriteLine(buba[0].ToShortTimeString() + "-" +  buba[1].ToShortTimeString());
//         // }

//         var result3 = Dates(startTimes, durations, consultationTime, beginWorkingTime, endWorkingTime);

//         foreach (var buba in result2)
//         {
//             Console.WriteLine(buba[0].ToShortTimeString() + "-" +  buba[1].ToShortTimeString());
//         }
//     }

//     static DateTime[][] Dates(DateTime[] startTimes, int[] durations, int consultationTime, DateTime beginWorkingTime, DateTime endWorkingTime)
//     {
//         var all = createAll(startTimes, durations, consultationTime, beginWorkingTime, endWorkingTime);

//         var allWorkTime = createAllWorkTime(startTimes, durations);

//         DateTime[][] result = new DateTime[0][];

//         foreach(DateTime[] buba in all){
//             foreach(DateTime[] buba2 in allWorkTime){
//                 if (buba[0] < buba2[0] || buba[1] >= buba2[1]){
//                     Array.Resize(ref result, result.Length + 1);
//                     result[result.Length - 1] = new DateTime[]{buba[0], buba[1]};
//                 }
//             }
//         }
//         return result;
//     }

//     static DateTime[][] createAll(DateTime[] startTimes, int[] durations, int consultationTime, DateTime beginWorkingTime, DateTime endWorkingTime)
//     {
//         DateTime i = beginWorkingTime;
//         int j = 0;

//         DateTime[] perechod = new DateTime[0];
        
//         while(i < endWorkingTime){
//             if (i >= startTimes[j]){
//                 if (j < durations.Length-1){
//                     j++;
//                 }
//             }
//             if (j > 0){
//                 if (durations[j-1] < consultationTime){
//                     Array.Resize(ref perechod, perechod.Length + 1);
//                     perechod[perechod.Length - 1] = i.AddMinutes(durations[j-1]);
//                 }
//                 if (durations[j-1] > consultationTime && durations[j-1] < 60){
//                     Array.Resize(ref perechod, perechod.Length + 1);
//                     perechod[perechod.Length - 1] = i.AddMinutes(durations[j-1]);
//                 }
//             }
//             i = i.AddMinutes(consultationTime);
//             Array.Resize(ref perechod, perechod.Length + 1);
//             perechod[perechod.Length - 1] = i;
//         }

//         // foreach (var buba in perechod)
//         // {
//         //     Console.WriteLine(buba.ToShortTimeString());
//         // }

//         int maxSlots = perechod.Length * 3;
//         DateTime[][] timeSlots = new DateTime[maxSlots][];
    
//         int index = 0;
//         int slotIndex = 0;

//         while (slotIndex < perechod.Length - 3)
//         {
//             if (index < timeSlots.Length)
//             {
//                 timeSlots[index] = new DateTime[] { perechod[slotIndex], perechod[slotIndex + 1] };
//                 timeSlots[index+1] = new DateTime[] { perechod[slotIndex], perechod[slotIndex + 2] };
//                 timeSlots[index+2] = new DateTime[] { perechod[slotIndex], perechod[slotIndex + 3] };
//                 slotIndex++;
//             }
//             index+=3;
//         }

//         Array.Resize(ref timeSlots, index);

//         return timeSlots;
//     }

//     static DateTime[][] createAllWorkTime(DateTime[] startTimes, int[] durations){
//         int maxSlots = startTimes.Length;
//         DateTime[][] timeSlots = new DateTime[maxSlots][];

//         for (int i = 0; i < maxSlots; i++){
//             timeSlots[i] = new DateTime[]{startTimes[i], startTimes[i].AddMinutes(durations[i])};
//         }
//         return timeSlots;
//     }
// }