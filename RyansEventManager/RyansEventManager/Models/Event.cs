using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;




namespace RyansEventManager.Models
{
    public class Event : IValidatableObject
    {
        [Key]
        public virtual int EventID { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        [StringLength(50, ErrorMessage = "Event Title Cannot Be More Than 50 Characters")]
        public virtual string EventTitle { get; set; }

        [Display(Name = "Event Description")]
        [StringLength(150, ErrorMessage = "Event Description Cannot Be More Than 150 Characters")]
        public virtual string EventDescription { get; set; }

        [Required(ErrorMessage = "Event Start Date Cannot Be a Past Date")]
        [Display(Name = "Event Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Event Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Event End Date Cannot Be a Past Date")]
        [Display(Name = "Event End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Event End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Event Location")]
        public virtual string EventLocation { get; set; }

        [Display(Name = "Event Type")]
        public virtual EventType EventType { get; set; }


        [Required]
        [Display(Name = "Organizer Name")]
        public virtual string OrganizerName { get; set; }

        [Display(Name = "Organizer Contact Information")]
        public virtual string OrganizerContactInfo { get; set; }


        [Required(ErrorMessage = "Maximum Number of Tickets is Required")]
        [Range(1, 9999, ErrorMessage = "Maximum Number of Tickets Cannot Be 0")]
        [Display(Name = "Maximum Number of Tickets")]
        public virtual int MaxTickets { get; set; }


        [Required(ErrorMessage = "Available Number of Tickets is Required")]
        [Range(1, 9999, ErrorMessage = "Availalbe Number of Tickets Cannot Be 0")]
        [Display(Name = "Available Tickets")]
        public virtual int AvailableTickets { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validation 1 : End Date cannot be less than start date
            if (EndDate < StartDate)
            {
                yield return (new ValidationResult("The end date of the event cannot be before the start date",new[] {"EndDate"}));
            }

            // Validation 2 : Address2 and Address 1 not the same
            var testDate = DateTime.Now;
            if (StartDate < testDate)
            {
                yield return (new ValidationResult("The Start Date cannot be a past date", new[] { "StartDate" }));
            }

            // Validation 1 : Address2 and Address 1 not the same
            if (EndDate < testDate)
            {
                yield return (new ValidationResult("The End Date cannot be a past date",new[] {"EndDate"}));
            }

        }
    }
}