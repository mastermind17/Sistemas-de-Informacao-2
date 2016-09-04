using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets_ex1.Forms
{
	public partial class Form_RemoveTicket : Form
	{
		public Form_RemoveTicket()
		{
			InitializeComponent();
		}

		private void btn_rmv_ticket_Click(object sender, EventArgs e)
		{
			doAction();
		}

		private void doAction()
		{
			using (var ctx = new TicketsEntities())
			{
				String ticketCode = textBox_cod.Text;
				//output paramenter
				ObjectParameter objParam = new ObjectParameter("res", typeof(int));
				ctx.proc_Remove_Ticket(ticketCode, objParam);
				// proc output that indicates success
				int r = Convert.ToInt32(objParam.Value);
				if (r == 0)
				{
					MessageBox.Show("The ticket with code " + ticketCode + "does not exist or has already been removed.");
				}
				else
				{
					MessageBox.Show("The ticket with code " + ticketCode + "has been removed");
				}
				//
				ctx.SaveChanges();
			}
		}
	}
}
