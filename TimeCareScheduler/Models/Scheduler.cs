using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TimeCareScheduler.DataAccess;

namespace TimeCareScheduler.Models
{
    public class Scheduler : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Event Title")]
        public string EventName { get; set; }
        [Required]
        [Display(Name = "Start Date/Time")]
        [OverlapInterval]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Display(Name = "End Date/Time")]
        [OverlapInterval]
        public DateTime EndDateTime { get; set; }

        [Required]
        public PriorityType Priority { get; set; }
        [Required]
        public CategoryType Category { get; set; }
        [Required]
        public StatusType Status { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (StartDateTime < DateTime.Now)
            {
                results.Add(new ValidationResult("Start Date and time must be greater than current time", new[] { "StartDateTime" }));
            }

            if (EndDateTime <= StartDateTime)
            {
                results.Add(new ValidationResult("End Date Time must be greater that Start Date Time", new[] { "EndDateTime" }));
            }

            return results;
        }

        public class OverlapInterval : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                TimeCareSchedulerContext db = new TimeCareSchedulerContext();

                var schedule = db.Schedulers.Where(p => (((DateTime)value >= p.StartDateTime) && (((DateTime)value)  <= p.EndDateTime))).ToList();

                var e = schedule.FirstOrDefault();

               if (e == null)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("You already has Event in same time :" + e.EventName);
                
                
            }
        }
    }
}