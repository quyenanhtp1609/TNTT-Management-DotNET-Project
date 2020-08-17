namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROLES")]
    public partial class ROLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROLE()
        {
            USER_PARISH_ROLE = new HashSet<USER_PARISH_ROLE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roleid { get; set; }

        [StringLength(100)]
        public string rolename { get; set; }

        public int? limit { get; set; }

        public bool? isDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_PARISH_ROLE> USER_PARISH_ROLE { get; set; }
    }
}
