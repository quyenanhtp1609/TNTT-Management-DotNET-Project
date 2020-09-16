namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LEARNING_GROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LEARNING_GROUP()
        {
            CLASSes = new HashSet<CLASS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int group_id { get; set; }

        [StringLength(100)]
        public string group_name { get; set; }

        public string note { get; set; }

        public bool? IsDeleted { get; set; }

        public int? parishid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASS> CLASSes { get; set; }

        public virtual LOCAL_PARISH LOCAL_PARISH { get; set; }
    }
}
