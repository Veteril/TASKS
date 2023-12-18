using Task_1.DatabaseContext;
using Task_1.Model;

namespace Task_1.Database
{
    public static class DatabaseActions
    {
        //Импорт файлов в БД 
        public static void ImportTxtFiles(string filePath, int startLineNumber = 1)
        {
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;

            string fileDirectory = Path.Combine(projectRoot, "..", "..", "..", filePath);

            using (var context = new TxtDbContext())
            {
                using (var reader = new StreamReader(fileDirectory))
                {
                    //Считываем все строки
                    string content = reader.ReadToEnd();
                    string[] lines = content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                    int numberOfLines = lines.Length;
                    //Счётчик добавленных строк
                    int importedCount = 0;

                    for (int i = startLineNumber - 1; i < numberOfLines; i++)
                    {
                        //Разделяем строку с данными в массив
                        string[] fields = lines[i].Split(new[] { "||" }, StringSplitOptions.None);

                        //Объект для БД
                        var txtData = new TxtData
                        {
                            Date = DateTime.Parse(fields[0]),
                            LatinString = fields[1],
                            RussianString = fields[2],
                            EvenIntegerNumber = int.Parse(fields[3]),
                            FloatNumber = double.Parse(fields[4])
                        };

                        context.Rows.Add(txtData);

                        importedCount++;

                        //Вывод прогресса импортирования
                        Console.WriteLine($"Imported {importedCount} rows. Remaining: {numberOfLines - importedCount - startLineNumber + 1}");
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
