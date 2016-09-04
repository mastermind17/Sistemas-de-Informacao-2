using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SI2_p2
{
    public partial class Form_ListTickets : Form
    {
        private string connstr = Utility.GetConnectionString();

        public Form_ListTickets()
        {
            InitializeComponent();
            ConnectAndGet();
        }

        private void ListTicketsForm_Load(object sender, EventArgs e)
        {

        }

        private void ConnectAndGet()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = connstr;
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "select * from dbo.vi_Ticket where ticketState!='closed'";
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            dgv_tickets.Rows.Add(
                                dr["cod"],
                                dr["ticketState"],
                                dr["ticketDescription"],
                                dr["ticketPriority"],
                                dr["ticketType"],
                                dr["ticketUser"],
                                dr["creationDate"],
                                dr["technician"],
                                dr["closeDate"]
                                );
                        }                            
                    }
                }
            }
            catch (SqlException ex)
            {
                if (!Utility.fatalNetworkException(ex.Number)) throw ex;
                SqlConnection.ClearAllPools();
                ConnectAndGet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}
