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
	public partial class Form_AssignTechnician : Form
	{
		public Form_AssignTechnician()
		{
			InitializeComponent();
		}

		private void btn_assign_Click(object sender, EventArgs e)
		{
			doAction();
		}

		private void doAction()
		{
			using (var ctx = new TicketsEntities())
			{
				int tech_num = Convert.ToInt16(textBox_techCode.Text);
				//output paramenter
				ObjectParameter objParam = new ObjectParameter("cod", typeof(String));

				ctx.proc_Assign_Technician(tech_num, objParam);
				String ticket_code = Convert.ToString(objParam.Value);
				if (ticket_code.Equals("."))
				{
					MessageBox.Show("The Technician with number " + tech_num + " doesn't exist in the DB");
				}
				else
				{
					if (ticket_code.Equals(""))
					{
						MessageBox.Show("There are no unassigned Tickets.");
					}
					else
					{
						MessageBox.Show("The Technician with number " + tech_num + " has been assigned to Ticket " + ticket_code);
					}
				}
				//
				ctx.SaveChanges();
			}
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}

/*
			using (var ctx = new TicketsEntities())

                using (var dbContextTransaction = ctx.Database.BeginTransaction()) 
                { 
                    try 
                    { 
                        ctx.SaveChanges(); 
 
                        dbContextTransaction.Commit(); 
                    } 
                    catch (Exception) 
                    { 
                        dbContextTransaction.Rollback(); 
                    } 
                } 
*/
