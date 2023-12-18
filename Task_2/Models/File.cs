using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Models
{
    //Модедь для файла в БД
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
