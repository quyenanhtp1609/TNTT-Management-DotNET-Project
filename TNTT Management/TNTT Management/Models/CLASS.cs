namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLASS")]
    public partial class CLASS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLASS()
        {
            USERLOGINs = new HashSet<USERLOGIN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int class_id { get; set; }

        [StringLength(100)]
        public string class_name { get; set; }

        public string note { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        public int? form_teacher_id { get; set; }

        public int? group_id { get; set; }

        public virtual USERLOGIN USERLOGIN { get; set; }

        public virtual LEARNING_GROUP LEARNING_GROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERLOGIN> USERLOGINs { get; set; }
    }
}
