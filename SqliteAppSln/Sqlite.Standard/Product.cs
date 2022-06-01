using SQLite;

namespace Sqlite.Standard
{

    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("({0}) {1}, {2}", Id, Name, Gender, Size, Color, Date, Address);
        }
    }
}