namespace MRS_Store.Models
{
    public class Stock : DbObject
    {
        //public int Id { get; set; }
        public string Symbol{ get; set; }
        public double PricePreShare{ get; set; }

    }
}