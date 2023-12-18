using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Models
{
    //Модедь для строки в БД
    public class DataRow
    {
        public int Id { get; set; }
        public string RowId { get; set; }
        public string GroupId { get; set; }
        public double OpeningBalanceAsset { get; set; }
        public double OpeningBalanceLiability { get; set; }
        public double TurnOverDebit { get; set; }
        public double TurnOverCredit { get; set; }
        public double ClosingBalanceAsset { get; set;}
        public double ClosingBalanceLiability {  get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
