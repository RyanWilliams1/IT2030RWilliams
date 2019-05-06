using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RyansEventManager.Models
{
    public class EventType
    {
        [Key]
        public virtual int EventTypeID { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        [StringLength(50, ErrorMessage = "Event Title Cannot Be More Than 50 Characters")]
        public virtual string EventTypeName { get; set; }
    }
}