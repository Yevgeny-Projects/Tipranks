namespace CRMInterview.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CrmEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public EventTypeEnum EventType { get; set; }

        [Required]
        [StringLength(50)]
        public string UserEmail { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
