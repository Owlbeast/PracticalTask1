using SQLite;

namespace PracticalTask1.Database
{
    [Table("Package")]
    public class Package
    {
        [PrimaryKey]
        [Column("id")]
        public int? Id { get; set; }
        
        [Column("name")]
        public string? Name { get; set; }
        
        [Column("description")]
        public string? Description { get; set; }
        
        [Column("weight")]
        public int? Weight { get; set; }
    }
}
