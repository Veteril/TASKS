using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Models
{
    //Модедь для класса в БД 
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassNumber { get; set; }
        public int FileId { get; set; }
        public File File { get; set; }
        public ICollection<DataRow> DataRows { get; set;}
    }
}
