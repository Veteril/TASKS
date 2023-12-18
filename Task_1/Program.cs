using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Task_1.Database;
using Task_1.DatabaseContext;
using Task_1.Generator;

TxtFileGenerator.GenerateFilePath();
while (true)
{
    const string connectionString = "Server =.\\SQLEXPRESS; Initial Catalog = TASK_1; Trusted_Connection = True; TrustServerCertificate = True";
    Console.WriteLine("Choose action:\n");
    Console.WriteLine("1. Generate/regenerate .txt files");
    Console.WriteLine("2. Combine .txt files");
    Console.WriteLine("3. Use migration to create tabel in MsSQL");
    Console.WriteLine("4. Import to MsSQL");
    Console.WriteLine("5. Query to MsSQL");

    string? choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("Generating...");
            TxtFileGenerator.GenerateTxtFiles();
            break;
        case "2":
            Console.WriteLine("Enter substirng for rows to delete: ");
            var substring = Console.ReadLine();

            if (substring == null)
            {
                Console.WriteLine("Invalid substring...");
                break;
            }

            TxtFileGenerator.CombineFiles(substring);
            break;

        case "3":
            //Применение миграции ддя создания таблицы
            using (var dbContext = new TxtDbContext())
            {
                var serviceProvider = dbContext.GetInfrastructure<IServiceProvider>();
                var migrator = serviceProvider.GetService<IMigrator>();
                migrator.Migrate();
            }
            break;

        case "4":
            Console.WriteLine("Enter filename to import(Files/... or CombinedFiles/...: ");
            var filePath = Console.ReadLine();

            if (filePath == null)
            {
                Console.WriteLine("Invalid file path...");
                break;
            }
            DatabaseActions.ImportTxtFiles(filePath);
            break;

        case "5":
            //Использовал не EntityFramework так как в задании конкретно написано SQL-скрипт
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT SUM(CAST([EvenIntegerNumber] AS bigint)) AS [EvenIntegerNumberSum]," +
                                                                  "SUM([FloatNumber]) AS [FloatNumberSum]," +
                                                                  "COUNT(*) AS [NumberOfRows] FROM [TASK_1].[dbo].[Rows]", connection))

                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Чтение результатов запроса
                            long sumOfIntegers = reader.IsDBNull(0) ? 0 : reader.GetInt64(0);
                            double sumOfFloats = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                            int rowCount = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);

                            // Проверка деления на ноль
                            double medianOfFloats = rowCount != 0 ? sumOfFloats / rowCount : 0;

                            // Вывод результатов
                            Console.WriteLine($"Sum of integers: {sumOfIntegers}");
                            Console.WriteLine($"Sum of floats: {sumOfFloats}");
                            Console.WriteLine($"Number of rows: {rowCount}");
                            Console.WriteLine($"Median of floats: {medianOfFloats}");
                        }
                    }
                }
                connection.Close();
            }
            break;

        default:
            Console.WriteLine("Invalid input");
            break;
    }
}