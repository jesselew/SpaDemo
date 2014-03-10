using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SpaDemo.Models
{
    public enum EventStatus
    {
        Openning = 0,
        Closed = 1,
    }

    public class Event
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [Required]
        public string Owner { get; set; }
        public EventStatus Status { get; set; }
    }
}