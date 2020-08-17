namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERLOGIN")]
    public partial class USERLOGIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERLOGIN()
        {
            USER_PARISH_ROLE = new HashSet<USER_PARISH_ROLE>();
            USER_RELATIONSHIP = new HashSet<USER_RELATIONSHIP>();
            USER_RELATIONSHIP1 = new HashSet<USER_RELATIONSHIP>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userid { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(20)]
        public string userpassword { get; set; }

        [StringLength(30)]
        public string first_name { get; set; }

        [StringLength(30)]
        public string last_name { get; set; }

        [StringLength(100)]
        public string holy_name { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? birthday { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(12)]
        public string phone_number { get; set; }

        [StringLength(100)]
        public string useradress { get; set; }

        [StringLength(100)]
        public string parish { get; set; }

        [StringLength(100)]
        public string diocese { get; set; }

        [StringLength(100)]
        public string province { get; set; }

        [StringLength(100)]
        public string baptised_place { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? baptised_date { get; set; }

        [StringLength(100)]
        public string first_communion_place { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? first_communion_date { get; set; }

        [StringLength(100)]
        public string comfirmation_place { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? comfirmation_date { get; set; }

        [StringLength(100)]
        public string father_name { get; set; }

        [StringLength(12)]
        public string father_phone_number { get; set; }

        [StringLength(100)]
        public string mother_name { get; set; }

        [StringLength(12)]
        public string mother_phone_number { get; set; }

        [StringLength(10)]
        public string usercode { get; set; }

        public bool? isDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_PARISH_ROLE> USER_PARISH_ROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_RELATIONSHIP> USER_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_RELATIONSHIP> USER_RELATIONSHIP1 { get; set; }
    }
}
