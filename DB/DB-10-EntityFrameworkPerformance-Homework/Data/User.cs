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
    
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Fullname { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<int> GroupID { get; set; }
    
        public virtual Group Group { get; set; }
    }
}
