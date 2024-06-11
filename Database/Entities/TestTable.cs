using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHistory.Database.Entities
{
    [Table("TestTable", Schema = "db")]
    public class TestTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? UserName { get; set; } = "";
    }
}
