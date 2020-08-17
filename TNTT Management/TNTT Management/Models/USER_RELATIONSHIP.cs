namespace TNTT_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_RELATIONSHIP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_relationship_id { get; set; }

        public int? userfrom_id { get; set; }

        public int? userto_id { get; set; }

        [StringLength(100)]
        public string relationship_name { get; set; }

        public bool? isDeleted { get; set; }

        public virtual USERLOGIN USERLOGIN { get; set; }

        public virtual USERLOGIN USERLOGIN1 { get; set; }
    }
}
