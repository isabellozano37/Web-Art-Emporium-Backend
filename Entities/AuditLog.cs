using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdLog { get; set; }
        public string? Action { get; set; }
        public string? TableName { get; set; }
        public int RecordId { get; set; }
       
        [Column(TypeName = "datetime2")]
        public DateTime Timestamp { get; set; }
        public int? UserId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
