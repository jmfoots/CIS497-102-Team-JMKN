using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class Form
    {
        //Primary key
        public int Id { get; set; }

        //Foreign key reference to Supervisor
        public Supervisor CreatedBy { get; set; }

        //Foreign key reference to Employee
        public Employee Employee { get; set; }

        //Employee's job title
        public string Title { get; set; }

        //Assessment period
        public string Period { get; set; }

        //0 = incomplete, 1 = complete
        public bool Complete { get; set; }

        //0 = not deleted, 1 = deleted
        public bool Deleted { get; set; }

        //Rating of 1-5
        public int Communication1 { get; set; }

        //Rating of 1-5
        public int Communication2 { get; set; }

        //Rating of 1-5
        public int Communication3 { get; set; }

        //Average of above ratings
        public float CommunicationAvg { get; set; }

        //Rating of 1-5
        public int Appreciation1 { get; set; }

        //Rating of 1-5
        public int Appreciation2 { get; set; }

        //Rating of 1-5
        public int Appreciation3 { get; set; }

        //Average of above ratings
        public float AppreciationAvg { get; set; }

        //Rating of 1-5
        public int Development1 { get; set; }

        //Rating of 1-5
        public int Development2 { get; set; }

        //Rating of 1-5
        public int Development3 { get; set; }

        //Average of above ratings
        public float DevelopmentAvg { get; set; }

        //Rating of 1-5
        public int Teamwork1 { get; set; }

        //Rating of 1-5
        public int Teamwork2 { get; set; }

        //Rating of 1-5
        public int Teamwork3 { get; set; }

        //Average of above ratings
        public float TeamworkAvg { get; set; }

        //Quality metric
        public string Quality { get; set; }

        //Quality actions & results
        public string QualityAr { get; set; }

        //Service metric
        public string Service { get; set; }

        //Service actions & results
        public string ServiceAr { get; set; }

        //Finance metric
        public string Finance { get; set; }

        //Finance actions & results
        public string FinanceAr { get; set; }

        //People metric
        public string People { get; set; }

        //People actions & results
        public string PeopleAr { get; set; }

        //Growth metric
        public string Growth { get; set; }

        //Growth actions & results
        public string GrowthAr { get; set; }
        
        //Summary of performance
        public string Summary { get; set; }

        //Developmental opportunities and personal goals
        public string Opportunities { get; set; }
    }
}
