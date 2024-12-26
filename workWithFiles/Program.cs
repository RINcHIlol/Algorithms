using System;
using System.IO;

namespace readwriteapp
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            //путь
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "workWithFiles.txt");
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Добавить");
                    Console.WriteLine("2. Просмотреть");
                    Console.WriteLine("3. Изменить");
                    Console.WriteLine("4. Удалить");
                    Console.WriteLine("5. Выйти");

                    Console.Write("Выбор: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Введите имя услуги: ");
                            string serviceName = Console.ReadLine();

                            Console.Write("Введите длительность услуги: ");
                            int durationMinutes = int.Parse(Console.ReadLine());

                            Console.Write("Введите стоимость услуги: ");
                            decimal price = decimal.Parse(Console.ReadLine());

                            DateTime executionTime = DateTime.Now;
                            
                            AddFile(filePath, serviceName, durationMinutes, price, executionTime);
                            Console.WriteLine("Услуга добавлена.");
                            break;

                        case "2":
                            ReadFile(filePath);
                            break;

                        case "3":
                            Console.Write("Введите имя услуги для изменения: ");
                            string oldServiceName = Console.ReadLine();

                            Console.Write("Введите новое имя услуги: ");
                            string newServiceName = Console.ReadLine();

                            Console.Write("Введите новую длительность услуги: ");
                            int newDurationMinutes = int.Parse(Console.ReadLine());

                            Console.Write("Введите новую стоимость услуги: ");
                            decimal newPrice = decimal.Parse(Console.ReadLine());

                            DateTime newExecutionTime = DateTime.Now;
                            
                            EditFile(filePath, oldServiceName, newServiceName, newDurationMinutes, newPrice, newExecutionTime);
                            Console.WriteLine("Услуга изменена.");
                            break;

                        case "4":
                            DelFile(filePath);
                            break;

                        case "5":
                            Console.WriteLine("Выход из программы.");
                            return;

                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Завершение работы программы.");
            }
        }
private static void AddFile(string filePath, string serviceName, int durationMinutes, decimal price, DateTime executionTime)
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                string line = $"{serviceName}, {durationMinutes} минут, {price} руб., {executionTime}";
                sw.WriteLine(line);
            }
        }

        private static void ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            Console.WriteLine("\nСодержимое файла:");
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        private static void EditFile(string filePath, string oldServiceName, string newServiceName, int newDurationMinutes, decimal newPrice, DateTime newExecutionTime)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            string tempFile = filePath + ".tmp";

            using (StreamReader sr = new StreamReader(filePath))
            using (StreamWriter sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(oldServiceName))
                    {
                        line = $"{newServiceName}, {newDurationMinutes} минут, {newPrice} руб., {newExecutionTime}";
                    }
                    sw.WriteLine(line);
                }
            }

            File.Delete(filePath);
            File.Move(tempFile, filePath);
        }

        private static void DelFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("Файл успешно удалён.");
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
    }
}