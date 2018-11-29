namespace ASPAssignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Show
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Show_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Show_theatre { get; set; }

        public string Show_time { get; set; }

        [Required]
        [StringLength(10)]
        public string Show_rating { get; set; }

        public int Movie_id { get; set; }

        public virtual Movy movy { get; set; }
    }
}
