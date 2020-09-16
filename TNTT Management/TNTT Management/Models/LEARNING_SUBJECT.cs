namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LEARNING_SUBJECT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int subject_id { get; set; }

        [StringLength(100)]
        public string subject_name { get; set; }

        public string note { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(100)]
        public string school_year { get; set; }

        [StringLength(100)]
        public string semester { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? start_day { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? end_day { get; set; }

        public int? teacher_id { get; set; }

        public virtual USERLOGIN USERLOGIN { get; set; }
    }
}
