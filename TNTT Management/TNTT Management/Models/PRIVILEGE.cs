namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRIVILEGES")]
    public partial class PRIVILEGE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int privilegeid { get; set; }

        [StringLength(100)]
        public string privilegename { get; set; }

        public bool? isDeleted { get; set; }
    }
}
