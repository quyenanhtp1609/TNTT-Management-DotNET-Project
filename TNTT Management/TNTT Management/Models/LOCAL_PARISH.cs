namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOCAL_PARISH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOCAL_PARISH()
        {
            LEARNING_GROUP = new HashSet<LEARNING_GROUP>();
            USER_PARISH_ROLE = new HashSet<USER_PARISH_ROLE>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int local_parish_id { get; set; }

        [StringLength(100)]
        public string parish_name { get; set; }

        [StringLength(100)]
        public string parish_address { get; set; }

        [StringLength(100)]
        public string diocese { get; set; }

        [StringLength(100)]
        public string province { get; set; }

        public int? created_by { get; set; }

        public bool? isDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LEARNING_GROUP> LEARNING_GROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_PARISH_ROLE> USER_PARISH_ROLE { get; set; }
    }
}
