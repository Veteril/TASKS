using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Text.RegularExpressions;
using Task_2.Database;
using Task_2.Models;
using ICell = NPOI.SS.UserModel.ICell;

namespace Task_2.Parser
{
    public static class ExcelParser
    {
        public static void ReadExcelFile(string filePath)
        {
            //Проверка существования файла
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            //Используем EntityFramework для взаимодействия с БД
            using (var context = new DatabaseContext())
            {
                
                string fileName = Path.GetFileName(filePath);

                //Проверка наличия файла в БД
                if (context.Files.Any(f => f.Name == fileName))
                {
                    throw new Exception("File already downloaded to database");
                }

                //Формируем объект для таблицы в БД
                var file = new Models.File
                {
                    Name = fileName
                };

                context.Files.Add(file);
                context.SaveChanges();

                //Использование библиотеки NPOI для считывания Excel файла 
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {

                    HSSFWorkbook workbook = new HSSFWorkbook(fileStream);

                    //Получаем страницу Excel файла, начинаем считывать с 9 строки
                    ISheet sheet = workbook.GetSheetAt(0);
                    int classRowNumber = 8;
                    bool isEndOfFile = false;

                    do
                    {   
                        //Получаем строку с классом из Excel
                        IRow classRow = sheet.GetRow(classRowNumber);
                        ICell classCell = classRow.GetCell(0);

                        //Считываем строку с информацией о классе
                        var classTable = GetClassTable(classCell, file.Id);
                        context.Classes.Add(classTable);
                        context.SaveChanges();

                        for (int rowIndex = classRowNumber + 1; ; rowIndex++)
                        {
                            //Получаем строку из Excel
                            IRow row = sheet.GetRow(rowIndex);
                            ICell cell = row.GetCell(0);

                            //Если конец файла 
                            if (cell.ToString() == "БАЛАНС" || cell == null)
                            {
                                context.SaveChanges();
                                isEndOfFile = true;
                                break;
                            }
                            else
                            {
                                //Если дошли до строки со следующим классом
                                if (cell.IsMergedCell)
                                {
                                    //Запоминаем номер строки для того чтобы считать класс и продолжить считывание данных со следующей строки
                                    classRowNumber = rowIndex;
                                    //Сохраняем в базу, так как информация о классе для следующих строк обновится
                                    context.SaveChanges();
                                    break;
                                }
                                //Если дошли до строки с общей информацией о группе или классе, пропускаем итерацию
                                else if (cell.ToString().Length > 4 || cell.ToString().Length == 2)
                                {
                                    continue;
                                }
                                //Считываем информацию из строки
                                var dataRow = GetDataRow(row, classTable.Id);
                                context.Rows.Add(dataRow);
                            }
                        }
                    }
                    while (!isEndOfFile);
                }
            }
        }

        private static DataRow GetDataRow(IRow row, int classId)
        {
            //Массив ячеек в строке
            ICell[] cells = new ICell[7];
            for (int cellIndex = 0; cellIndex < 7; cellIndex++)
            {
                cells[cellIndex] = row.GetCell(cellIndex);
            }

            //Считываем номер счёта
            var cellValue = cells[0].ToString();
            
            //Первая пара символов записывается в идентификатор группы, вторая в идентификатор строки
            string groupId = cellValue.Substring(0, 2);
            string rowId = cellValue.Substring(2); 

            //Формируем объект для таблицы в БД, записываем все остальные ячейки
            var dataRow = new DataRow
            {
                GroupId = groupId,
                RowId = rowId,
                ClassId = classId,
                OpeningBalanceAsset = cells[1].NumericCellValue,
                OpeningBalanceLiability = cells[2].NumericCellValue,
                TurnOverDebit = cells[3].NumericCellValue,
                TurnOverCredit = cells[4].NumericCellValue,
                ClosingBalanceAsset = cells[5].NumericCellValue,
                ClosingBalanceLiability = cells[6].NumericCellValue,
            };

            return dataRow;
        }

        private static Class GetClassTable(ICell classCell, int fileId)
        {
            var cellValue = classCell.ToString();
            //Парсим объеденённую ячейку с информацией
            var classData = ParseMergedCell(cellValue);

            //Формируем объект для таблицы в БД
            var classTable = new Class
            {
                ClassNumber = int.Parse(classData[0]),
                Name = classData[1],
                FileId = fileId
            };

            return classTable;
        }
        private static string[] ParseMergedCell(string cellValue)
        {
            // Используем регулярное выражение для извлечения номера и названия класса
            Match match = Regex.Match(cellValue, @"КЛАСС\s+(\d+)\s+(.+)");
            var classData = new string[2];
            if (match.Success)
            {
                classData[0] = match.Groups[1].Value;
                classData[1] = match.Groups[2].Value;
            }

            return classData;
        }
    }
}