namespace ASPAssignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class movy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public movy()
        {
            shows = new HashSet<show>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int movie_id { get; set; }

        [Required]
        [StringLength(50)]
        public string movie_title { get; set; }

        [Required]
        [StringLength(50)]
        public string movie_genre { get; set; }

        public int movie_duration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<show> shows { get; set; }
    }
}
