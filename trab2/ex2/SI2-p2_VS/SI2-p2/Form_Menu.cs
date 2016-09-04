using System;
using System.Windows.Forms;

namespace SI2_p2
{
    public partial class Form_Menu : Form
    {
        private Form frm;

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
            if (frm!=null)
            {
                frm.Close();
            }            
            frm = new Form_ListTickets();
            frm.Show();
        }

        //assign technician to recent unassigned tickets
        private void button2_Click(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.Close();
            }
            frm = new Form_AssignTechnician();
            frm.Show();
        }

        //insert action into a ticket
        private void button3_Click(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.Close();
            }
            frm = new Form_InsertAction();
            frm.Show();

        }

        //remove a ticket
        private void button4_Click(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.Close();
            }
            frm = new Form_RemoveTicket();
            frm.Show();
        }

        //export ticket info
        private void button5_Click(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.Close();
            }
            frm = new Form_ExportTicketToXML();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (frm != null)
                {
                    frm.Close();
                }
                Application.Exit();
            }
        }
    }
}
