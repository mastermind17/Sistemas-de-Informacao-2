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
	public partial class Form_InsertAction : Form
	{
		private int resp_technician;
		private string ticket_type;

		public Form_InsertAction()
		{
			InitializeComponent();
		}

		//hides the labels, textboxes and button for the insertion part
		private void Conceal()
		{
			lbl_mainInfo.Visible = false;
			lbl_techNum.Visible = false;
			lbl_stepNumber.Visible = false;
			lbl_note.Visible = false;
			btn_Insert.Visible = false;
			textBox_actionNote.Visible = false;
			textBox_techNum.Visible = false;
			textBox_stepNum.Visible = false;
		}

		//shows the labels, textboxes and button for the insertion part
		private void Reveal()
		{
			lbl_mainInfo.Visible = true;
			lbl_techNum.Visible = true;
			lbl_stepNumber.Visible = true;
			lbl_note.Visible = true;
			btn_Insert.Visible = true;
			textBox_actionNote.Visible = true;
			textBox_techNum.Visible = true;
			textBox_stepNum.Visible = true;
		}

		private void textBox_ticketCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				GetTicketInfo();
			}
		}

		private void GetTicketInfo()
		{
			using (var ctx = new TicketsEntities())
			{
				bool reveal = true;
				String ticket_code = textBox_ticketCode.Text;
				//
				// get ticket steps
				//
				var result = ctx.proc_Get_Ticket_Steps(ticket_code);
				var q = result.ToList();

				//

				if (q.Count() == 0)
				{
					//if ticket code doesn't exist, hides the insertion section
					Conceal();
					dgv_steps.Rows.Clear();
					MessageBox.Show("There isn't any ticket with the code " + ticket_code);
				}
				else
				{
					foreach (var line in q)
					{
						if (!line.ticketState.Equals("In Progress"))
						{
							dgv_steps.Rows.Clear();
							MessageBox.Show("The ticket " + ticket_code + " is not in progress");
							Conceal();
							reveal = false;
							break;
						}
						dgv_steps.Rows.Add(
							line.orderNumber,
							line.description
							);
						//stores the responsible technician for the ticket, for future use
						resp_technician = Convert.ToInt32(line.technician);
						//stores the ticket's ticket type for future use
						ticket_type = line.ticketType;
					}
					if (reveal)
					{
						Reveal();
					}
				}
				//
				ctx.SaveChanges();
			}
		}

		private void btn_Insert_Click(object sender, EventArgs e)
		{
			DoInsertion();
		}

		private void DoInsertion()
		{
			using (var ctx = new TicketsEntities())
			{
				//
				// insert ticket action
				//
				String ticketCode = textBox_ticketCode.Text;
				int tech = Convert.ToInt32(textBox_techNum.Text);
				String ticketType = ticket_type;
				int stepOrderNumber = Convert.ToInt32(textBox_stepNum.Text);
				String note = textBox_actionNote.Text;
				//output paramenter
				ObjectParameter objParam = new ObjectParameter("orderNumber", typeof(int));
				ctx.sp_Insert_Ticket_Action(ticketCode, tech, ticketType, stepOrderNumber, note, objParam);
				//
				if (MessageBox.Show("When you press Ok, the action will be closed", "Confirm", MessageBoxButtons.OK) == DialogResult.OK)
				{
					//
					// end ticket action
					//
					ctx.sp_End_Ticket_Action(Convert.ToInt32(objParam.Value), ticketCode);
					//
					if (MessageBox.Show("Did the action solve the problem?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
						if (resp_technician == Convert.ToInt32(textBox_techNum.Text))
						{
							//
							// close ticket
							//
							ctx.sp_Close_Ticket(ticketCode, tech);
							MessageBox.Show("The ticket " + ticketCode + " has been closed.");
						}
						else
						{
							MessageBox.Show("You're not the technician responsible for this ticket, so it's not closed.");
						}
						dgv_steps.Rows.Clear();
					}
				}
				//
				ctx.SaveChanges();
			}
		}
	}
}

/*				var query = ctx.Tickets.SqlQuery(
					"select orderNumber,description,technician,ticketState,Step.ticketType from vi_Ticket " +
					"inner join Step " +
					"on vi_Ticket.ticketType = Step.ticketType " +
					"where cod = " + ticket_code
					);
*/