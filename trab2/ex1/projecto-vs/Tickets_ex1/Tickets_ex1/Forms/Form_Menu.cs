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
	public partial class Form_Menu : Form
	{
		private Form form;

		public Form_Menu()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		//list tickets
		private void button1_Click(object sender, EventArgs e)
		{
			if (form != null)
			{
				form.Close();
			}
			form = new Form_ListTickets();
			form.Show();
		}

		//assign technician to recent unassigned tickets
		private void button2_Click(object sender, EventArgs e)
		{
			if (form != null)
			{
				form.Close();
			}
			form = new Form_AssignTechnician();
			form.Show();
		}

		//insert action into a ticket
		private void button3_Click(object sender, EventArgs e)
		{
			if (form != null)
			{
				form.Close();
			}
			form = new Form_InsertAction();
			form.Show();
		}

		//remove a ticket
		private void button4_Click(object sender, EventArgs e)
		{
			if (form != null)
			{
				form.Close();
			}
			form = new Form_RemoveTicket();
			form.Show();
		}

		//export ticket info
		private void button5_Click(object sender, EventArgs e)
		{
			if (form != null)
			{
				form.Close();
			}
			form = new Form_ExportTicketToXML();
			form.Show();
		}

		// quit
		private void button6_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				if (form != null)
				{
					form.Close();
				}
				Application.Exit();
			}
		}
	}
}
