//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tickets_ex1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket_Log
    {
        public int orderNumber { get; set; }
        public string sqlCommand { get; set; }
        public Nullable<System.DateTime> modificationDate { get; set; }
        public string ticket { get; set; }
        public Nullable<int> technician { get; set; }
    
        public virtual Technician Technician1 { get; set; }
        public virtual Ticket Ticket1 { get; set; }
    }
}