using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets_ex1.Forms
{
	public partial class Form_ListTickets : Form
	{

		public Form_ListTickets()
		{
			InitializeComponent();
			GetTickets();
		}

		private void ListTicketsForm_Load(object sender, EventArgs e)
		{

		}

		private void GetTickets()
		{
			using (var ctx = new TicketsEntities())
			{
				var query = from t in ctx.vi_Ticket
							where t.ticketState != "closed"
							select t;
				//
				foreach(var ticket in query)
				{
					dgv_tickets.Rows.Add(
						ticket.cod,
						ticket.ticketState,
						ticket.ticketDescription,
						ticket.ticketPriority,
						ticket.ticketType,
						ticket.ticketUser,
						ticket.creationDate,
						ticket.technician,
						ticket.closeDate
						);
				}
				ctx.SaveChanges();
			}
		}
	}
}
