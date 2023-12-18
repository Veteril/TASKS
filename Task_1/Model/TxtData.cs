namespace Task_1.Model
{
    //Модель для БД
    public class TxtData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string RussianString { get; set; }
        public string LatinString { get; set; }
        public int EvenIntegerNumber { get; set; }
        public double FloatNumber { get; set; }
    }
}