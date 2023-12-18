namespace Task_1.Generator
{
    public static class TxtFileGenerator
    {
        //Константы для генерации данных
        private const string LatinString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string RussianString = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        //Путь к файлам
        private static string FilesPath = String.Empty;
        private static string CombinedFilesPath = String.Empty;

        private static Random random = new Random();

        public static void GenerateFilePath()
        {
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;

            //Путь для создания папок с файлами
            string filesDirectory = Path.Combine(projectRoot, "..", "..", "..", "Files");
            string combinedFilesDirectory = Path.Combine(projectRoot, "..", "..", "..", "CombinedFiles");

            if (!Directory.Exists(filesDirectory))
            {
                Console.WriteLine("Files directory created");
                Directory.CreateDirectory(filesDirectory);
            }

            if (!Directory.Exists(combinedFilesDirectory))
            {
                Console.WriteLine("Combined files directory created");
                Directory.CreateDirectory(combinedFilesDirectory);
            }

            FilesPath = filesDirectory;
            CombinedFilesPath = combinedFilesDirectory;
        }
        public static void GenerateTxtFiles()
        {
            //Создание 100 файлов с количестов строк 100000
            for (int i = 1; i <= 100; i++)
            {
                string[] data = new string[100000];
                for (int j = 0; j < 100000; j++)
                {
                    data[j] = GenerateData();
                }

                File.WriteAllLines($"{FilesPath}/FILE{i}.txt", data);
            }
            Console.WriteLine("Successfully genereated...");
        }
        
        //Генерация строки для файла
        private static string GenerateData()
        {
            DateTime randomDate = DateTime.Now.AddDays(-random.Next(1, 1825));
            string date = randomDate.ToString("dd.MM.yyyy");

            int evenInt = random.Next(1, 50000000) * 2;

            double floatNum = Math.Round(random.NextDouble() * (20 - 1) + 1, 8);

            string latinChars = new string(Enumerable.Range(0, 10)
                .Select(_ => LatinString[random.Next(LatinString.Length)])
                .ToArray());

            string russianChars = new string(Enumerable.Range(0, 10)
                .Select(_ => RussianString[random.Next(RussianString.Length)])
                .ToArray());

            string totalString = $"{date}||{latinChars}||{russianChars}||{evenInt}||{floatNum}||";

            return totalString;
        }

        //Объединение файлов
        public static void CombineFiles(string stringToRemove)
        {
            int linesRemoved = 0;

            Console.WriteLine("Enter the name of the file:");
            var filename = Console.ReadLine();

            Console.WriteLine("Generting combined file...");

            using (StreamWriter output = new StreamWriter($"{CombinedFilesPath}/{filename}.txt"))
            {
                for (int i = 1; i <= 100; i++)
                {
                    string[] lines = File.ReadAllLines($"{FilesPath}/FILE{i}.txt");
                    linesRemoved += lines.Count(line => line.Contains(stringToRemove));
                    //Удаление строки по определённому условию
                    lines = lines.Where(line => !line.Contains(stringToRemove)).ToArray();
                    output.Write(string.Join(Environment.NewLine, lines));
                    output.Write('\n');
                }
            }
            Console.WriteLine("Generated successfully...");
            Console.WriteLine($"Lines removed: {linesRemoved}");
        }
    }
}