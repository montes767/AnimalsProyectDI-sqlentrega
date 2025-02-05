using SQLite;

namespace AnimalsProyectDI.Abstractions
{
    public abstract class TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

    }
}
