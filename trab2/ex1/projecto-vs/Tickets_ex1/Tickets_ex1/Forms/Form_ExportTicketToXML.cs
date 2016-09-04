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
	public partial class Form_ExportTicketToXML : Form
	{
		public Form_ExportTicketToXML()
		{
			InitializeComponent();
		}

		//button export click event
		private void btn_export_Click(object sender, EventArgs e)
		{
			using (var ctx = new TicketsEntities())
			{
				DataSet ds = new DataSet();
				// get desired ticket
				String ticketCod = textBox_ticketCode.Text;
				//reads XML_Schema to build dataset
				ds.ReadXmlSchema("XML_Schema.xsd");
				DataTableCollection dtc = ds.Tables;
				//
				var result = ctx.proc_Get_Ticket_Info(ticketCod);
				//populate dataset
				int i = 0;
				foreach (var ticket in result)
				{
					if( i == 0)
					{
						// ticket info
						dtc["ticket"].Rows.Add(new Object[] { ticket.tt_id, ticket.cod, ticket.ticketState, ticket.ticketDescription, 1 });
						dtc["owner"].Rows.Add(new Object[] { ticket.owner_email, ticket.owner_name, ticket.owner_id, ticket.owner_email, 1 });
						dtc["supervisor"].Rows.Add(new Object[] { ticket.anumber, ticket.tech_name, ticket.tech_email, ticket.anumber, 1 });
						dtc["type_type"].Rows.Add(new Object[] { ticket.tt_id, ticket.tt_name, ticket.tt_id, 1 });
						// ticket actions sequence
						dtc["actions"].Rows.Add(new object[] { 1 });
						++i;
					}
					// continues until there's no more actions
					dtc["action"].Rows.Add(new object[] { ticket.orderNumber, ticket.beginDate, ticket.endDate, ticket.orderNumber, 1 });
				}
				ds.DataSetName = "Ticket_Info";
				//saves both xsd and xml
				ds.WriteXml(textBox_filename.Text + ".xml");
				ds.WriteXmlSchema(textBox_filename.Text + ".xsd");
				MessageBox.Show("The ticket " + textBox_ticketCode.Text + " has been exported to " + textBox_filename + ".xml");
				//
				ctx.SaveChanges();
			}
		}
	}
}
