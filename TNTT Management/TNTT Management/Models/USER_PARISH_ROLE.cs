namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_PARISH_ROLE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_PARISH_ROLE_ID { get; set; }

        public int? roleid { get; set; }

        public int? userid { get; set; }

        public int? parishid { get; set; }

        [StringLength(100)]
        public string role_name { get; set; }

        public bool? isDeleted { get; set; }

        public virtual LOCAL_PARISH LOCAL_PARISH { get; set; }

        public virtual ROLE ROLE { get; set; }

        public virtual USERLOGIN USERLOGIN { get; set; }
    }
}
