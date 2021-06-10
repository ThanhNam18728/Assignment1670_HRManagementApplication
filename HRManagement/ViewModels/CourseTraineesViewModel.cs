using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models;

namespace HRManagement.ViewModels
{
    public class CourseTraineesViewModel
    {
        public int CourseId { get; set; }
        public string TraineeId { get; set; }
        public IEnumerable<Trainee> Trainees { get; set; }
    }
}