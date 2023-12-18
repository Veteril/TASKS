using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2.Database
{
    public static class DatabaseActions
    {
        //Метод для считывания всей информации из файла
        public static void GetAllFile(DataGridView dataGridView, string fileName) 
        {
            //Формируем запрос при помощи EntityFramework
            using (var dbContext = new DatabaseContext())
            {
                var result = dbContext.Rows
                    .Include(r => r.Class)
                    .ThenInclude(c => c.File)
                    .Where(r => r.Class.File.Name == fileName)
                    .OrderBy(r => r.Class.ClassNumber)
                    .ThenBy(r => r.GroupId)
                    .ThenBy(r => r.RowId)
                    .Select(r => new
                    {
                        r.Class.ClassNumber,
                        r.GroupId,
                        r.RowId,
                        r.OpeningBalanceAsset,
                        r.OpeningBalanceLiability,
                        r.TurnOverDebit,
                        r.TurnOverCredit,
                        r.ClosingBalanceAsset,
                        r.ClosingBalanceLiability,
                    })
                    .ToList();
                dataGridView.DataSource = result;
            }
        }

        //Метод для считывания информации о классах
        public static void GetClassesInformation(DataGridView dataGridView, string fileName)
        {
            using (var dbContext = new DatabaseContext())
            {
                var result = dbContext.Classes
                    .Include(c => c.File)
                    .Include(c => c.DataRows)
                    .Where(c => c.File.Name == fileName)
                    .OrderBy(c => c.ClassNumber)
                    .Select(c => new
                    {
                        c.ClassNumber,
                        c.Name,
                        DataRowCount = c.DataRows.Count(),
                        DataRowGroupsCount = c.DataRows.GroupBy(r => r.GroupId).Count()
                    })
                    .ToList();
                dataGridView.DataSource = result;
            }
        }

        //Метод для считывания информация о группах классов
        public static void GetGroupsInformation(DataGridView dataGridView, string fileName)
        {
            using (var dbContext = new DatabaseContext())
            {
                var result = dbContext.Rows
                    .Include(r => r.Class)
                    .ThenInclude(c => c.File)
                    .Where(r => r.Class.File.Name == fileName)
                    .GroupBy(r => r.GroupId)
                    .Select(group => new
                    {
                        GroupId = group.Key,
                        SumOpeningBalanceAsset = group.Sum(r => r.OpeningBalanceAsset),
                        SumOpeningBalanceLiability = group.Sum(r => r.OpeningBalanceLiability),
                        SumTurnOverDebit = group.Sum(r => r.TurnOverDebit),
                        SumTurnOverCredit = group.Sum(r => r.TurnOverCredit),
                        SumClosingBalanceAsset = group.Sum(r => r.ClosingBalanceAsset),
                        SumClosingBalanceLiability = group.Sum(r => r.ClosingBalanceLiability),
                    })
                    .ToList();

                dataGridView.DataSource = result;
            }
        }

        //Метод для считывания информация о загруженных файлах
        public static void GetDownloadedFiles(DataGridView dataGridView)
        {
            using (var dbContext = new DatabaseContext())
            {
                var result = dbContext.Files
                    .Select(f => new 
                    {
                        f.Id,
                        f.Name
                    })
                    .ToList();

                dataGridView.DataSource = result;
            }
        }
    }
}
