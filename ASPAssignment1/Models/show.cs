namespace ASPAssignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class show
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int show_id { get; set; }

        [Required]
        [StringLength(50)]
        public string show_theatre { get; set; }

        public TimeSpan show_time { get; set; }

        [Required]
        [StringLength(10)]
        public string show_rating { get; set; }

        public int movie_id { get; set; }

        public virtual movy movy { get; set; }
    }
}
