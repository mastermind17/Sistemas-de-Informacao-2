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
    
    public partial class Step
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Step()
        {
            this.Ticket_Action = new HashSet<Ticket_Action>();
        }
    
        public int orderNumber { get; set; }
        public string description { get; set; }
        public string ticketType { get; set; }
    
        public virtual Ticket_Type Ticket_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket_Action> Ticket_Action { get; set; }
    }
}
