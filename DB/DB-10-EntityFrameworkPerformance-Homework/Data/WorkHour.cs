//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHour
    {
        public int WorkHoursID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime ReportDate { get; set; }
        public string ReportTask { get; set; }
        public Nullable<int> ReportHours { get; set; }
        public string Comments { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
